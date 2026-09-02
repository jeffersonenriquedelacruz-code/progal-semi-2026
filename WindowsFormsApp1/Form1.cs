using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Paciente> listaPacientes = new List<Paciente>();
        private string prioridadSeleccionada = "";


        private TextBox txtNombre;
        private TextBox txtEdad;
        private ComboBox cmbMotivo;
        private DataGridView tabla;


        private Label lbl2;
        private Label lbl3;
        private Label lbl4;

        public Form1()
        {
            InitializeComponent();
            EnlazarControles();
        }

        private void EnlazarControles()
        {

            var textBoxes = this.Controls.OfType<TextBox>().OrderBy(t => t.Left).ToList();

            if (textBoxes.Count >= 2)
            {
                txtNombre = textBoxes[0];
                txtEdad = textBoxes[1];
            }
            else if (textBoxes.Count == 1)
            {
                txtNombre = textBoxes[0];
            }


            cmbMotivo = this.Controls.OfType<ComboBox>().FirstOrDefault();
            tabla = this.Controls.OfType<DataGridView>().FirstOrDefault();


            if (tabla != null)
            {
                tabla.AutoGenerateColumns = false;


                if (tabla.Columns.Count >= 4)
                {
                    tabla.Columns[0].DataPropertyName = "Nombre";
                    tabla.Columns[1].DataPropertyName = "Edad";
                    tabla.Columns[2].DataPropertyName = "Motivo";
                    tabla.Columns[3].DataPropertyName = "HoraIngreso";
                }
                else if (tabla.Columns.Count == 0)
                {
                    tabla.AutoGenerateColumns = true;
                }
            }


            lbl2 = this.Controls.Find("label2", true).FirstOrDefault() as Label;
            lbl3 = this.Controls.Find("label3", true).FirstOrDefault() as Label;
            lbl4 = this.Controls.Find("label4", true).FirstOrDefault() as Label;

            if (lbl2 == null  lbl3 == null  lbl4 == null)
            {
                var labels = this.Controls.OfType<Label>().OrderBy(l => l.Top).ToList();
                if (labels.Count >= 4)
                {
                    lbl2 = labels[1];
                    lbl3 = labels[2];
                    lbl4 = labels[3];
                }
            }


            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    string texto = btn.Text.ToLower();

                    if (texto.Contains("rojo")  texto.Contains("prioridad 1")  texto.Contains("prioridad i"))
                        btn.Click += (s, e) => SeleccionarPrioridad("Prioridad 1 - Rojo");
                    else if (texto.Contains("amarillo")  texto.Contains("prioridad 2")  texto.Contains("prioridad ii"))
                        btn.Click += (s, e) => SeleccionarPrioridad("Prioridad 2 - Amarillo");
                    else if (texto.Contains("verde")  texto.Contains("prioridad 3")  texto.Contains("prioridad iii"))
                        btn.Click += (s, e) => SeleccionarPrioridad("Prioridad 3 - Verde");
                    else if (texto.Contains("registrar"))
                        btn.Click += RegistrarPaciente;
                    else if (texto.Contains("atender") || texto.Contains("siguiente"))
                        btn.Click += AtenderSiguiente;
                }
            }


            if (cmbMotivo != null)
            {
                cmbMotivo.Items.Clear();
                cmbMotivo.Items.Add("General / Chequeo");
                cmbMotivo.Items.Add("Dolor agudo / Lesión");
                cmbMotivo.Items.Add("Fiebre alta");
                cmbMotivo.Items.Add("Emergencia crítica");
                cmbMotivo.SelectedIndex = 0;
            }
        }