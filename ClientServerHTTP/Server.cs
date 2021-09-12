using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
 
namespace SocketTcpServer
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
             
            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);
 
                // начинаем прослушивание
                listenSocket.Listen(10);
 
                Console.WriteLine("Сервер запущен: http://127.0.0.1:" + port);
 
                while (true)
                {
                    Console.WriteLine("Ожидание подключений...");
 
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных
                    int i = 0; // счётчик
                    bool flag = false; // флаг
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        // проверяем от браузера ли пришёл завпрос
                        if (i == 0) if (Encoding.UTF8.GetString(data, 0, bytes).IndexOf("GET / HTTP/1.1") == 0) flag = true;
                        i = 1;
                    }
                    while (handler.Available>0);
 
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
                     
                    // отправляем ответ
                    if (flag) {
                        // Код простой HTML-странички
                        string Html = "<html><body><h1>Сервер работает!</h1></body></html>";
                        // Необходимые заголовки: ответ сервера, тип и длина содержимого. После двух пустых строк - само содержимое
                        string message = "HTTP/1.1 200 OK\nContent-Type: text/html; charset=utf-8\nContent-Length:" + Html.Length.ToString() + "\n\n" + Html;
                        data = Encoding.UTF8.GetBytes(message);
                    }else {
                        string message = "Ваше сообщение доставлено.";
                        data = Encoding.Unicode.GetBytes(message);
                    }

                    
                    handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}