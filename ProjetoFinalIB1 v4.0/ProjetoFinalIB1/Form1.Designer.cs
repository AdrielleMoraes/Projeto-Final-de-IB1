namespace ProjetoFinalIB1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portaSerialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPortNames = new System.Windows.Forms.ToolStripComboBox();
            this.conectarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ganhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coletaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btStartAquis = new System.Windows.Forms.ToolStripMenuItem();
            this.btStopAquis = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarDiretórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirJogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stConectar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.st_aquis = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLED = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerPortas = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.analiseDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem,
            this.coletaToolStripMenuItem,
            this.mudarDiretórioToolStripMenuItem,
            this.abrirJogoToolStripMenuItem,
            this.analiseDeDadosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conectarToolStripMenuItem
            // 
            this.conectarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portaSerialToolStripMenuItem,
            this.conectarToolStripMenuItem1,
            this.ganhoToolStripMenuItem,
            this.configurarADToolStripMenuItem});
            this.conectarToolStripMenuItem.Name = "conectarToolStripMenuItem";
            this.conectarToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.conectarToolStripMenuItem.Text = "MicroControlador";
            // 
            // portaSerialToolStripMenuItem
            // 
            this.portaSerialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbPortNames});
            this.portaSerialToolStripMenuItem.Name = "portaSerialToolStripMenuItem";
            this.portaSerialToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.portaSerialToolStripMenuItem.Text = "Porta Serial";
            // 
            // cbPortNames
            // 
            this.cbPortNames.Name = "cbPortNames";
            this.cbPortNames.Size = new System.Drawing.Size(121, 23);
            // 
            // conectarToolStripMenuItem1
            // 
            this.conectarToolStripMenuItem1.Name = "conectarToolStripMenuItem1";
            this.conectarToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.conectarToolStripMenuItem1.Text = "Conectar";
            this.conectarToolStripMenuItem1.Click += new System.EventHandler(this.conectarToolStripMenuItem1_Click);
            // 
            // ganhoToolStripMenuItem
            // 
            this.ganhoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.ganhoToolStripMenuItem.Name = "ganhoToolStripMenuItem";
            this.ganhoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ganhoToolStripMenuItem.Text = "Ganho";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem2.Text = "0";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem3.Text = "1353";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem4.Text = "2706";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem5.Text = "5412";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem6.Text = "10824";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem7.Text = "21648";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem8.Text = "43296";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem9.Text = "86592";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // configurarADToolStripMenuItem
            // 
            this.configurarADToolStripMenuItem.Name = "configurarADToolStripMenuItem";
            this.configurarADToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configurarADToolStripMenuItem.Text = "Configurar AD";
            this.configurarADToolStripMenuItem.Click += new System.EventHandler(this.configurarADToolStripMenuItem_Click);
            // 
            // coletaToolStripMenuItem
            // 
            this.coletaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btStartAquis,
            this.btStopAquis});
            this.coletaToolStripMenuItem.Name = "coletaToolStripMenuItem";
            this.coletaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.coletaToolStripMenuItem.Text = "Coleta";
            // 
            // btStartAquis
            // 
            this.btStartAquis.Enabled = false;
            this.btStartAquis.Name = "btStartAquis";
            this.btStartAquis.Size = new System.Drawing.Size(192, 22);
            this.btStartAquis.Text = "Iniciar Aquisição";
            this.btStartAquis.Click += new System.EventHandler(this.btStartAquis_Click);
            // 
            // btStopAquis
            // 
            this.btStopAquis.Enabled = false;
            this.btStopAquis.Name = "btStopAquis";
            this.btStopAquis.Size = new System.Drawing.Size(192, 22);
            this.btStopAquis.Text = "Interromper Aquisição";
            this.btStopAquis.Click += new System.EventHandler(this.btStopAquis_Click);
            // 
            // mudarDiretórioToolStripMenuItem
            // 
            this.mudarDiretórioToolStripMenuItem.Name = "mudarDiretórioToolStripMenuItem";
            this.mudarDiretórioToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.mudarDiretórioToolStripMenuItem.Text = "Mudar diretório";
            this.mudarDiretórioToolStripMenuItem.Click += new System.EventHandler(this.mudarDiretórioToolStripMenuItem_Click);
            // 
            // abrirJogoToolStripMenuItem
            // 
            this.abrirJogoToolStripMenuItem.Name = "abrirJogoToolStripMenuItem";
            this.abrirJogoToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.abrirJogoToolStripMenuItem.Text = "Abrir Jogo";
            this.abrirJogoToolStripMenuItem.Click += new System.EventHandler(this.abrirJogoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stConectar,
            this.toolStripStatusLabel2,
            this.st_aquis,
            this.toolStripStatusLabel1,
            this.lbLED});
            this.statusStrip1.Location = new System.Drawing.Point(0, 571);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1016, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stConectar
            // 
            this.stConectar.Image = global::ProjetoFinalIB1.Properties.Resources.disconnected;
            this.stConectar.Name = "stConectar";
            this.stConectar.Size = new System.Drawing.Size(140, 20);
            this.stConectar.Text = "Status: Desconectado";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // st_aquis
            // 
            this.st_aquis.Image = global::ProjetoFinalIB1.Properties.Resources.disconnected;
            this.st_aquis.Name = "st_aquis";
            this.st_aquis.Size = new System.Drawing.Size(105, 20);
            this.st_aquis.Text = "Não coletando";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 20);
            this.toolStripStatusLabel1.Text = "Frequência: ";
            // 
            // lbLED
            // 
            this.lbLED.Name = "lbLED";
            this.lbLED.Size = new System.Drawing.Size(13, 20);
            this.lbLED.Text = "0";
            // 
            // timerPortas
            // 
            this.timerPortas.Enabled = true;
            this.timerPortas.Interval = 1000;
            this.timerPortas.Tick += new System.EventHandler(this.timerPortas_Tick);
            // 
            // chart1
            // 
            chartArea3.AxisX.Maximum = 5D;
            chartArea3.AxisX.Minimum = 0D;
            stripLine2.BorderColor = System.Drawing.Color.Silver;
            stripLine2.Interval = 0.5D;
            chartArea3.AxisX.StripLines.Add(stripLine2);
            chartArea3.Name = "ChartArea1";
            chartArea4.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 24);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Color = System.Drawing.Color.Navy;
            series4.Legend = "Legend1";
            series4.Name = "EEG";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Color = System.Drawing.Color.Chartreuse;
            series5.Legend = "Legend1";
            series5.Name = "Trigger";
            series6.ChartArea = "ChartArea2";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Legend = "Legend1";
            series6.Name = "Sinal Filtrado";
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1016, 547);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // analiseDeDadosToolStripMenuItem
            // 
            this.analiseDeDadosToolStripMenuItem.Name = "analiseDeDadosToolStripMenuItem";
            this.analiseDeDadosToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.analiseDeDadosToolStripMenuItem.Text = "Analise de Dados";
            this.analiseDeDadosToolStripMenuItem.Click += new System.EventHandler(this.analiseDeDadosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 596);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "EEG Data";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portaSerialToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbPortNames;
        private System.Windows.Forms.ToolStripMenuItem mudarDiretórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirJogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem coletaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btStartAquis;
        private System.Windows.Forms.ToolStripMenuItem btStopAquis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stConectar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel st_aquis;
        private System.Windows.Forms.Timer timerPortas;
        private System.Windows.Forms.ToolStripMenuItem ganhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem configurarADToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbLED;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem analiseDeDadosToolStripMenuItem;
    }
}

