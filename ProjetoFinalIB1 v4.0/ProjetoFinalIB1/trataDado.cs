using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using Filtro;
using FFTMatlab2;
using processamentoData2;
using processamentoData4;
using System.Threading.Tasks;

namespace ProjetoFinalIB1
{
    class trataDado
    {
        public trataDado()
        { }
        public double[] passaBaixa(double[] sinal, int polos, int fc, int fs)
        {

            double[] res = new double[sinal.Length];

            MWNumericArray aux_res2 = new MWNumericArray(new double[sinal.Length]);
            MWNumericArray xdt = new MWNumericArray(new double[sinal.Length]);
            Array aux_res3 = null;
            Fltros obj = new Fltros();
            xdt = sinal;
            MWArray aux_res = obj.LowPassFilt(xdt, polos, fc, fs);

            aux_res2 = (MWNumericArray)aux_res;
            aux_res3 = aux_res2.ToVector(MWArrayComponent.Real);
            res = (double[])aux_res3;
            return res;
        }
        public double[] passaAlta(double[] sinal, int polos, int fc, int fs)
        {

            double[] res = new double[sinal.Length];

            MWNumericArray aux_res2 = new MWNumericArray(new double[sinal.Length]);
            MWNumericArray xdt = new MWNumericArray(new double[sinal.Length]);
            Array aux_res3 = null;
            Fltros obj = new Fltros();
            xdt = sinal;
            MWArray aux_res = obj.HighPassFilt(xdt, polos, fc, fs);

            aux_res2 = (MWNumericArray)aux_res;
            aux_res3 = aux_res2.ToVector(MWArrayComponent.Real);
            res = (double[])aux_res3;
            return res;
        }
        public int correlacao(double[] sinal, double freqAm, double tamanhoJanela)
        {
            int LED = 0;
            string aux_LED2;
            MWNumericArray xdt = new MWNumericArray(new double[sinal.Length]);
            xdt = sinal;
            xcorr obj = new xcorr();
            MWArray aux_LED = obj.correlacao(xdt, freqAm, tamanhoJanela);
            aux_LED2 = aux_LED.ToString();
            LED = Convert.ToInt32(aux_LED2);
            return LED;
        }
        public int findFrequencia(double[] sinal, double freqAm)
        {
            int LED = 0;
            string aux_LED2;
            MWNumericArray xdt = new MWNumericArray(new double[sinal.Length]);
            xdt = sinal;
            processamento obj = new processamento();
            MWArray aux_LED = obj.FindFreq(xdt, freqAm);
            aux_LED2 = aux_LED.ToString();
            LED = Convert.ToInt32(aux_LED2);
            return LED;
        }
        public double[,] doFFT(double[] sinal, double freqAm)
        {
            double[] resY = new double[sinal.Length];
            double[] resX = new double[sinal.Length];
            double[,] res = new double[sinal.Length,2];

            MWNumericArray aux_res2 = new MWNumericArray(new double[sinal.Length]);
            MWNumericArray aux_res2X = new MWNumericArray(new double[sinal.Length]);
            MWNumericArray xdt = new MWNumericArray(new double[sinal.Length]);
            Array aux_res3 = null;
            Array aux_res3X = null;
            fftMatlab2 obj = new fftMatlab2();
            xdt = sinal;

            MWArray aux_res = obj.IB_fft(xdt, freqAm);
            MWArray aux_resX = obj.IB_fftx(xdt, freqAm);

            aux_res2X = (MWNumericArray)aux_resX;
            aux_res2 = (MWNumericArray)aux_res;

            aux_res3X = aux_res2X.ToVector(MWArrayComponent.Real);
            aux_res3 = aux_res2.ToVector(MWArrayComponent.Real);


            resY = (double[])aux_res3;
            resX = (double[])aux_res3X;
            for (int i = 0; i < resX.Length; i++)
            {
                res[i,0] = resY[i];//linha 0 valores de Y
                res[i,1] = resX[i];//linha 1 valores de X
            }

            return res;
        }
    }
}
