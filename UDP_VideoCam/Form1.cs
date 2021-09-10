using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_VideoCam
{
    public partial class Form_TV : Form
    {
        private UdpClient _udpClient;
        
        public Form_TV()
        {
            InitializeComponent();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 45001);
            _udpClient = new UdpClient(iPEndPoint);
        }

        private async void Form_TV_Load(object sender, EventArgs e)
        {
            while (true)
            {
                var data = await _udpClient.ReceiveAsync();//получение данных
                MemoryStream memoryStream = new MemoryStream(data.Buffer);
                pictureBox_TV.Image = new Bitmap(memoryStream);
                
                pictureBox_TV.Invalidate();
          }
        }
    }
}
