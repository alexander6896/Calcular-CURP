using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calcular_CURP
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void btn0a1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btn1a0_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btn1a2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btn2a1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        //Vista final de la Curp
        protected void btn2a3_Click(object sender, EventArgs e)
        {
            string nombreAplellidos = txtNombre.Text + " " + txtPrimerApellido.Text + " " + txtSegundoApellido.Text;

            lblCURP.Text = nombreCompleto(nombreAplellidos);

            MultiView1.ActiveViewIndex = 3;
        }

        protected void btn3a2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }
        public string nombreCompleto(string NombreCompleto)
        {
            return NombreCompleto;
        }
    }
}