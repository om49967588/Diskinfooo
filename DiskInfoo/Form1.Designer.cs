namespace DiskInfoo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mHDSPACEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mISHDSPACE = new DiskInfoo.MISHDSPACE();
            this.Get_disk = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.m_HDSPACETableAdapter = new DiskInfoo.MISHDSPACETableAdapters.M_HDSPACETableAdapter();
            this.Pcid = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mHDSPACEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISHDSPACE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.Title = "日期(月/日)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Olive;
            chartArea1.AxisY.LabelStyle.Format = "N2";
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.Title = "剩餘(GB)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Olive;
            chartArea1.AxisY2.LabelStyle.Format = "N2";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.mHDSPACEBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 32);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(598, 361);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // mHDSPACEBindingSource
            // 
            this.mHDSPACEBindingSource.DataMember = "M_HDSPACE";
            this.mHDSPACEBindingSource.DataSource = this.mISHDSPACE;
            // 
            // mISHDSPACE
            // 
            this.mISHDSPACE.DataSetName = "MISHDSPACE";
            this.mISHDSPACE.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Get_disk
            // 
            this.Get_disk.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Get_disk.Location = new System.Drawing.Point(646, 32);
            this.Get_disk.Name = "Get_disk";
            this.Get_disk.Size = new System.Drawing.Size(142, 47);
            this.Get_disk.TabIndex = 1;
            this.Get_disk.UseVisualStyleBackColor = true;
            // 
            // m_HDSPACETableAdapter
            // 
            this.m_HDSPACETableAdapter.ClearBeforeFill = true;
            // 
            // Pcid
            // 
            this.Pcid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pcid.Font = new System.Drawing.Font("新細明體-ExtB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Pcid.FormattingEnabled = true;
            this.Pcid.Items.AddRange(new object[] {
            "DC01",
            "DC02",
            "EIP",
            "ERP",
            "ERP2",
            "GPM",
            "KMS",
            "NAS01",
            "SMRV2",
            "SVR09",
            "UTILEHS",
            "WSS01",
            "ANTIVIRUS"});
            this.Pcid.Location = new System.Drawing.Point(646, 193);
            this.Pcid.Name = "Pcid";
            this.Pcid.Size = new System.Drawing.Size(121, 27);
            this.Pcid.TabIndex = 3;
            this.Pcid.SelectionChangeCommitted += new System.EventHandler(this.Pcid_Changeevent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pcid);
            this.Controls.Add(this.Get_disk);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mHDSPACEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mISHDSPACE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Get_disk;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MISHDSPACE mISHDSPACE;
        private System.Windows.Forms.BindingSource mHDSPACEBindingSource;
        private MISHDSPACETableAdapters.M_HDSPACETableAdapter m_HDSPACETableAdapter;
        private System.Windows.Forms.ComboBox Pcid;
    }
}

