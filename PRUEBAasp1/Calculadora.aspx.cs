using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRUEBAasp1
{
    public partial class Calculadora : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Operar_Click(object sender, EventArgs e)
        {
            lblResultado.CssClass = "resultado";

            double a, b;
            if (!double.TryParse(txtNumero1.Text, out a) || !double.TryParse(txtNumero2.Text, out b))
            {
                MostrarError("Ingresa dos números válidos.");
                return;
            }

            string operacion = ((Button)sender).CommandArgument;
            double resultado = 0;

            switch (operacion)
            {
                case "+": resultado = a + b; break;
                case "-": resultado = a - b; break;
                case "*": resultado = a * b; break;
                case "/":
                    if (b == 0)
                    {
                        MostrarError("No se puede dividir entre cero.");
                        return;
                    }
                    resultado = a / b;
                    break;
            }

            lblResultado.Text = "Resultado: " + resultado;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        private void MostrarError(string mensaje)
        {
            lblResultado.CssClass = "resultado error";
            lblResultado.Text = mensaje;
        }
    }
}
