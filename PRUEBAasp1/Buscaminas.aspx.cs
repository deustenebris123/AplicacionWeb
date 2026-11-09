using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRUEBAasp1
{
    [Serializable]
    public class EstadoJuego
    {
        public bool[,] Minas;
        public bool[,] Abiertas;
        public bool[,] Banderas;
        public bool Terminado;
        public bool Gano;
    }

    public partial class Buscaminas : Page
    {
        const int Filas = 8;
        const int Columnas = 8;
        const int TotalMinas = 10;

        private Button[,] botones = new Button[Filas, Columnas];

        private EstadoJuego Estado
        {
            get { return (EstadoJuego)Session["estadoBuscaminas"]; }
            set { Session["estadoBuscaminas"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Estado == null)
                NuevoJuego();

            // Los botones se crean en cada petición para que sus eventos funcionen
            CrearBotones();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Dibujar();
        }

        private void CrearBotones()
        {
            phTablero.Controls.Clear();
            for (int f = 0; f < Filas; f++)
            {
                Panel fila = new Panel { CssClass = "fila" };
                for (int c = 0; c < Columnas; c++)
                {
                    Button b = new Button();
                    b.ID = "c_" + f + "_" + c;
                    b.CommandArgument = f + "," + c;
                    b.CssClass = "celda";
                    b.Click += Celda_Click;
                    botones[f, c] = b;
                    fila.Controls.Add(b);
                }
                phTablero.Controls.Add(fila);
            }
        }

        private void NuevoJuego()
        {
            EstadoJuego e = new EstadoJuego();
            e.Minas = new bool[Filas, Columnas];
            e.Abiertas = new bool[Filas, Columnas];
            e.Banderas = new bool[Filas, Columnas];

            Random rnd = new Random();
            int colocadas = 0;
            while (colocadas < TotalMinas)
            {
                int f = rnd.Next(Filas);
                int c = rnd.Next(Columnas);
                if (!e.Minas[f, c])
                {
                    e.Minas[f, c] = true;
                    colocadas++;
                }
            }
            Estado = e;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoJuego();
            chkBandera.Checked = false;
        }

        protected void Celda_Click(object sender, EventArgs e)
        {
            EstadoJuego est = Estado;
            if (est.Terminado) return;

            string[] pos = ((Button)sender).CommandArgument.Split(',');
            int f = int.Parse(pos[0]);
            int c = int.Parse(pos[1]);

            if (est.Abiertas[f, c]) return;

            // Modo bandera: poner / quitar bandera
            if (chkBandera.Checked)
            {
                est.Banderas[f, c] = !est.Banderas[f, c];
                return;
            }

            if (est.Banderas[f, c]) return;

            if (est.Minas[f, c])
            {
                est.Terminado = true;
                est.Gano = false;
                return;
            }

            Abrir(est, f, c);

            if (HaGanado(est))
            {
                est.Terminado = true;
                est.Gano = true;
            }
        }

        // Abre la celda; si no tiene minas alrededor, abre las vecinas (recursivo con pila)
        private void Abrir(EstadoJuego est, int f, int c)
        {
            Stack<int[]> pila = new Stack<int[]>();
            pila.Push(new[] { f, c });

            while (pila.Count > 0)
            {
                int[] p = pila.Pop();
                int rf = p[0], rc = p[1];

                if (rf < 0 || rc < 0 || rf >= Filas || rc >= Columnas) continue;
                if (est.Abiertas[rf, rc] || est.Minas[rf, rc]) continue;

                est.Abiertas[rf, rc] = true;
                est.Banderas[rf, rc] = false;

                if (ContarVecinas(est, rf, rc) == 0)
                {
                    for (int df = -1; df <= 1; df++)
                        for (int dc = -1; dc <= 1; dc++)
                            if (df != 0 || dc != 0)
                                pila.Push(new[] { rf + df, rc + dc });
                }
            }
        }

        private int ContarVecinas(EstadoJuego est, int f, int c)
        {
            int total = 0;
            for (int df = -1; df <= 1; df++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    int nf = f + df, nc = c + dc;
                    if ((df != 0 || dc != 0) && nf >= 0 && nc >= 0 && nf < Filas && nc < Columnas && est.Minas[nf, nc])
                        total++;
                }
            }
            return total;
        }

        private bool HaGanado(EstadoJuego est)
        {
            for (int f = 0; f < Filas; f++)
                for (int c = 0; c < Columnas; c++)
                    if (!est.Minas[f, c] && !est.Abiertas[f, c])
                        return false;
            return true;
        }

        // Refleja el estado del juego en los botones
        private void Dibujar()
        {
            EstadoJuego est = Estado;
            int banderas = 0;

            for (int f = 0; f < Filas; f++)
            {
                for (int c = 0; c < Columnas; c++)
                {
                    Button b = botones[f, c];
                    b.CssClass = "celda";
                    b.Text = "";
                    b.Enabled = !est.Terminado;

                    if (est.Banderas[f, c]) banderas++;

                    if (est.Abiertas[f, c])
                    {
                        int n = ContarVecinas(est, f, c);
                        b.CssClass = "celda abierta" + (n > 0 ? " n" + n : "");
                        b.Text = n > 0 ? n.ToString() : "";
                        b.Enabled = false;
                    }
                    else if (est.Terminado && est.Minas[f, c])
                    {
                        b.CssClass = "celda mina";
                        b.Text = "💣";
                    }
                    else if (est.Banderas[f, c])
                    {
                        b.Text = "🚩";
                    }
                }
            }

            lblInfo.Text = "Minas: " + TotalMinas + " | Banderas: " + banderas;

            if (est.Terminado)
            {
                lblMensaje.Text = est.Gano ? "🎉 ¡Ganaste!" : "💥 ¡Perdiste! Pisaste una mina.";
                lblMensaje.ForeColor = est.Gano ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            else
            {
                lblMensaje.Text = "";
            }
        }
    }
}
