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

namespace server_s
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TCP protocol= the way to transport for example by car 
            TcpListener _listener = new TcpListener(8888); 
            _listener.Start();// start work
            Socket _cs = _listener.AcceptSocket();//  _cs Distribution employee
           
            NetworkStream _ns = new NetworkStream(_cs); // make general steram. any 1 can send on it through socket (door)
            
            // Recive msgs from the client
            StreamReader _sr = new StreamReader(_ns); // read msgs through the stream_reader through the strean _ns
            string result = _sr.ReadLine();// save what is i the stream_reader
            MessageBox.Show(result);


            // Send msgs to the client
            StreamWriter _sw = new StreamWriter(_ns);// writ msgs through the stream_reader
            // check for PANADOL in Database
            _sw.WriteLine("there not enough Panadol");// send this msgs to the client through the _sw
            _sw.Flush();//Clears buffers for this stream
            _cs.Close();// close the door
           _listener.Stop();
        }
    }
}
