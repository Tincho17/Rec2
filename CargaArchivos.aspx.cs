using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rec2
{
    public partial class CargaArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrilla();

                string nombreCompleto = this.Session["nombreCompleto"] as string;

                if (!string.IsNullOrEmpty(nombreCompleto))
                {
                    string path = $"{Server.MapPath(".")}/{nombreCompleto}";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                Label3.Text = " - Valor de Cookie";
                Label2.Text = this.Session["nombreCompleto"].ToString();
            }
        }

        public void cargarGrilla()
        {
            string nombreCompleto = this.Session["nombreCompleto"] as string;
            string path = $"{Server.MapPath(".")}/{nombreCompleto}";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                List<Archivo> fileList = new List<Archivo>();
                foreach (string file in files)
                {
                    var fileNew = new Archivo(Path.GetFileName(file), file);
                    fileList.Add(fileNew);
                }
                GridView1.DataSource = fileList;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombreCompleto = this.Session["nombreCompleto"] as string;
            string path = $"{Server.MapPath(".")}/{nombreCompleto}";
            string result = string.Empty;

            if (FileUpload1.HasFiles)
            {
                foreach (HttpPostedFile archivo in FileUpload1.PostedFiles)
                {
                    if (archivo.ContentLength > 1000)
                    {
                        result += $"El archivo {archivo.FileName} supera los 1000 bytes - ";
                    }
                    else
                    {
                        string filePath = Path.Combine(path, archivo.FileName);

                        if (File.Exists(filePath))
                        {
                            result += $"El archivo {archivo.FileName} ya existe - ";
                        }
                        else
                        {
                            archivo.SaveAs(filePath);
                        }
                    }
                }
            }
            else
            {
                result = "No se seleccionaron archivos para subir.";
            }
            Label1.Text = result;
            cargarGrilla();
        }


        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string filePath = registro.Cells[2].Text;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }
}