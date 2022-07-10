using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /* VARIABLES */
        public double Num1 = 0;
        public double Num2;
        public string operacion = "";
        public double resultado;

        /* BORRAR */
        private void borrarTodo_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "";
            Reserva.Text = "";
        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            string textoCompleto = Display.Text;

            if(textoCompleto != "")
                Display.Text = textoCompleto.Remove(textoCompleto.Length - 1);
            //Borro un solo caracter, solo si el display tiene contenido

        }

        /* NUMEROS */
        private void mostrarEnPantalla(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            Display.Text += btn.Content;
        }

        /* OPERADORES */
        private void punto_Click(object sender, RoutedEventArgs e)
        {
            //Si no hay coma escrita Y hay ALGO escrito en el display
            //Entonces escribo ,

            if (!hayComa(Display.Text) && Display.Text.Length > 0)
            {
                Display.Text += ",";
            }
        }

        public bool hayComa(string a)
        {
            //Me fijo si ya escribieron una coma
            if (a.Length != 0)
            {
                if (a.Contains(','))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private void OperadorClick(object sender, RoutedEventArgs e)
        {
            MandarArriba(sender);
        }

        private void igual_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length != 0 && Num1 > 0)
            {
                Num2 = Double.Parse(Display.Text);

                operacion = Reserva.Text.Substring(Reserva.Text.Length - 1, 1);

                Reserva.Text += Num2;

                switch (operacion)
                {
                    case ("+"):
                        resultado = Num1 + Num2;
                        Display.Text = resultado.ToString();
                        break;
                    case ("-"):
                        resultado = Num1 - Num2;
                        Display.Text = resultado.ToString();
                        break;
                    case ("x"):
                        resultado = Num1 * Num2;
                        Display.Text = resultado.ToString();
                        break;
                    case ("/"):
                        resultado = Num1 / Num2;
                        Display.Text = resultado.ToString();
                        break;
                }
            }
        }


        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true; //Evito el ingreso por teclado
        }

        public void MandarArriba(object a)
        {
            if (Display.Text.Length != 0)
            {
                Button operacion = (Button)a;

                Num1 = Double.Parse(Display.Text);
                Reserva.Text = Display.Text + operacion.Content;
                Display.Text = "";
            }
        }

        private void EasterEgg(object sender, RoutedEventArgs e)
        {

        }
    }
}