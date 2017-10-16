using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Filtro;
using System.Globalization;

namespace ProjetoFinalIB1
{
    public partial class Form1 : Form
    {
        ReceiveData dataHander; //control for receive data
        const int baudRate = 115200; //serial port baud rate

        StreamWriter file; //file to save data
        static string nome = @"\EEG_" + DateTime.Now.ToString("ddMMyyyy_HH-mm");

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + nome; //save files to desktop

        //threads to handle data
        Thread thrAquis;
        Thread thrHandle;

        bool working = false; //flag to control thread
        static double t =0;
        static int fa = 1000;//1176;
        double G = 1;//353;
        double convertNum = Math.Pow(2, 16) / 5000.0;

        public bool triggerOn = false;//flag para saber quando o trigger disparou

        //vetor para guardar os dados para análise
        double[] vetorParaTratamento;
        double[] copiaVetorParaTratamento;
        Mutex m;
        public int contAmostrasVetorParaTratamento = 0;
        //variavel para startar processo com Matlab
        Fltros MatlabAwake;

        //variavel para classe de tratamento de dados
        trataDado tratar;
        double[] sinalFiltrado;
        public int LED;
        public int TempoDeAnalise = 1;

        public Form1()
        {
            InitializeComponent();
            ComPorts();
            vetorParaTratamento = new double[TempoDeAnalise * fa];
            copiaVetorParaTratamento = new double[TempoDeAnalise * fa];
            m = new Mutex();
            MatlabAwake = new Fltros();
            tratar = new trataDado();
            sinalFiltrado = new double[TempoDeAnalise * fa];
        }

        delegate void VarDoublePto(double[] val);
        public void atribuirPto_WithDelegate(double[] val)
        {
            if(t>chart1.ChartAreas[0].AxisX.Minimum)
            {
                chart1.ChartAreas[0].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Maximum;
                chart1.ChartAreas[0].AxisX.Maximum += 10;
            }
            chart1.Series[0].Points.AddXY(t, val[0]);
            chart1.Series[1].Points.AddXY(t, val[1]);
            t += 1.0 / fa;
        }
        VarDoublePto add_Pto;

        private void timerPortas_Tick(object sender, EventArgs e)
        {
            ComPorts(); //refesh serial port names
        }

        //verifica quais as portas seriais disponíveis
        public void ComPorts()
        {
            int i = 0;
            bool isDifferent = false;

            //if the length is equal
            if (cbPortNames.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    //but the strings are different
                    if (!cbPortNames.Items[i++].Equals(s))
                    {
                        isDifferent = true;
                    }

                }
            }
            else
            {
                isDifferent = true;
            }

            //if nothing changed, nothing to do
            if (!isDifferent)
            {
                return;
            }

