using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using System.IO;

// FOR DEBUG

using System.Diagnostics;


namespace DAQPemex
{
    public partial class DAQPemex : Form
    {
        private DAQBoardInterface boardInt;
        private Estado_Valvula estadoV;
        private WebCam webcam;


        private float timeElapsed, timerTick;
        private float maxPoint, stablePoint;
        private int stableCounter;
        private string dirTemporales;
        private string cadenaConexion, cadenaBusqueda, cadenaWriteDB;
        private DataViewManager dsVistaPlantas, dsVistaValvulas;
        private DataSet dsPlantas, dsValvulas;
        private SqlConnection cn, writeCn;
        private SqlDataAdapter daPlantas, daValvulas;
        private float zeroOffset;
        private Regresion_Lineal RegLin;
        private bool valvulaCerrada;
        private Button cmdStartConvert;
        private Button cmdStopConvert;
        private Label lblShowData;
        private Label lblMaximo;
        private float psiMultiplier;

        public DAQPemex()
        {
            InitializeComponent();

            boardInt = new DAQBoardInterface(0, 0);
            estadoV = new Estado_Valvula();

            webcam = new WebCam();
            webcam.InitializeWebCam(ref pictureBox1);

            timeElapsed = 0;
            timerTick = 5;
            maxPoint = 0; stablePoint =0;
            stableCounter = 0;
            zeroOffset = 2;

            RegLin = new Regresion_Lineal();


           cadenaConexion = "Data Source=BARBAROJA\\SQLEXPRESS2005;Initial Catalog=Eq_Criticos;Integrated Security=True";
           cadenaWriteDB = "Data Source=BARBAROJA\\sqlexpress2005;Initial Catalog=Historiador;Integrated Security=True;Pooling=False";
           cn = new SqlConnection(cadenaConexion);
           writeCn = new SqlConnection(cadenaWriteDB);
           dsPlantas = new DataSet("dsPlantas");
           dsValvulas = new DataSet("dsValvulas");
           daPlantas = new SqlDataAdapter("SELECT * FROM C_Plantas", cn);
           daPlantas.TableMappings.Add("Table", "C_Plantas");
           daPlantas.Fill(dsPlantas);

          

           dsVistaPlantas = dsPlantas.DefaultViewManager;
           cmbPlanta.DataSource = dsVistaPlantas;
           cmbPlanta.DisplayMember = "C_Plantas.claplanta";
           cmbPlanta.ValueMember = "C_Plantas.Id_Pla";

           
            
            

            
           
            
        }

        

        private void btnStart_Click(object sender, EventArgs e)
        {
            webcam.Start();
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }



        private void cmdStartConvert_Click(object eventSender, System.EventArgs eventArgs) /* Handles cmdStartConvert.Click */
        {
            if (validateComboBox())
            {




                foreach (Series serieActual in graficaPresion.Series)
                {
                    serieActual.Points.Clear();
                }

                cmdStartConvert.Visible = false;
                cmdStopConvert.Visible = true;
                
                tmrConvert.Interval = (int)timerTick;
                tmrConvert.Enabled = true;
                
                rdBtn300Psi.Enabled = false;
                rdBtn5000Psi.Enabled = false;
                
                cmbPlanta.Enabled = false;
                cmbValvula.Enabled = false;
                
                lblStable.Text = "0.00";
                lblMaximo.Text = "0.00";
                lblShowData.Text = "0.00";
                maxPoint = 0;
                stablePoint = 0;
            }
            else
            {
                MessageBox.Show("Favor de Seleccionar una Valvula");
            }

        }



