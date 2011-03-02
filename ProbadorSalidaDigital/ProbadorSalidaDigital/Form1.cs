using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ProbadorSalidaDigital
{
    public partial class Probador : Form
    {
        private MccDaq.MccBoard interfaz;
        const MccDaq.DigitalPortType puerto = MccDaq.DigitalPortType.FirstPortA;
        const MccDaq.DigitalPortDirection direccion = MccDaq.DigitalPortDirection.DigitalOut;
        private int contador;
        

        public Probador()
        {
            InitializeComponent();

            MccDaq.ErrorInfo ULstat = MccDaq.MccService.ErrHandling(MccDaq.ErrorReporting.PrintAll, MccDaq.ErrorHandling.StopFatal);

            interfaz = new MccDaq.MccBoard(0);

            ULstat = interfaz.DConfigPort(puerto, direccion);
        }

        private void btnInterfaz_Click(object sender, EventArgs e)
        {
            MccDaq.ErrorInfo ULstat;
            interfaz = new MccDaq.MccBoard(Convert.ToInt16(txtInterfaz.Text));
            ULstat = interfaz.DConfigPort(puerto, direccion);
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(txtDato.Text) > 255)
            {
                txtDato.Text = "255";
            }
            int valor = int.Parse(txtDato.Text);

            if (chkRep.Checked)
            {
                Reloj.Interval = int.Parse(txtRepTiempo.Text);
                Reloj.Start();

            }
            else
            {
                escribeValor(valor);
            }

           
        }

        private void escribeValor(int valor)
        {
            ushort ValorDato = (ushort)valor;

            MccDaq.ErrorInfo ULStat = interfaz.DOut(puerto, ValorDato);

            if (ULStat.Value == MccDaq.ErrorInfo.ErrorCode.NoErrors)
            {
                lblRespuesta.Text = "Se escribio";
                lblRespuestaDato.Text = ValorDato.ToString("0");
            }
            else
            {
                lblRespuesta.Text = "No se Escribio";
                lblRespuestaDato.Text = "--";
            }
        }

        private void Reloj_Tick(object sender, EventArgs e)
        {
            if (contador <= 100)
            {
                contador++;
                escribeValor(int.Parse(txtDato.Text));

            }
            else
            {
                contador = 0;
                Reloj.Stop();
            }
        }


    }
}
