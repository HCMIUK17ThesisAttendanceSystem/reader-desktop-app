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
        string url = "https://hcmiu-presence.herokuapp.com";
        //string url = "http://localhost:8080";

        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
            BtnStart.Enabled = false;
        }

        private class Course
        {
            public Course(string id)
            {
                this.id = id;
            }
            public string id { get; set; }
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

            client.On(Socket.EVENT_DISCONNECT, (reason) =>
            {
                TxtLog.Text += $"Disconnected from server due to: {reason}\r\n";
                Console.WriteLine($"Disconnected from server due to: {reason}");
            });

            client.On(Socket.EVENT_RECONNECT, () =>
            {
                TxtLog.Text += "Reconnected to server :D\r\n";
                Console.WriteLine("Reconnected to server :D");
            });

            client.On("current-courses", response =>
            {
                //TxtLog.Text += response + "\r\n";
                Console.WriteLine(response);
            });

            client.On("scheduled-courses", response =>
            {
                //TxtLog.Text += response + "\r\n";
                Console.WriteLine(response);
            });
        }

        public void GPIControlMsg(GPI_Model gpi_model)
        {
            
        }

        private string AddNewRfidTag(string tagTID)
        {
            //TxtLog.Text += tagTID + "\r\n";
            HttpRequest request = new HttpRequest();
            string response = request.Post($"{url}/reader/rfid?rfidTag={tagTID}").ToString();
            return response;
        }

        private string CheckAttendance(string tagTID, string courseId)
        {
            HttpRequest request = new HttpRequest();
            string response = request.Post($"{url}/reader/attendance?rfidTag={tagTID}&courseId={courseId}").ToString();
            return response;
        }

        public void OutPutTags(Tag_Model tag)
        {
            Console.WriteLine(tag.TID);
            //string res = AddNewRfidTag(tag.TID);
            string res = CheckAttendance(tag.TID, TxtCourseId.Text);
            TxtLog.Text += res + "\r\n";
            Console.WriteLine(res);
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
            string tcp = TxtTcp.Text;
            if (BtnConnect.Text == "Connect")
            {
                    bool cn = RFIDReader.CreateTcpConn(tcp, this); // Connect đến đầu đọc
                    if (cn)
                    {
                        TxtLog.Text += "Connect successfully to reader(s)\r\n";
                        BtnConnect.Text = "Disconnect";
                        TxtTcp.Enabled = false;
                        TxtCourseId.Enabled = false;
                        BtnStart.Enabled = true;

                        int stup = RFIDReader._RFIDConfig.SetTagUpdateParam(tcp, 6000, 0); // Stop reading the same tag for 1 minute (6000 centiseconds)
                        if (stup == 0) TxtLog.Text += "Set tag update filter successfully\r\n";
                        else TxtLog.Text += "Set tag update filter failed\r\n";

                        //int srasp = RFIDReader._RFIDConfig.SetReaderAutoSleepParam(tcp, true, "50"); // auto sleep in 1/2 second
                        //if (srasp == 0) TxtLog.Text += "Set auto sleep successfully\r\n";
                        //else TxtLog.Text += "Set auto sleep failed\r\n";

                        RFIDReader._RFIDConfig.Stop(TxtTcp.Text); 
                    }
                    else
                    {
                        TxtLog.Text += "Failed connection to reader(s)\r\n";
                    }

            }
            else
            {
                RFIDReader._RFIDConfig.Stop(TxtTcp.Text); // Tắt chế độ đọc thẻ trước khi ngắt kết nối
                RFIDReader.CloseConn(TxtTcp.Text); // Ngắt kết nối với đầu đọc
                TxtTcp.Enabled = true;
                TxtCourseId.Enabled = true;
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
