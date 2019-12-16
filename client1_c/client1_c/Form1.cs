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
                NetworkStream _ns = _client.GetStream();// connect to the media/ stream/ link 

                /* FOR IMAGE note using below function */
                //StreamReader arrSize = new StreamReader(_ns);
                //int imgSize = int.Parse(arrSize.ReadLine());
                //byte[] _imgArray = new byte[imgSize];
                //_ns.Read(_imgArray, 0, _imgArray.Length);
                //Image img = byteArrayToImage(_imgArray);
                //img.Save("C:\\Users\\JemmY_NeutroN\\Desktop\\img.jpeg");
                //MessageBox.Show("Image has been saved ", "Client");

                /* FOR PATHS of images  i.e. array of text */ 
                //StreamWriter _sw = new StreamWriter(_ns);
                //_sw.WriteLine("C:\\Users\\JemmY_NeutroN\\Desktop\\photos\\");
                //_sw.Flush();
                //StreamReader _num = new StreamReader(_ns);
                //int count = int.Parse(_num.ReadLine());
                //MessageBox.Show(count.ToString(),"Number of Images found in the file");
                //StreamReader _sr = new StreamReader(_ns);
                //string[] _arr = new string[count];
                //for (int i = 0; i < count; ++i)
                //    _arr[i] = _sr.ReadLine();

                //for (int i = 0; i < count; i++)
                //    MessageBox.Show(_arr[i], "Client | paths of images ");

                _client.Close();
                
            }
            catch (Exception ep)
            { MessageBox.Show(ep.Message,"Client");}
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream _ms = new MemoryStream(byteArrayIn);
            Image _returnImage = Image.FromStream(_ms);
            return _returnImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}