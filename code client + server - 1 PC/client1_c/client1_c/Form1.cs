using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;// Socket programming library
using System.IO;

namespace client1_c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient _client = new TcpClient();// Provides client connections for TCP network services.
                _client.Connect("192.168.1.5", 8888);
                byte[] bytes = new byte[10];
                NetworkStream ns = _client.GetStream();// connect to the media/ stream/ link 
                //ns.Read(imgArray, 0, imgArray.Length);
                //Image img = byteArrayToImage(imgArray);
                //img.Save("C:\\Users\\JemmY_NeutroN\\Downloads\\img.jpeg");
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine("C:\\Users\\JemmY_NeutroN\\Desktop\\net\\");
                sw.Flush();
                StreamReader num = new StreamReader(ns);
                string counter = num.ReadLine();
                MessageBox.Show(counter,"Number of Images found in the file");
                int count = int.Parse(counter);
                StreamReader sr = new StreamReader(ns);
                string[] arr = new string[count];
                for (int i = 0; i < count; ++i)
                    arr[i] = sr.ReadLine();

                for (int i = 0; i < count; i++)
                    MessageBox.Show(arr[i], "recieved");

                _client.Close();
                
            }
            catch (Exception ep)
            { MessageBox.Show(ep.Message);}
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}