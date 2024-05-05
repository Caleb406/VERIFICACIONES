using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORMESTUDIANTES
{
    public partial class FormNotas : Form
    {
        private List<Estudiante> estudiantesMostrados = new List<Estudiante>();

        public FormNotas(List<Estudiante> estudiantesMostrados)
        {
            InitializeComponent();
            this.estudiantesMostrados = estudiantesMostrados;
        }



        private void btnCalcularPromedio_Click(object sender, EventArgs e)
        {
            // Validar que se hayan ingresado todas las notas y que sean valores numéricos
            decimal nota1, nota2, nota3, nota4;
            if (!decimal.TryParse(txtNota1.Text, out nota1) || !decimal.TryParse(txtNota2.Text, out nota2) ||
                !decimal.TryParse(txtNota3.Text, out nota3) || !decimal.TryParse(txtNota4.Text, out nota4))
            {
                MessageBox.Show("Por favor ingrese valores numéricos válidos para todas las notas.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcula el promedio
            decimal promedio = (nota1 + nota2 + nota3 + nota4) / 4;

            // Muestra el resultado
            MessageBox.Show($"El promedio es: {promedio}", "Promedio Calculado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            // Configuro las columnas del DataGridView
            dataGridViewEstudiantes.ColumnCount = 7;
            dataGridViewEstudiantes.Columns[0].Name = "Carnet";
            dataGridViewEstudiantes.Columns[1].Name = "Nombre";
            dataGridViewEstudiantes.Columns[2].Name = "Fecha de Nacimiento";
            dataGridViewEstudiantes.Columns[3].Name = "Correo";
            dataGridViewEstudiantes.Columns[4].Name = "Responsables";
            dataGridViewEstudiantes.Columns[5].Name = "Notas (1, 2, 3, 4)";
            dataGridViewEstudiantes.Columns[5].Name = "Nota Promedio";


            // Agrego los datos de los estudiantes al DataGridView
            foreach (var estudiante in estudiantesMostrados)
            {
                dataGridViewEstudiantes.Rows.Add(estudiante.Carnet, estudiante.Nombre, estudiante.FechaNacimiento, estudiante.Correo, estudiante.Responsables);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
