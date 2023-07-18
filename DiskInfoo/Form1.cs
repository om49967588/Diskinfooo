using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace DiskInfoo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //string datas = "172.16.1.5";
        //string catalog = "MIS";
        //string account = "erp_adm";
        //string password = "/apptzen/";
        string sqlconnect = ConfigurationManager.ConnectionStrings["DiskInfoo.Properties.Settings.MISConnectionString"].ConnectionString.ToString();

        string[] datee = new string[7];
        double[] diskfree = new double[7];

        List<string> dateList = new List<string>();
        List<double> diskList = new List<double>();

        SqlCommand sqlcmd = new SqlCommand();

        Color C = Color.Red;
        Color D = Color.Blue;
        Color E = Color.Green;


        
        private void GetDiskValue_()
        {
            try
            {
                dateList.Clear();
                diskList.Clear();
                SqlDataReader hdtype = this.sqlcmd.ExecuteReader();
                if (hdtype.HasRows)
                {
                    while (hdtype.Read())
                    {
                        dateList.Add(Convert.ToString(hdtype["RECDT"]).Substring(5, 5));
                        diskList.Add(Convert.ToDouble(hdtype["DISKFREE"]));
                    }
                }
                else { MessageBox.Show("NO"); }
                hdtype.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DrawChart_()
        {
            //值傳入陣列+排序
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    diskfree[i] = diskList[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
                
            }
            datee = dateList.ToArray();
            Array.Reverse(datee);
            Array.Reverse(diskfree);

            //製作圖
            string series1 = (string)sqlcmd.Parameters[1].Value;
            Series Disk1 = new Series((string)series1);
            chart1.Series.Add(Disk1);
            //圖的樣式
            Disk1.ChartType = SeriesChartType.Line;
            if (series1 == "C")
            {
                Disk1.BorderColor = C;
                Disk1.Color = C;
                Disk1.MarkerColor = C;
            }
            else if (series1 == "D") 
            {
                Disk1.BorderColor = D;
                Disk1.Color = D;
                Disk1.MarkerColor = D;
            }
            else if (series1 == "E")
            {
                Disk1.BorderColor = E;
                Disk1.Color = E;
                Disk1.MarkerColor = E;
            }
            Disk1.BorderWidth = 2;
            Disk1.XValueType = ChartValueType.Date;
            Disk1.YValueType = ChartValueType.Double;
            //加入點畫成圖
            Disk1.Points.Clear();
            for (int i = 0; i < 7; i++)
            {
                Disk1.Points.AddXY(datee[i], diskfree[i]);
                Disk1.Points[i].Label = diskfree[i].ToString();
                Disk1.Points[i].MarkerStyle = MarkerStyle.Circle;
                Disk1.Points[i].MarkerBorderWidth = 2;
                Disk1.Points[i].MarkerSize = 5;
                Disk1.Points[i].LabelForeColor = Color.Orange;
                Disk1.Points[i].IsValueShownAsLabel = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'mISHDSPACE.M_HDSPACE' 資料表。您可以視需要進行移動或移除。
            this.m_HDSPACETableAdapter.Fill(this.mISHDSPACE.M_HDSPACE);
        }

        public void Pcid_Changeevent(object sender, EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            this.sqlcmd.Parameters.Clear(); 
            chart1.Series.Clear();
            if ((string)sen.SelectedItem == "DC01")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIDC01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIDC01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "E");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "DC02")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIDC02");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIDC02");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();
                }
            }else if ((string)sen.SelectedItem == "EIP")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIEIP");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();
                }
            }else if ((string)sen.SelectedItem == "ERP")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIERP");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIERP");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();
                }
            }else if ((string)sen.SelectedItem == "ERP2")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIERP2");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIERP2");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "GPM")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIGPM");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIGPM");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "E");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "KMS")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIKMS");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "NAS01")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTINAS01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTINAS01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTINAS01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "E");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "WSS01")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIWSS01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIWSS01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIWSS01");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "E");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "SMRV2")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTISMRV2");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "SVR09")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTISVR09");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTISVR09");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTISVR09");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "E");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "UTILEHS")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIUTILEHS");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();

                    sqlcmd.Parameters.Clear();
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIUTILEHS");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "D");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
            else if ((string)sen.SelectedItem == "ANTIVIRUS")
            {
                using (SqlConnection conn = new SqlConnection(sqlconnect))
                {
                    sqlcmd.Connection = conn;
                    conn.Open();
                    this.sqlcmd.CommandText = @"SELECT TOP 7 RECDT, DISKFREE  FROM M_HDSPACE WHERE PCID =@PCID AND DISKID = @DISKID ORDER BY RECDT DESC";
                    this.sqlcmd.CommandType = CommandType.Text;
                    this.sqlcmd.Parameters.AddWithValue("@PCID", "TTIANTIVIRUS");
                    this.sqlcmd.Parameters.AddWithValue("@DISKID", "C");
                    GetDiskValue_();
                    DrawChart_();
                }
            }
        }
    }
}
