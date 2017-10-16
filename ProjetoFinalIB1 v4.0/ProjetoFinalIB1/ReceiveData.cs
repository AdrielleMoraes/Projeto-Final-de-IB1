using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace ProjetoFinalIB1
{
    class ReceiveData
    {
        SerialPort port;
        public bool isOpen = false;
        //Incoming data
        private const byte ST = 0x24; //start tranmition byte
        private const byte quit = 0x04; //quit transmition byte
        private const byte ET = 0x0A; //end transmition byte
        private const byte TR = 0x54; //trigger identifier
        private const byte EEG = 0x45; //emg identifier
        private byte[] buffer; //buffer to store samples

        private int NE = 1; //number of samples to receive for emg    


        //circular buffer to hold data
        private const int bufferSize = 10000; //buffer size
        private CircularBuffer<double> circularBufferEEG = new CircularBuffer<double>(bufferSize); //eeg circular buffer
        private CircularBuffer<double> circularBufferTR = new CircularBuffer<double>(bufferSize); //trigger circular buffer

        public ReceiveData(string portName, int baudRate)
        {
            port = new SerialPort();
            port.PortName = portName;
            port.BaudRate = baudRate;
        }


        //devolve a quantidade de amostras presentes no buffer circular
        public int samplesToReadEEG {
        get { return circularBufferEEG.SamplesToRead; }
        }
        public int samplesToReadTR
        {
            get { return circularBufferTR.SamplesToRead; }
        }

        /// <summary>
        /// Executa um comando na porta serial
        /// </summary>
        /// <param name="comando">OPEN - CLOSE - START - STOP</param>
        public void run(string comando)
        {
            switch (comando)
            {
                case "OPEN"://open serial port
                    if (!port.IsOpen)
                    {
                        port.Open();
                        port.DiscardOutBuffer();
                        port.DiscardInBuffer();
                        isOpen = true;
                    }
                    break;
                case "CLOSE": //cole serial port
                    if (port.IsOpen)
                    {
                        isOpen = false;
                        port.Close();
                    }
                    break;
                case "START": //start receiving data
                    if (port.IsOpen)
                    {
                        port.WriteLine("r");
                    }
                    break;
                case "STOP": //stop receiving data
                    if (port.IsOpen)
                    {
                        port.WriteLine("p");
                    }
                    break;
                default:
                    Console.WriteLine("Comando errado");
                    return;
            }
        }

        public void SetupAD()
        {
            port.WriteLine("s");
        }
        public void GainControl(int G)
        {
            switch (G)
            {
                case 0:
                    port.WriteLine("a");
                    break;
                case 1:
                    port.WriteLine("b");
                    break;
                case 2:
                    port.WriteLine("c");
                    break;
                case 4:
                    port.WriteLine("d");
                    break;
                case 8:
                    port.WriteLine("e");
                    break;
                case 16:
                    port.WriteLine("f");
                    break;
                case 32:
                    port.WriteLine("g");
                    break;
                case 64:
                    port.WriteLine("h");
                    break;
            }
        }

        /// <summary>
        /// Waits byte to arrive
        /// </summary>
        /// <param name="num">number of bytes to wait for</param>
        /// <returns>received byte</returns>
        private byte[] WaitIncomingByte(int num)
        {
            //check how many bytes are coming
            int byteAvailable=0;

            //wait until you get num bytes
            while (byteAvailable < num && port.IsOpen)
            {
                byteAvailable = port.BytesToRead;
            }

            //byte to receive data according to num
            byte[] buff = new byte[num];
            //read bytes
            if (port.IsOpen)
                port.Read(buff, 0, num);

            return buff;
        }

        /// <summary>
        /// receive data from serial port
        /// </summary>
        public void receiveData()
        {
            if (port.IsOpen)
            {
                //waiting for the ST byte
                buffer = WaitIncomingByte(1);

                if (ST == buffer[0])
                {
                    buffer = WaitIncomingByte(1); //this bytes represent the kind of samples we are going to receive

                    if (buffer[0] == EEG)
                    { ReceiveEEG(); } //is a emg data
                    else if (buffer[0] == TR)
                    {
                        ReceiveTR();
                    }
                }
            }         
        }

        /// <summary>
        /// Handle emg data
        /// </summary>
        private void ReceiveEEG()
        {
            double[] data = new double[NE];
            buffer = WaitIncomingByte(NE * 2); //this bytes represent the samples we are going to receive

            //join lsb and msb
            data[0] = (buffer[1] << 8 | buffer[0]); //storing data

            //waiting for the ET byte
            buffer = WaitIncomingByte(1);
            if (buffer[0] == ET)
            {
                //store data
                circularBufferEEG.Enqueue(data[0]);
            }
            //if not ignore data
        }

        /// <summary>
        /// Handle TR data
        /// </summary>
        private void ReceiveTR()
        {
            double[] data = new double[NE];
            buffer = WaitIncomingByte(NE * 2); //this bytes represent the samples we are going to receive

            //join lsb and msb
            data[0] = buffer[1] << 8 | buffer[0]; //storing data

            //waiting for the ET byte
            buffer = WaitIncomingByte(1);
            if (buffer[0] == ET)
            {
                //store data
                circularBufferTR.Enqueue(data[0]);
            }
            //if not ignore data
        }


        /// <summary>
        /// Get data from eeg circular buffer
        /// </summary>
        /// <returns></returns>
        public double HandleEEG()
        {
          return circularBufferEEG.Dequeue();         
        }

        /// <summary>
        /// Get data from tr circular buffer
        /// </summary>
        /// <returns></returns>
        public double HandleTR()
        {
            return circularBufferTR.Dequeue();
        }

    }
}
