using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORMESTUDIANTES
{

    public partial class Form1 : Form
    {
        private List<Estudiante> listaEstudiantes = new List<Estudiante>();
        public Form1()
        {
            InitializeComponent();
            BtnIngresarnota.Click += BtnIngresarnota_Click;
        }
    

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que el campo Carnet no esté vacío y tenga el formato correcto (2 letras seguidas de 6 números)
            if (string.IsNullOrEmpty(txtcarnet.Text) || !Regex.IsMatch(txtcarnet.Text, @"^[A-Za-z]{2}\d{6}$"))
            {
                MessageBox.Show("Por favor ingrese un carnet válido (dos letras seguidas de ocho números).", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // compruebo que el campo Nombres no esté vacío
            if (string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre del estudiante.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Valido que el campo Fecha de Nacimiento no esté vacío y tenga el formato correcto
            if (string.IsNullOrEmpty(dtpFechaNacimiento.Text) || !DateTime.TryParse(dtpFechaNacimiento.Text, out _))
            {
                MessageBox.Show("Por favor ingrese una fecha de nacimiento válida (formato: DD/MM/AAAA).", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Valido que el campo Correo electrónico no esté vacío y tenga el formato correcto
            if (string.IsNullOrEmpty(txtcorreo.Text) || !IsValidEmail(txtcorreo.Text))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // pruebo que el campo Responsables no esté vacío
            if (string.IsNullOrEmpty(txtresponsables.Text))
            {
                MessageBox.Show("Por favor ingrese al menos un responsable.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listaEstudiantes.Add(new Estudiante(txtcarnet.Text, txtnombre.Text, dtpFechaNacimiento.Value, txtcorreo.Text, txtresponsables.Text));
            MessageBox.Show("Datos del estudiante guardados correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Función para comprobar el formato de correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnIngresarnota_Click(object sender, EventArgs e)
        {
            FormNotas formNotas = new FormNotas(listaEstudiantes);
            // Muestra el formulario de ingreso de notas
            formNotas.ShowDialog();
        }
    }
}