            //clear cb items and add new values
            cbPortNames.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cbPortNames.Items.Add(s);
                //change selected index
                cbPortNames.SelectedIndex = 0;
            }

        }

        private void conectarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string portName = cbPortNames.Items[cbPortNames.SelectedIndex].ToString(); //get value from combo box    
                Connect(portName); //connect to serial port                         
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar\nSelecione uma porta válida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }


        void Connect(string portName)
        {
            if (conectarToolStripMenuItem1.Text == "Conectar")
            {
                
                dataHander = new ReceiveData(portName, baudRate); //creates a new data handler to receive data
                dataHander.run("OPEN"); //open serial port

                conectarToolStripMenuItem1.Text = "Desconectar"; //change text
                stConectar.Text = "Conectado"; //change text
                stConectar.Image = Properties.Resources.connected; //change image
                btStartAquis.Enabled = true; //enable aquisition button
            }
            else
            {
                dataHander.run("CLOSE"); //close serial port

                conectarToolStripMenuItem1.Text = "Conectar"; //change text
                stConectar.Text = "Desconectado"; //change text
                stConectar.Image = Properties.Resources.disconnected; //change image
                btStartAquis.Enabled = false; //disable aquisition button
            }
            
        }

        private void mudarDiretórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //creates a new save file dialog to store data
            sfd.Filter = "Text File|.txt"; //defines the filter, in this case text files
            sfd.FileName = "EEG_" + DateTime.Now.ToString("ddMMyyyy_HH-mm"); //default name

            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = sfd.FileName;
                path = path.Replace(@"\", "/");
            }
        }

        private void btStartAquis_Click(object sender, EventArgs e)
        {
            //set buttons state
            btStopAquis.Enabled = true;
            btStartAquis.Enabled = false;
            st_aquis.Text = "Coletando Dados";
            st_aquis.Image = Properties.Resources.connected;

            file = new StreamWriter(path, false); //create a new txt           
            //add time to the file
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            file.WriteLine(timestamp);
            file.WriteLine("SampFreq =" + fa.ToString());

            //threads to manage data
            thrAquis = new Thread(GetData);
            thrHandle = new Thread(HandleSamples);
            thrAquis.Priority = ThreadPriority.BelowNormal;
            thrHandle.Priority = ThreadPriority.BelowNormal;
            //run aquisition 
            dataHander.run("START");

            //start threads
            working = true;
            thrAquis.Start();
            thrHandle.Start();
        }

        void GetData()
        {
            while (working)
            {
                dataHander.receiveData();
            }
            Console.WriteLine("Aquisição encerrada!");

        }
        
        void HandleSamples()
        {
            int amostraTR = 0;
            float x = 0;
            while (working)
            {
                int samplesAvailablesEEG = dataHander.samplesToReadEEG;
                int samplesAvailablesTR = dataHander.samplesToReadTR;

                int samplesAvailables = 0;

               if (samplesAvailablesEEG > samplesAvailablesTR)
               {
                    samplesAvailables = samplesAvailablesTR;
                }
                else
                {
                    samplesAvailables = samplesAvailablesEEG;
                }

                if (samplesAvailables > 0)
                {
                    for (int i = 0; i < samplesAvailables; i++)
                    {
                        double sample =dataHander.HandleEEG(); //gets the sample
                        double sampleTR =  dataHander.HandleTR(); //gets the sample
                        chart1.BeginInvoke(new Action(() => chart1.Series[0].Points.AddXY(t, sample/G))); //plot data
                        chart1.BeginInvoke(new Action(() => chart1.Series[1].Points.AddXY(t, sampleTR/10000))); //plot data
                        t += 1.0 / fa;
                        if (sampleTR < 0.1)
                        {
                            vetorParaTratamento[contAmostrasVetorParaTratamento] = sample;
                            contAmostrasVetorParaTratamento++;
                            amostraTR++;
                            if (contAmostrasVetorParaTratamento == vetorParaTratamento.Length)
                            {
                                contAmostrasVetorParaTratamento = 0;

                                copiaVetorParaTratamento = vetorParaTratamento;

                                FazerCoisas(null);

                                Console.WriteLine(LED.ToString());
                                if (LED == 1)
                                {
                                    statusStrip1.Invoke(new Action(() =>
                                    {
                                        lbLED.Text = "7 - cima";
                                        SendKeys.SendWait("{UP}"); 
                                        Application.DoEvents();
                                    }));
                                }
                                else if (LED == 2)
                                {
                                    statusStrip1.Invoke(new Action(() =>
                                    {
                                        lbLED.Text = "9 - baixo";
                                        SendKeys.SendWait("{DOWN}"); 
                                        Application.DoEvents();
                                    }));
                                }
                                else if (LED == 3)
                                {
                                    statusStrip1.Invoke(new Action(() =>
                                    {
                                        lbLED.Text = "11 - direita";
                                        SendKeys.SendWait("{RIGHT}"); 
                                        Application.DoEvents();
                                    }));
                                }
                                else if (LED == 4)
                                {
                                    statusStrip1.Invoke(new Action(() =>
                                    {
                                        lbLED.Text = "13 - esquerda";
                                        SendKeys.SendWait("{LEFT}"); 
                                        Application.DoEvents();
                                    }));
                                }
                            }
                            
                            
                        }

                        file.WriteLine(sample.ToString() + "\t" + sampleTR.ToString()); //save data to a file
                        if (t > chart1.ChartAreas[0].AxisX.Maximum)
                        {
                            chart1.Invoke(new Action(() => chart1.Series[0].Points.Clear()));
                            chart1.Invoke(new Action(() => chart1.Series[1].Points.Clear()));
                            chart1.Invoke(new Action(() => chart1.ChartAreas[0].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Maximum));
                            chart1.Invoke(new Action(() => chart1.ChartAreas[0].AxisX.Maximum += 5));
                        }
                    }
                    
                    
                }
            }

            
            //add time to the file
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            file.WriteLine(timestamp);
            file.Close();//close file
            Console.WriteLine("Thread encerrada!");
        }

        public void FazerCoisas(object temp)
        {

            sinalFiltrado = tratar.passaAlta(copiaVetorParaTratamento, 4, 4, fa);
            sinalFiltrado = tratar.passaBaixa(sinalFiltrado, 4, 20, fa);
            LED = tratar.findFrequencia(sinalFiltrado, fa);

            chart1.BeginInvoke(new Action(() => chart1.Series[2].Points.Clear()));
            chart1.BeginInvoke(new Action(() => chart1.Series[2].Points.DataBindY(sinalFiltrado)));

        }

        private void btStopAquis_Click(object sender, EventArgs e)
        {
            //set buttons state
            btStopAquis.Enabled = false;
            btStartAquis.Enabled = true;
            st_aquis.Text = "Não coletando";
            st_aquis.Image = Properties.Resources.disconnected;

            working = false;
            dataHander.run("STOP"); //stop receiving data
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void configurarADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataHander.SetupAD();
        }


        #region gain control
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            G = 1 * convertNum;
            dataHander.GainControl(0);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            G = 1353 * convertNum;
            dataHander.GainControl(1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            G = 2.706 * convertNum;
            dataHander.GainControl(2);

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            G = 5.412 * convertNum;
            dataHander.GainControl(4);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            G = 10.824 * convertNum;
            dataHander.GainControl(8);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            G = 21.648 * convertNum;
            dataHander.GainControl(16);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            G = 43.296 * convertNum;
            dataHander.GainControl(32);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            G = 86.592 * convertNum;
            dataHander.GainControl(64);
        }
        #endregion

        private void abrirJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Users/ADRIELLE/Desktop/LightGame.exe");//um executável "não windows" 
            //System.Diagnostics.Process.Start(@"C:\Users\Ricardo\Downloads\Será que é virus\LightGame.exe");

        }


        private void analiseDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnaliseDados frm = new AnaliseDados(fa);
            frm.Show();
        }
    }
}
