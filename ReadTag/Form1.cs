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

using xNet;
using Quobject.SocketIoClientDotNet.Client;

namespace ReadTag
{
    public partial class Form1 : Form, IAsynchronousMessage
    {
        string url = "http://localhost:8080";

        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
            BtnStart.Enabled = false;
        }

        private class Response
        {
            public Response(string action)
            {
                this.action = action;
            }
            public string action { get; set; }
            public string data { get; set; }
        }

        public void ConnectToServer()
        {
            var client = IO.Socket(url);

            client.On(Socket.EVENT_CONNECT, () =>
            {
                TxtLog.Text += "Connected to server :D\r\n";
                Console.WriteLine("Connected to server :D");
                client.Emit("get-current-courses"); // emit not work
            });

            client.On("current-courses", response =>
            {
                TxtLog.Text += response + "\r\n";
                Console.WriteLine(response);
            });
        }

        public void GPIControlMsg(GPI_Model gpi_model)
        {
            
        }

        private string AddNewRfidTag(string tagTID)
        {
            TxtLog.Text += tagTID + "\r\n";
            HttpRequest request = new HttpRequest();
            string response = request.Post("http://192.168.0.104:8080/reader/new-rfid?rfidTag=" + tagTID).ToString();
            return response;
        }

        private string CheckAttendance(string tagTID, string courseId)
        {
            HttpRequest request = new HttpRequest();
            string response = request.Post($"http://192.168.0.104:8080/reader/attendance?rfidTag={tagTID}&courseId={courseId}").ToString();
            return response;
        }

        public void OutPutTags(Tag_Model tag)
        {
            //string res = AddNewRfidTag(tag.TID);
            string res = CheckAttendance(tag.TID, "603d1f1965bc512da8832841");
            TxtLog.Text += res + "\r\n";
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
            ConnectToServer();
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
