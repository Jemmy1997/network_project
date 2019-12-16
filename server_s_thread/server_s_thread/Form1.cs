using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace server_s_thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart ThListen = new ThreadStart(ListenAllTheTime); //ThreadStart Represents the method that executes on a Thread.

            Thread Th = new Thread(ThListen);// Thread Creates and controls a thread
            Th.Start();
        }

 //--------------- DONNOT forget to add the System.threading class above beside((.Net & .Net.Socket & .IO)) ---------------//
        // --------------------------------------------------------------------------------------------------------//
  // This method creates a welecome socket and keeps accepting clients. For every accepted client, it creates another thread.
        public void ListenAllTheTime()
        {
            TcpListener _listener = new TcpListener(8888);
            _listener.Start();

            while (true)
            {   // Accepting a new client
                Socket _cs = _listener.AcceptSocket();
                //Creating a thread specific to every accepted client.
                ParameterizedThreadStart ParThSt = new ParameterizedThreadStart(ReadAndWrite); //ParameterizedThreadStart Represents the method that executes on a Thread
                Thread THPerCLient = new Thread(ParThSt);
                THPerCLient.Start(_cs);
            }
        }

        // This method reads an input from the client
    private void ReadAndWrite(object ClientSocket)
   {
            Socket SkClient = (Socket)ClientSocket;
            NetworkStream _ns = new NetworkStream(SkClient);
            //StreamReader _sr = new StreamReader(_ns);
            //string result = _sr.ReadLine();
            //MessageBox.Show(result);
            //StreamWriter _sw = new StreamWriter(_ns);
            //_sw.WriteLine("there not enough Panadol");
            //_sw.Flush();
            //string imgName = "img1.jpg";
            //Image img = Image.FromFile("C:\\Users\\JemmY_NeutroN\\Desktop\\" + imgName);
            //byte[] imgArray = imgToByteArray(img);
            //_ns.Write(imgArray, 0, imgArray.Length);
            StreamReader _sr = new StreamReader(_ns);
            string path = _sr.ReadLine();
           // MessageBox.Show(path);
            string [] dir =  Directory.GetFiles(path,"*.jpg");
            StreamWriter num = new StreamWriter(_ns);
            num.WriteLine(dir.Length);
            num.Flush();
            StreamWriter _sw = new StreamWriter(_ns);
            for (int i = 0; i < dir.Length; i++)
            {
                _sw.WriteLine(dir[i]);
                _sw.Flush();
            } 
                

            SkClient.Close();
          //_listener.Stop();
        }
         
         //public byte[] imgToByteArray(Image img)
         //{
         //    MemoryStream ms = new MemoryStream();
         //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
         //    return ms.ToArray();
         //}
    }
}
