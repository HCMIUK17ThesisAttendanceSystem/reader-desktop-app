using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFIDReaderAPI;
using RFIDReaderAPI.Interface;
using RFIDReaderAPI.Models;
using System.Data.SqlClient;

namespace ReadTag
{
    public partial class Form1 : Form, IAsynchronousMessage
    {
        string strConnection = "chuoi ket noi";
        public Form1()
        {
            InitializeComponent();
            BtnStart.Enabled = false;
        }

        public void GPIControlMsg(GPI_Model gpi_model)
        {
            
        }

        private void AddNewRfidStudentTag(string tagTID)
        {
            // Post tagTID to backend
        }

        private void AddAttendanceRecord(string tagTID, string tagReadTime, int AntNum)
        {
            // Post tagTID, readTime and room number
        }

        public void OutPutTags(Tag_Model tag)
        {
            // Sau khi bật chế độ đọc thẻ, dữ liệu trả về xuất ra tại đây.
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand cmd;
            cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "INSERT INTO <Ten-Bang> (Cot1, Cot2, Cot3) VALUES('" + tag.TID + "','" + tag.ReadTime + "','" + tag.ANT_NUM + "')";
            /*tag.TID = ID thẻ // tag.ReadTime = thời gian đọc thẻ // tag.ANT_NUM = ăng-ten đọc đc thẻ
            Xem thêm các dữ liệu xuất ra trong file hướng dẫn.*/
            cmd.ExecuteNonQuery();

            // Perform one of two method (add new tag or add attendance record)
        }

        public void OutPutTagsOver()
        {
            //Thực thi khi dừng chế độ đọc thẻ
        }

        public void PortClosing(string connID)
        {
            //Thực thi khi ngắt kết nối với đầu đọc
        }

        public void PortConnecting(string connID)
        {
            //Thực thi khi kết nối với đầu đọc
            // Get/put connection with backend too
        }

        public void WriteDebugMsg(string msg)
        {

        }

        public void WriteLog(string msg)
        {

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (BtnConnect.Text == "Connect")
            {
                    bool cn = RFIDReader.CreateTcpConn(TxtTcp.Text, this); // Connect đến đầu đọc
                    if (cn)
                    {
                        TxtLog.Text += "Kết nối thành công\r\n";
                        BtnConnect.Text = "Disconnect";
                        TxtTcp.Enabled = false;
                        BtnStart.Enabled = true;
                        RFIDReader._RFIDConfig.Stop(TxtTcp.Text); 
                    }
                    else
                    {
                        TxtLog.Text += "Kết nối thất bại\r\n";
                    }

            }
            else
            {
                RFIDReader._RFIDConfig.Stop(TxtTcp.Text); // Tắt chế độ đọc thẻ trước khi ngắt kết nối
                RFIDReader.CloseConn(TxtTcp.Text); // Ngắt kết nối với đầu đọc
                TxtTcp.Enabled = true;
                BtnStart.Enabled = false;
                BtnConnect.Text = "Connect";
                TxtLog.Text += "Ngắt kết nối\r\n";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (BtnStart.Text == "Start")
            {
                int st = RFIDReader._Tag6C.GetEPC_TID(TxtTcp.Text, eAntennaNo._1, eReadType.Inventory); // Bật đọc thẻ ăng-ten 1, chế độ inventory ( đọc liên tục )
                if (st == 0)
                {
                    TxtLog.Text += "Bắt đầu đọc thẻ\r\n";
                    BtnStart.Text = "Stop";
                    BtnConnect.Enabled = false;
                    BtnExit.Enabled = false;
                }
                else
                {
                    TxtLog.Text += "Đọc thẻ thất bại\r\n";
                }
            }
            else
            {
                RFIDReader._RFIDConfig.Stop(TxtTcp.Text); // Tắt chế độ đọc thẻ
                BtnStart.Text = "Start";
                TxtLog.Text += "Dừng đọc thẻ\r\n";
                BtnConnect.Enabled = true;
                BtnExit.Enabled = true;
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            TxtLog.Clear();
        }
    }
}
