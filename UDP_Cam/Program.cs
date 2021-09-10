using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDP_Cam // отправляет данные с камеры, которая находиться на сервере
{
    class Program
    {
        private static IPEndPoint _iPEndPoint;//сетевая конечная точка (ipadress and port), которая находиться на сервере
        private static UdpClient _udpClient;//объект для получения и отправки данных по UDP протоколу
        static void Main(string[] args)
        {
            try
            {
                _udpClient = new UdpClient();//создаем объект UdpClient
                _iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 45001);// создаем сетевую конечную точку, указываем ip adress и порт

                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);//фильтр устройств компьютера,
                                                                                                              //ищет на копьютере подключенные девайсы,
                                                                                                              //в данном случае камеры - FilterCategory.VideoInputDevice

                VideoCaptureDevice vebCam = new VideoCaptureDevice(videoDevices[0].MonikerString); // videoDevices[0].MonikerString - полное имя адресс камеры
                                                                                                   // vebCam - создаем объект камеры
                                                                                                  
                vebCam.NewFrame += VebCam_NewFrame; //к событию (vebCam.NewFrame)- появление нового кадра в веб камере, привязываем метод VebCam_NewFrame,
                                                    //т.е. как только появляется новый кадр, то срабатывает метод VebCam_NewFrame
                                                    
                                                    

                while (true)
                {                  

                    vebCam.Start();// создает фоновый поток и получает данные с камеры через событие (vebCam.NewFrame), подключаем камеру 
                    Thread.Sleep(500);// поток приостанавливаем на 500 мс
                    vebCam.Stop();//останавливаем фоновый
                                  //поток камеры
                }

            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            

        }

        private static void VebCam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)// метод который привязан к событию NewFrame
                                                                                                    // (vebCam - у кого это событие произошло)
                                                                                                    // sender - vebCam, sender - это тот у кого это событие произошло
        
        {                                                                                            // AForge.Video.NewFrameEventArgs eventArgs - кадры, параметры события
            var bmp = new Bitmap(eventArgs.Frame, 800, 600);//создаем картинку, маштабируем, указываем размер в пикселях

            MemoryStream memoryStream = new MemoryStream(); // создаем пустой поток
            bmp.Save(memoryStream, ImageFormat.Jpeg); //конвертируем в Jpeg формат, сохраняем картинку в поток,
                                                     //bmp - картинка, которую сохраняем в поток memoryStream
            byte[] bytes = memoryStream.ToArray(); //конвертируе поток  в массив байт


            int sendedBytes = _udpClient.Send(bytes, bytes.Length, _iPEndPoint);// отправка данных по UDP протоколу, bytes - данные для отправки,
                                                                                // bytes.Length - общий размер отправляемых байтов,
                                                                                // _iPEndPoint -- куда отправляем
            Console.WriteLine($"bytes: {sendedBytes}");
            memoryStream.Close();
        }
    }
}