        private bool validateComboBox()
        {
            if (cmbValvula.SelectedValue != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void cmdStopConvert_Click(object eventSender, System.EventArgs eventArgs) /* Handles cmdStopConvert.Click */
        {
           

            tmrConvert.Enabled = false;
            cmdStartConvert.Visible = true;
            cmdStopConvert.Visible = false;
            rdBtn300Psi.Enabled = true;
            rdBtn5000Psi.Enabled = true;
            cmbPlanta.Enabled = true;
            cmbValvula.Enabled = true;
            RegLin.borrar();

            graficaPresion.Series["Presion_Inicio"].Points.Clear();
            timeElapsed = 0;

            dirTemporales = "C:\\temp\\" + "Historiador_PSV" + ".jpeg";
            graficaPresion.SaveImage(dirTemporales, ChartImageFormat.Jpeg);
            guardarDatos(maxPoint, stablePoint);

        }

        private void guardarDatos(float maxPoint, float stablePoint)
        {   



                string updateSql = "UPDATE Datos " +
                    "SET Presion_Apertura=@Presion_Apertura," +
                    "Presion_Cierre=@Presion_Cierre "+
                    "WHERE No_ID_Valvula=@No_ID_Valvula "+
                    "IF @@ROWCOUNT = 0 "+
                    "INSERT INTO Datos (No_ID_Valvula, Presion_Apertura, Presion_Cierre) "+
                    "VALUES (@No_ID_Valvula, @Presion_Apertura, @Presion_Cierre)";


                SqlCommand UpdateCmd = new SqlCommand(updateSql, writeCn);

                UpdateCmd.Parameters.Add("@Presion_Apertura", SqlDbType.NVarChar, 255, "Presion_Apertura");                
                UpdateCmd.Parameters.Add("@Presion_Cierre", SqlDbType.NVarChar, 255, "Presion_Cierre");
                UpdateCmd.Parameters.Add("@No_ID_Valvula", SqlDbType.NVarChar, 255, "No_ID_Valvula");
                UpdateCmd.Parameters["@Presion_Apertura"].Value = maxPoint.ToString();
                UpdateCmd.Parameters["@Presion_Cierre"].Value = stablePoint.ToString();
                UpdateCmd.Parameters["@No_ID_Valvula"].Value = cmbValvula.SelectedValue.ToString();
                try
                {

                    writeCn.Open();

                    UpdateCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   
                    writeLog(ex.ToString());
                }
                finally
                {
                    writeCn.Close();
                }


  
        }

        private void writeLog(string p)
        {
            TextWriter tw = new StreamWriter("C:\\Historiador\\Temporal\\Log.txt", true);
            tw.WriteLine("Evento: "+p+" Fecha: "+DateTime.Now);
            tw.Close();
        }

  


        private void frmDataDisplay_Load(object eventSender, System.EventArgs eventArgs) /* Handles base.Load */
        {

            MccDaq.ErrorInfo ULStat;

            //  Initiate error handling
            //   activating error handling will trap errors like
            //   bad channel numbers and non-configured conditions.
            //   Parameters:
            //     MccDaq.ErrorReporting.PrintAll :all warnings and errors encountered will be printed
            //     MccDaq.ErrorHandling.StopAll   :if an error is encountered, the program will stop

            ULStat = MccDaq.MccService.ErrHandling(MccDaq.ErrorReporting.DontPrint, MccDaq.ErrorHandling.DontStop);


        }


        private void tmrConvert_Tick(object eventSender, System.EventArgs eventArgs)
        {
            float DataValue;
            int grafica, curva;
            // FOR DEBUGGING
            /*
            Stopwatch sw = new Stopwatch();
           

            
            sw.Start();
            
            lblPntCount.Visible=true;
            lblStpWatch.Visible=true;
            label5.Visible = true;
             * */
            tmrConvert.Stop();


            timeElapsed = timeElapsed + timerTick;
            DataValue = boardInt.boardData();

           // lblData.Text = DataValue.ToString();
            if (DataValue > zeroOffset)
            {
                DataValue -= zeroOffset;
            }
            else
            {
                DataValue = 0;
            }
            if (DataValue < 0)
            {
                DataValue = DataValue * (-1);
            }

            DataValue *= psiMultiplier;
            lblShowData.Text = DataValue.ToString();                //  print the counts

            if (estadoV.defineEstado(DataValue))
            {
                RegLin.borrar();
            }
            grafica = estadoV.graficaActiva();
            curva = estadoV.curvaActiva();

            graficaPresion.Series[estadoV.curvaActiva()].Points.AddXY(timeElapsed, DataValue);
            RegLin.addTermino(timeElapsed, DataValue);
            graficaPresion.Series[estadoV.graficaActiva()].Points.Clear();
            RegLin.calcularRegresionLineal();
            foreach (DataPoint point in graficaPresion.Series[estadoV.curvaActiva()].Points)
            {
                graficaPresion.Series[estadoV.graficaActiva()].Points.AddXY(point.XValue, RegLin.obtieneCoordenada(point.XValue));
            }
           
           //MessageBox.Show(grafica.ToString());
           // MessageBox.Show(curva.ToString());

            tmrConvert.Start();

        }




        private bool validaEstable(float OldDataValue, float DataValue)
        {
            if (OldDataValue == DataValue)
            {
                if (stableCounter > 5)
                {
                    return true;
                }
                stableCounter++;
                return false;

            }
            stableCounter = 0;
            return false;
        }

        private bool validaApertura(float OldDataValue, float DataValue)
        {
            if ((OldDataValue - DataValue) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }








        private void rdBtn5000Psi_CheckedChanged(object sender, EventArgs e)
        {
            
            psiMultiplier = (float)500.00;
            
        }

        private void rdBtn300Psi_CheckedChanged(object sender, EventArgs e)
        {
            
            psiMultiplier = (float)30;
            

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dsValvulas.Clear();

            if (cmbPlanta.SelectedValue.ToString() != "System.Data.DataViewManagerListItemTypeDescriptor")
            {
                cadenaBusqueda = "SELECT * FROM Cat_psv WHERE Planta = '" + cmbPlanta.SelectedValue.ToString() +"'";
                daValvulas = new SqlDataAdapter(cadenaBusqueda, cn);
                daValvulas.TableMappings.Add("Table", "Cat_psv");

                daValvulas.Fill(dsValvulas);

              

                dsVistaValvulas = dsValvulas.DefaultViewManager;
                cmbValvula.DataSource = dsVistaValvulas;
                cmbValvula.DisplayMember = "Cat_psv.No_Id_Tec";
                cmbValvula.ValueMember = "Cat_psv.No_Id_Tec";
  
            }


        }

        private void btnWebCamCnfig_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }





        
    }
}
