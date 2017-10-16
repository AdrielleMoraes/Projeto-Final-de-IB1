using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjetoFinalIB1
{
    public partial class AnaliseDados : Form
    {
        List<double> eegData = new List<double>();//dados da coleta
        List<int> triggerData = new List<int>();//dados do trigger
        string arquivo;
        string mensagem;
        private trataDado obj;
        private int freqAm ;
        List<int> index = new List<int>();
        List<int> index2 = new List<int>();
        public AnaliseDados(int fa)
        {

            InitializeComponent();
            freqAm = fa;
            obj = new trataDado();
        }

        private void carregarArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LerArquivo();
        }
        private void LerArquivo()
        {
            List<string> mensagemLinha = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione um arquivo de coleta";
            openFileDialog.InitialDirectory = @"c:\Program Files"; //Se ja quiser em abrir em um diretorio especifico
            openFileDialog.Filter = "txt (*.txt*)|*.*|txt (*.txt*)|*.txt*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                arquivo = openFileDialog.FileName;

            if (String.IsNullOrEmpty(arquivo))
            {
                MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
            }
            else
            {
                toolStripStatusLabel1.Text = arquivo;
                using (StreamReader texto = new StreamReader(arquivo))
                {
                    //ignora as duas primeiras linhas 
                    texto.ReadLine();//data da coleta
                    texto.ReadLine();// frequência de amostragem
                    
                    while ((mensagem = texto.ReadLine()) != null)
                    {
                        var dados = mensagem.Split('\t');
                        if (dados.Length != 2)
                            break;
                        eegData.Add(Convert.ToDouble(dados[0]));
                        triggerData.Add(Convert.ToInt16(dados[1]));
                    }
                    //mensagemLinha.RemoveAt(mensagemLinha.Count - 1);
                    int result = 0;
                    int resultadoAnterior = triggerData[0];
                   
                    for (int i = 0; i < triggerData.Count; i++)
                    {
                        result = triggerData[i];
                        if (result >= 0 && result < 100)
                        {
                            result = 0;
                        }

                        if (result > 100 && result < 1000)
                        {
                            result = 1;
                        }
                        if (resultadoAnterior != result && result == 0)
                        {
                            resultadoAnterior = result;
                            index.Add(i);
                        }

                        if (resultadoAnterior != result && result == 1)
                        {
                            resultadoAnterior = result;
                            index2.Add(i);
                        }
                    }
                    for (int i = 0; i < index.Count; i++)
                    {
                        cbIntervalos.Items.Add(index[i].ToString() + "-" + index2[i + 1].ToString());
                    }


                }
            }
        }

        private void btSubmeter_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            string intervalo = cbIntervalos.Items[cbIntervalos.SelectedIndex].ToString();
            string[] I = intervalo.Split('-');
            int I1 = Convert.ToInt32(I[0]);
            int I2 = Convert.ToInt32(I[1]);
            double[] sinal = new double[I2 -I1 +1];

            eegData.CopyTo(I1, sinal, 0, I2-I1);           

            double[,] FFT = obj.doFFT(sinal, freqAm);
            for (int ii = 0; ii < FFT.Length/2; ii++)
            {
               
               chart1.Series[0].Points.AddXY(FFT[ii,1],FFT[ii,0]);
            }
        }
    }
}
