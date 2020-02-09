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
                _client.Connect("192.168.1.101", 8888);
                //_client.Connect("192.168.1.1", 8888);
                NetworkStream _ns = _client.GetStream();// connect to the media/ stream/ link 

                string path = textBox1.Text;

                StreamWriter send = new StreamWriter(_ns);
                send.WriteLine(path);
                send.Flush();

                if (path.Contains("jpeg") || path.Contains("jpg") || path.Contains("png"))
                {
                    StreamReader arrSize = new StreamReader(_ns);
                    int imgSize = int.Parse(arrSize.ReadLine());
                    byte[] _imgArray = new byte[imgSize];
                    StreamReader sr = new StreamReader(_ns);
                    for (int i = 0; i < _imgArray.Length; i++)
                        _imgArray[i] = byte.Parse(sr.ReadLine());
                    Image img = byteArrayToImage(_imgArray);
                    img.Save(@"C:\Users\JemmY_NeutroN\Desktop\img.jpeg");
                    //img.Save(@"C:\Users\cdc\Desktop\img.jpeg");
                    MessageBox.Show("Image has been saved successfully", "Client");
                }


                else if (path.Contains("mp3") || path.Contains("wav"))
                {
                    /*FOR AUDIO */
                    StreamReader _sz = new StreamReader(_ns);
                    int _audioLength = int.Parse(_sz.ReadLine());
                    byte[] _audio = new byte[_audioLength];
                    StreamReader sr = new StreamReader(_ns);
                    button1.Enabled = false;
                    for (int i = 0; i < _audio.Length; i++)
                        _audio[i] = byte.Parse(sr.ReadLine());
                    File.WriteAllBytes(@"C:\Users\JemmY_NeutroN\Desktop\audio.mp3", _audio);
                    MessageBox.Show("audio has been saved successfully", "Client");
                    button1.Enabled = true;

                }
                else if (path.Contains("mp4") || path.Contains("mkv"))
                {

                    /*FOR VIDEO */
                    StreamReader _sz = new StreamReader(_ns);
                    int _videoLength = int.Parse(_sz.ReadLine());
                    byte[] _video = new byte[_videoLength];
                    StreamReader sr = new StreamReader(_ns);
                    button1.Enabled = false;
                    for (int i = 0; i < _video.Length; i++)
                        _video[i] = byte.Parse(sr.ReadLine());
                    File.WriteAllBytes(@"C:\Users\JemmY_NeutroN\Desktop\video.mp4", _video);
                    MessageBox.Show("video has been saved succeeded", "Client");
                    button1.Enabled = true;

                }

                
               
              
                /* FOR IMAGE note using below function */
                //StreamReader arrSize = new StreamReader(_ns);
                //int imgSize = int.Parse(arrSize.ReadLine());
                //byte[] _imgArray = new byte[imgSize];
                ////_ns.Read(_imgArray, 0, _imgArray.Length);
                //StreamReader sr = new StreamReader(_ns);
                //for (int i = 0; i < _imgArray.Length; i++)
                //    _imgArray[i] = byte.Parse(sr.ReadLine());
                //Image img = byteArrayToImage(_imgArray);
                //img.Save("C:\\Users\\JemmY_NeutroN\\Desktop\\img.jpeg");
                //img.Save(@"E:\B\College\Biomedical\Fourth year\First semester\Networks\Tasks & Projects\Final_Project\img.jpg");
                //img.Save(@"E:\B\College\Biomedical\img.jpg");
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

                /*FOR AUDIO */
                //StreamReader _sz = new StreamReader(_ns);
                //int _audioLength = int.Parse(_sz.ReadLine());
                //byte[] _audio = new byte[_audioLength];
                //StreamReader sr = new StreamReader(_ns);
                //for (int i = 0; i < _audio.Length; i++)
                //    _audio[i] = byte.Parse(sr.ReadLine());
                //File.WriteAllBytes(@"C:\Users\JemmY_NeutroN\Desktop\azan.mp3", _audio);
                //MessageBox.Show("audio succeeded", "Client");

                /*FOR VIDEO */
                //StreamReader _sz = new StreamReader(_ns);
                //int _videoLength = int.Parse(_sz.ReadLine());
                //byte[] _video = new byte[_videoLength];
                //StreamReader sr = new StreamReader(_ns);
                //for (int i = 0; i < _video.Length; i++)
                //    _video[i] = byte.Parse(sr.ReadLine());
                //File.WriteAllBytes(@"C:\Users\JemmY_NeutroN\Desktop\caaaaat.mp4", _video);
                //MessageBox.Show("video succeeded", "Client");

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}