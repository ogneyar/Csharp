using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace HTTPServer {
    class Server {
        TcpListener Listener; // Объект, принимающий TCP-клиентов
        // Запуск сервера
        public Server(int Port) {
            // Создаем "слушателя" для указанного порта
            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); // Запускаем его

            Console.WriteLine("Start!");

            // В бесконечном цикле
            while (true) {
                // Принимаем новых клиентов
                // Listener.AcceptTcpClient();
                new Client(Listener.AcceptTcpClient());
                Console.WriteLine("HZ!");
            }
        }

        // Остановка сервера
        ~Server() {
            // Если "слушатель" был создан
            if (Listener != null) {
                // Остановим его
                Listener.Stop();
                Console.WriteLine("Stop!");
            }
        }

        static void Main(string[] args) {
            // Создадим новый сервер на порту 80
            new Server(80);
        }
    }

    class Client {
        // Конструктор класса. Ему нужно передавать принятого клиента от TcpListener
        public Client(TcpClient Client) {
            // Код простой HTML-странички
            string Html = "<html><body><h1>It works!</h1></body></html>";
            // Необходимые заголовки: ответ сервера, тип и длина содержимого. После двух пустых строк - само содержимое
            string Str = "HTTP/1.1 200 OK\nContent-Type: text/html; charset=utf-8\nContent-Length:" + Html.Length.ToString() + "\n\n" + Html;
            // Приведем строку к виду массива байт
            byte[] Buffer = Encoding.UTF8.GetBytes(Str);
            Console.WriteLine("vot!");
            // Отправим его клиенту
            Client.GetStream().Write(Buffer, 0, Buffer.Length);
            // Закроем соединение
            Client.Close();
        }
    }
}

