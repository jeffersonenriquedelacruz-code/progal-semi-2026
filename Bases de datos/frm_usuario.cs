using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuevarama
{
    public partial class frm_usuario : Form
    {
        public frm_usuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga los datos de tu tabla en el DataSet al iniciar
            this.usuarios_usss128826TableAdapter.Fill(this.db_academicaDataSet.usuarios_usss128826);

            // Pone el formulario listo para un nuevo registro en blanco de entrada
            this.usuarios_usss128826BindingSource.AddNew();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        // --- EVENTO PARA EVITAR CRASHES SI UN CAMPO OBLIGATORIO QUEDA VACÍO ---
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("El campo 'usuario' no puede quedar vacío. Por favor, asígnale un valor.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {

        }

        // --- BOTÓN AGREGAR ---
        private void Agregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.usuarios_usss128826BindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.db_academicaDataSet);
                this.usuarios_usss128826TableAdapter.Fill(this.db_academicaDataSet.usuarios_usss128826);

                MessageBox.Show("¡Registro agregado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Prepara automáticamente otra línea en blanco para el siguiente registro
                this.usuarios_usss128826BindingSource.AddNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN MODIFICAR ---
        private void Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.usuarios_usss128826BindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.db_academicaDataSet);
                this.usuarios_usss128826TableAdapter.Fill(this.db_academicaDataSet.usuarios_usss128826);

                MessageBox.Show("¡Registro modificado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN ELIMINAR ---
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.usuarios_usss128826BindingSource.RemoveCurrent();
                    this.tableAdapterManager.UpdateAll(this.db_academicaDataSet);
                    this.usuarios_usss128826TableAdapter.Fill(this.db_academicaDataSet.usuarios_usss128826);

                    MessageBox.Show("¡Registro eliminado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.usuarios_usss128826BindingSource.AddNew();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- BOTÓN NUEVO ---
        private void Nuevo_Click(object sender, EventArgs e)
        {
            this.usuarios_usss128826BindingSource.AddNew();
        }

        // --- BOTÓN SALIR ---
        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modificar_Click_1(object sender, EventArgs e)
        {

        }

        private void Eliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void Salir_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.usuarios_usss128826BindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.usuarios_usss128826BindingSource.EndEdit();
            this.usuarios_usss128826TableAdapter.Update(this.db_academicaDataSet.usuarios_usss128826);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.usuarios_usss128826BindingSource.AddNew();
        }
    }
}