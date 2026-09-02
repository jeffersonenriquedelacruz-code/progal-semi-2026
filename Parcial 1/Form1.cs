using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Cargar unidades al iniciar
            CargarUnidades();

            // Forzar la suscripción al evento del botón por si no está en el Designer
            if (button1 != null)
            {
                button1.Click -= button1_Click; // Evita duplicar suscripción
                button1.Click += button1_Click;
            }
        }

        private void CargarUnidades()
        {
            string[] unidades = {
                "Pie Cuadrado",
                "Vara Cuadrada",
                "Yarda Cuadrada",
                "Metro Cuadrado",
                "Tareas",
                "Manzana",
                "Hectárea"
            };

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            comboBox1.Items.AddRange(unidades);
            comboBox2.Items.AddRange(unidades);

            comboBox1.SelectedIndex = 3; // Metro Cuadrado 
            comboBox2.SelectedIndex = 1; // Vara Cuadrada 

            label4.Text = "Resultado: ---";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EjecutarConversion();
        }

        private void EjecutarConversion()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor ingrese un dato a convertir.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (double.TryParse(textBox1.Text, out double cantidad))
            {
                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    string origen = comboBox1.SelectedItem.ToString();
                    string destino = comboBox2.SelectedItem.ToString();

                    double resultado = ConvertirArea(cantidad, origen, destino);

                    label4.Text = $"Resultado: {resultado:N4} {destino}";
                }
                else
                {
                    MessageBox.Show("Seleccione las unidades de conversión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ConvertirArea(double valor, string origen, string destino)
        {
            
            double enMetrosCuadrados = 0;

            switch (origen)
            {
                case "Pie Cuadrado":
                    enMetrosCuadrados = valor * 0.092903;
                    break;
                case "Vara Cuadrada":
                    enMetrosCuadrados = valor * 0.698896;
                    break;
                case "Yarda Cuadrada":
                    enMetrosCuadrados = valor * 0.836127;
                    break;
                case "Metro Cuadrado":
                    enMetrosCuadrados = valor;
                    break;
                case "Tareas":
                    enMetrosCuadrados = valor * 628.86;
                    break;
                case "Manzana":
                    enMetrosCuadrados = valor * 6988.96;
                    break;
                case "Hectárea":
                    enMetrosCuadrados = valor * 10000.0;
                    break;
                default:
                    return 0;
            }

            // 2. Convertir de metros cuadrados (m²) a la otra unidad 
            double resultado = 0;

            switch (destino)
            {
                case "Pie Cuadrado":
                    resultado = enMetrosCuadrados / 0.092903;
                    break;
                case "Vara Cuadrada":
                    resultado = enMetrosCuadrados / 0.698896;
                    break;
                case "Yarda Cuadrada":
                    resultado = enMetrosCuadrados / 0.836127;
                    break;
                case "Metro Cuadrado":
                    resultado = enMetrosCuadrados;
                    break;
                case "Tareas":
                    resultado = enMetrosCuadrados / 628.86;
                    break;
                case "Manzana":
                    resultado = enMetrosCuadrados / 6988.96;
                    break;
                case "Hectárea":
                    resultado = enMetrosCuadrados / 10000.0;
                    break;
                default:
                    return 0;
            }

            return resultado;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}