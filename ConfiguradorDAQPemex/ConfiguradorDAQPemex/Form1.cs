using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace ConfiguradorDAQPemex
{
    public partial class DAQCalibrador : Form
    {
        AccesoUsuarios logon;
        Regresion_Lineal regLin;

        public DAQCalibrador()
        {
            InitializeComponent();

           
            hideTabs();
            logon = new AccesoUsuarios();
            regLin = new Regresion_Lineal();
        }

        private void hideTabs()
        {
            foreach (TabPage tp in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tp);
            }
            tabControl1.TabPages.Add(tabLogon);
        }

        private void showUserTabs()
        {
            tabControl1.TabPages.Add(tabCalibracion);
            tabControl1.TabPages.Add(tabDatos);
        }
       
        private void showAdminTabs()
        {
            tabControl1.TabPages.Add(tabAdmin);
        }
       
        private void hideLogon()
        {
            tabControl1.TabPages.Remove(tabLogon);
        }

        private void btnClearPass_Click(object sender, EventArgs e)
        {
            txtBxPassword.Clear();
            txtBxUsuario.Clear();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            logon.nuevoUsuario(txtBxUsuario.Text.ToString(),txtBxPassword.Text.ToString());
            if (logon.validaUsuario())
            {
                switch (logon.nivelAcceso())
                {
                    case 1:
                        accesoUsuario();
                        break;
                    case 2:
                        accesoAdmin();
                        break;
                    default:
                        logon.usuarioIncorrecto();
                        break;
                }

            }
            else
            {

                logon.usuarioIncorrecto();
            }
        }

        private void accesoAdmin()
        {
           showAdminTabs();
           accesoUsuario(); 
        }

        private void accesoUsuario()
        {
            showUserTabs();
            hideLogon();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            logon.creaUsuario(txtCrearUsuario.Text.ToString(), txtCrearContraseña.Text.ToString(), 2);
        }

        private void numBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(tb.Text.ToString()))
            {
                e.Cancel = false;
            }
            else
            {

                try
                {
                    float value = float.Parse(tb.Text.ToString());             
                }
                catch (Exception )
                {
                    e.Cancel = true;                   
                    MessageBox.Show("Ingrese un Numero");
                    tb.Clear();
                }
            }


        }

        private void numBox_Validated(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            double indice = 0;

            graficaCalilbracion.Series["puntosMedidos"].Points.Clear();
            regLin.borrar();
            graficaCalilbracion.Series["regLin"].Points.Clear();

            foreach (TextBox txtBx in panelLblRecib.Controls)
            {
                if (string.IsNullOrWhiteSpace(txtBx.Text.ToString()) == false)
                {
                    graficaCalilbracion.Series["puntosMedidos"].Points.AddXY((double)indice, double.Parse(txtBx.Text.ToString()));
                    regLin.addTermino((float)indice, float.Parse(txtBx.Text.ToString()));
                    
                }
                else
                {
                    int indiceHijo = panelLblRecib.Controls.GetChildIndex(txtBx);
                    graficaCalilbracion.Series["puntosMedidos"].Points.AddXY
                        ((double)indice, double.Parse(PanelLabelsEsp.Controls[indiceHijo].Text.ToString()));
                    regLin.addTermino((float)indice, float.Parse(PanelLabelsEsp.Controls[indiceHijo].Text.ToString()));

                }
                indice += 1.0;
            }

            regLin.calcularRegresionLineal();
            dibujaRegresionLineal();

        }

        private void dibujaRegresionLineal()
        {
            foreach (TextBox txtbx in panelLblRecib.Controls)
            {
               
                graficaCalilbracion.Series["regLin"].Points.AddXY(
                    panelLblRecib.Controls.GetChildIndex(txtbx),
                    regLin.obtieneCoordenada(panelLblRecib.Controls.GetChildIndex(txtbx)));
            }
        }

        private void rdBtn300PSI_CheckedChanged(object sender, EventArgs e)
        {

            lblsPresion(300);
            
            
        }


        private void rdBtn7500PSI_CheckedChanged(object sender, EventArgs e)
        {
            lblsPresion(7500);
        }

        private void lblsPresion(int p)
        {
            float value = 0;
            float aumentar = p / 10;
            foreach (Label lb in PanelLabelsEsp.Controls)
            {
                lb.Text = value.ToString();
                value += aumentar;
            }
        }










    

              
       
    }
}
