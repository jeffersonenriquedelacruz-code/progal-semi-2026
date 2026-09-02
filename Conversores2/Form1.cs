using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Conversores2
{
    public partial class Form1 : Form
    {
        // Estructura para almacenar las 10 unidades por categoría
        public class UnidadMedida
        {
            public string Nombre { get; set; }
            public double FactorABase { get; set; }
        }

        private Dictionary<string, List<UnidadMedida>> categorias;
        private Label lblResultado;

        public Form1()
        {
            InitializeComponent();
            CrearLabelResultado();
            CargarDatos();
        }

        private void CrearLabelResultado()
        {
            // Se crea dinámicamente el Label para mostrar el resultado en pantalla
            lblResultado = new Label();
            lblResultado.Location = new Point(180, 260);
            lblResultado.Size = new Size(400, 30);
            lblResultado.Font = new Font("Arial", 11, FontStyle.Bold);
            lblResultado.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblResultado);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Se asocian las categorías al ComboBox principal (comboBox3)
            comboBox3.DataSource = categorias.Keys.ToList();
            comboBox3.SelectedIndex = 0;

            // Asignación de eventos por código
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            button1.Click += button1_Click;

            ActualizarCombosUnidades();
        }

        private void CargarDatos()
        {
            categorias = new Dictionary<string, List<UnidadMedida>>
            {
                ["Monedas"] = new List<UnidadMedida>
                {
                    new UnidadMedida { Nombre = "Dólar estadounidense (USD)", FactorABase = 1.0 },
                    new UnidadMedida { Nombre = "Euro (EUR)", FactorABase = 1.08 },
                    new UnidadMedida { Nombre = "Libra esterlina (GBP)", FactorABase = 1.27 },
                    new UnidadMedida { Nombre = "Yen japonés (JPY)", FactorABase = 0.0067 },
                    new UnidadMedida { Nombre = "Dólar canadiense (CAD)", FactorABase = 0.74 },
                    new UnidadMedida { Nombre = "Peso mexicano (MXN)", FactorABase = 0.058 },
                    new UnidadMedida { Nombre = "Quetzal guatemalteco (GTQ)", FactorABase = 0.13 },
                    new UnidadMedida { Nombre = "Lempira hondureño (HNL)", FactorABase = 0.040 },
                    new UnidadMedida { Nombre = "Córdoba nicaragüense (NIO)", FactorABase = 0.027 },
                    new UnidadMedida { Nombre = "Colón costarricense (CRC)", FactorABase = 0.0019 }
                },
                ["Masa"] = new List<UnidadMedida>
                {
                    new UnidadMedida { Nombre = "Kilogramo (kg)", FactorABase = 1.0 },
                    new UnidadMedida { Nombre = "Gramo (g)", FactorABase = 0.001 },
                    new UnidadMedida { Nombre = "Miligramo (mg)", FactorABase = 0.000001 },
                    new UnidadMedida { Nombre = "Libra (lb)", FactorABase = 0.453592 },
                    new UnidadMedida { Nombre = "Onza (oz)", FactorABase = 0.0283495 },
                    new UnidadMedida { Nombre = "Tonelada métrica (t)", FactorABase = 1000.0 },
                    new UnidadMedida { Nombre = "Arroba (@)", FactorABase = 11.3398 },
                    new UnidadMedida { Nombre = "Quintal (qq)", FactorABase = 45.3592 },
                    new UnidadMedida { Nombre = "Grano (gr)", FactorABase = 0.0000647989 },
                    new UnidadMedida { Nombre = "Stone (st)", FactorABase = 6.35029 }
                },
                ["Volumen"] = new List<UnidadMedida>
                {
                    new UnidadMedida { Nombre = "Litro (L)", FactorABase = 1.0 },
                    new UnidadMedida { Nombre = "Mililitro (mL)", FactorABase = 0.001 },
                    new UnidadMedida { Nombre = "Metro cúbico (m³)", FactorABase = 1000.0 },
                    new UnidadMedida { Nombre = "Galón (US gal)", FactorABase = 3.78541 },
                    new UnidadMedida { Nombre = "Cuarto de galón (qt)", FactorABase = 0.946353 },
                    new UnidadMedida { Nombre = "Pinta (pt)", FactorABase = 0.473176 },
                    new UnidadMedida { Nombre = "Taza (cup)", FactorABase = 0.24 },
                    new UnidadMedida { Nombre = "Onza líquida (fl oz)", FactorABase = 0.0295735 },
                    new UnidadMedida { Nombre = "Cucharada (tbsp)", FactorABase = 0.0147868 },
                    new UnidadMedida { Nombre = "Cucharadita (tsp)", FactorABase = 0.00492892 }
                },
                ["Longitud"] = new List<UnidadMedida>
                {
                    new UnidadMedida { Nombre = "Metro (m)", FactorABase = 1.0 },
                    new UnidadMedida { Nombre = "Kilómetro (km)", FactorABase = 1000.0 },
                    new UnidadMedida { Nombre = "Centímetro (cm)", FactorABase = 0.01 },
                    new UnidadMedida { Nombre = "Milímetro (mm)", FactorABase = 0.001 },
                    new UnidadMedida { Nombre = "Milla (mi)", FactorABase = 1609.34 },
                    new UnidadMedida { Nombre = "Yarda (yd)", FactorABase = 0.9144 },
                    new UnidadMedida { Nombre = "Pie (ft)", FactorABase = 0.3048 },
                    new UnidadMedida { Nombre = "Pulgada (in)", FactorABase = 0.0254 },
                    new UnidadMedida { Nombre = "Milla náutica (nmi)", FactorABase = 1852.0 },
                    new UnidadMedida { Nombre = "Micrómetro (µm)", FactorABase = 0.000001 }
                },
                ["Almacenamiento"] = new List<UnidadMedida>
                {
                    new UnidadMedida { Nombre = "Megabyte (MB)", FactorABase = 1.0 },
                    new UnidadMedida { Nombre = "Bit (b)", FactorABase = 0.00000011920928955078125 },
                    new UnidadMedida { Nombre = "Byte (B)", FactorABase = 0.00000095367431640625 },
                    new UnidadMedida { Nombre = "Kilobyte (KB)", FactorABase = 0.0009765625 },
                    new UnidadMedida { Nombre = "Gigabyte (GB)", FactorABase = 1024.0 },
                    new UnidadMedida { Nombre = "Terabyte (TB)", FactorABase = 1048576.0 },
                    new UnidadMedida { Nombre = "Petabyte (PB)", FactorABase = 1073741824.0 },
                    new UnidadMedida { Nombre = "Nibble", FactorABase = 0.000000476837158203125 },
                    new UnidadMedida { Nombre = "Kibibyte (KiB)", FactorABase = 0.001 },
                    new UnidadMedida { Nombre = "Mebibyte (MiB)", FactorABase = 1.048576 }
                },
                ["Tiempo"] = new List<UnidadMedida>
                {
                    new UnidadMedida { Nombre = "Segundo (s)", FactorABase = 1.0 },
                    new UnidadMedida { Nombre = "Milisegundo (ms)", FactorABase = 0.001 },
                    new UnidadMedida { Nombre = "Minuto (min)", FactorABase = 60.0 },
                    new UnidadMedida { Nombre = "Hora (h)", FactorABase = 3600.0 },
                    new UnidadMedida { Nombre = "Día (d)", FactorABase = 86400.0 },
                    new UnidadMedida { Nombre = "Semana", FactorABase = 604800.0 },
                    new UnidadMedida { Nombre = "Mes (30 días)", FactorABase = 2592000.0 },
                    new UnidadMedida { Nombre = "Año (365 días)", FactorABase = 31536000.0 },
                    new UnidadMedida { Nombre = "Década", FactorABase = 315360000.0 },
                    new UnidadMedida { Nombre = "Siglo", FactorABase = 3153600000.0 }
                }
            };
        }

        private void ActualizarCombosUnidades()
        {
            if (comboBox3.SelectedItem == null) return;

            string tipoSeleccionado = comboBox3.SelectedItem.ToString();
            var listaUnidades = categorias[tipoSeleccionado];

            // Cargar datos en ComboBox De (comboBox1) y A (comboBox2)
            comboBox1.DataSource = listaUnidades.ToList();
            comboBox1.DisplayMember = "Nombre";

            comboBox2.DataSource = listaUnidades.ToList();
            comboBox2.DisplayMember = "Nombre";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCombosUnidades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double cantidad))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var unidadOrigen = (UnidadMedida)comboBox1.SelectedItem;
            var unidadDestino = (UnidadMedida)comboBox2.SelectedItem;

            if (unidadOrigen == null || unidadDestino == null) return;

            // Fórmula universal de conversión
            double valorEnBase = cantidad * unidadOrigen.FactorABase;
            double resultado = valorEnBase / unidadDestino.FactorABase;

            lblResultado.Text = $"Resultado: {resultado:N4} {unidadDestino.Nombre}";
        }
    }
}