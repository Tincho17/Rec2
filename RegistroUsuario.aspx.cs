using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rec2
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //SCRIPT PARA BD
        //    CREATE TABLE Usuarios(
        //id INT PRIMARY KEY IDENTITY(1,1),
        //nombre VARCHAR(50),
        //apellido VARCHAR(50),
        //direccion VARCHAR(100),
        //mail VARCHAR(100)
        //);

       protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string email = txtEmail.Text.Trim();
            string confirmarEmail = txtConfirmarEmail.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(confirmarEmail))
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, "^[a-zA-Z]+$") || !System.Text.RegularExpressions.Regex.IsMatch(apellido, "^[a-zA-Z]+$"))
            {
                lblMensaje.Text = "Los campos Nombre y Apellido solo pueden contener letras.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email,
                @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                lblMensaje.Text = "El formato del Email no es válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (email != confirmarEmail)
            {
                lblMensaje.Text = "Los campos Email y Confirmar Email deben coincidir.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }


            string s = System.Configuration.ConfigurationManager.ConnectionStrings["administracion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(s))
            {
                con.Open();
                string query = "INSERT INTO Usuarios (nombre, apellido, direccion, mail) VALUES (@nombre, @apellido, @direccion, @mail)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@mail", email);

                    cmd.ExecuteNonQuery();
                }
            }

            lblMensaje.Text = "Usuario registrado correctamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;

            this.Session["nombreCompleto"] = txtNombre.Text +" " + txtApellido.Text;
            Thread.Sleep(3000);
            this.Response.Redirect("CargaArchivos.aspx");

        }

    }
}