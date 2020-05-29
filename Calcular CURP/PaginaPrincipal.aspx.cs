﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Libreria para usar archivo XML
using System.Data;
using System.EnterpriseServices.Internal;

namespace Calcular_CURP
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtenemos el año del sistema
                int year = (DateTime.Now.Year);

                //Llenar el DropDowList del Año actual hasta el año 1990
                for (int i = year; i >= 1900; i--)
                {
                    ddlAño.Items.Add(i.ToString());
                }

                //Llenar los meses con archivo XML
                DataSet DS = new DataSet();
                DS.ReadXml(Server.MapPath("Meses.xml"));

                ddlMes.DataSource = DS;
                ddlMes.DataValueField = "MesID";
                ddlMes.DataTextField = "MesNombre";
                //Agregar contenido al DropDownList
                ddlMes.DataBind();

                //Lenar DropDownList de los Días
                for (int i = 1; i < 32; i++)
                {
                    if (i < 10)
                    {
                        ddlDia.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        ddlDia.Items.Add(i.ToString());
                    }
                }

                //Llenar DropDownList de ddlEstados con archivo XML
                DataSet DS1 = new DataSet();
                DS1.ReadXml(Server.MapPath("Estados.xml"));
                ddlEstados.DataSource = DS1;
                ddlEstados.DataValueField = "EstadoID";
                ddlEstados.DataTextField = "EstadoNomrbe";
                ddlEstados.DataBind();

                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void btn0a1_Click(object sender, EventArgs e)
        {
            //No mueve al View1 de Lugar de Nacimiento
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btn1a0_Click(object sender, EventArgs e)
        {
            //Regresa al View Principal del Nombre y Fecha de Nacimiento
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btn1a2_Click(object sender, EventArgs e)
        {
            //View donde obtenemos el CURP completo

            //Obtener primeras letras del nombre completo
            //string nombreAplellidos = txtNombre.Text + " " + txtPrimerApellido.Text + " " + txtSegundoApellido.Text;
            string nombre = txtNombre.Text;
            string primerApellido = txtPrimerApellido.Text;
            string segundoApellido = txtSegundoApellido.Text;

            //Obtener digitos de la fecha de nacimiento
            string year = ddlAño.Text;
            year = year.Substring(1, 3);
            year = year.Substring(1, 2);
            string mes = ddlMes.Text;
            string dia = ddlDia.Text;

            //Obtener Sexo
            string sexo = ddlSexo.SelectedItem.Text;
            sexo = sexo.Substring(0, 1);

            //Obtener Estado
            string estado = ddlEstados.SelectedValue;

            //Imprmiendo CURP en Label
            lblCURP.Text = separarInicialesNombreCompleto(nombre, primerApellido, segundoApellido)
                + year + mes + dia
                + sexo.ToUpper()
                + estado
                + separarSApellidoLetra(primerApellido)
                + separarPApellidoLetra(segundoApellido)
                + separarNombreEnLetras(nombre);
            //lblCURP.Text = nombreCompleto(nombreAplellidos);

            MultiView1.ActiveViewIndex = 2;
        }

        protected void btn2a1_Click(object sender, EventArgs e)
        {
            //No regresa al View del lugar de Nacimiento
            //separarInicialesNombreCompleto("", "", "");
            MultiView1.ActiveViewIndex = 1;
        }

        //public string nombreCompleto(string NombreCompleto)
        //{
        //    return NombreCompleto;
        //}
        public string separarInicialesNombreCompleto(string nombre, string pApe, string sApe)
        {
            //Obtener las primeras letras del Nombre y Apellidos
            string primerLetraNombre = nombre.Substring(0, 1);
            string primerasLetraPApellido = pApe.Substring(0, 2);
            string primerLetraSApellido = sApe.Substring(0, 1);

            return primerasLetraPApellido.ToUpper() + primerLetraSApellido.ToUpper() + primerLetraNombre.ToUpper();
        }
        public string separarNombreEnLetras(string nombre)
        {
            return "";
        }
        public string separarPApellidoLetra(string pApellido)
        {
            return "";
        }
        public string separarSApellidoLetra(string sApellido)
        {
            return "";
        }
    }
}