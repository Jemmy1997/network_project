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
using System.Media;


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
            TcpListener listener = new TcpListener(8888);
            listener.Start();

            while (true)
            {   // Accepting a new client
                Socket cs = listener.AcceptSocket();
                //Creating a thread specific to every accepted client.
                ParameterizedThreadStart ParThSt = new ParameterizedThreadStart(ReadAndWrite); //ParameterizedThreadStart Represents the method that executes on a Thread
                Thread THPerCLient = new Thread(ParThSt);
                THPerCLient.Start(cs);
            }
        }

        // This method reads an input from the client
    private void ReadAndWrite(object ClientSocket)
   {

       try {
           Socket server = (Socket)ClientSocket;
           NetworkStream ns = new NetworkStream(server);

           /* FOR IMAGE note that using below function */
           //string imgName = "ai.jpg";
           //Image img = Image.FromFile("E:\\" + imgName);
           //byte[] imgArray = imgToByteArray(img);
           //StreamWriter imgSize = new StreamWriter(ns);
           //imgSize.WriteLine(imgArray.Length);
           //imgSize.Flush();
           //ns.Write(imgArray, 0, imgArray.Length);



           /* FOR PATHS of images  i.e. array of text */
           //StreamReader sr = new StreamReader(ns);
           //string path = sr.ReadLine();
           //MessageBox.Show(path, "Server| path received ");
           //string[] dir = Directory.GetFiles(path, "*.jpg");
           //StreamWriter num = new StreamWriter(ns);
           //num.WriteLine(dir.Length);
           //num.Flush();
           //StreamWriter sw = new StreamWriter(ns);
           //for (int i = 0; i < dir.Length; i++)
           //{
           //    sw.WriteLine(dir[i]);
           //    sw.Flush();
           //} 

           

           /* FOR AUDIO */
           byte[] audiobyte = File.ReadAllBytes("E:\\AzanByat.mp3");
           StreamWriter sz = new StreamWriter(ns);
           sz.WriteLine(audiobyte.Length);
           sz.Flush();
           ns.Write(audiobyte, 0, audiobyte.Length);

           server.Close();
       }
       catch (Exception ep)
       { MessageBox.Show(ep.Message, "Server"); }
    }

            public byte[] imgToByteArray(Image img)
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }
    }
}
