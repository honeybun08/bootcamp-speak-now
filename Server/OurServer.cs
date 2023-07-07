using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener server; // слушатель подключений

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients();  
        }

        void LoopClients() // ловим клиентиков
        {
            while (true) // бесконечно ждем клиентов
            {
                TcpClient client = server.AcceptTcpClient();

                Thread thread = new Thread(() => HandleClient(client));
                thread.Start();
            }
        }

        void HandleClient(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8); // с клиентом устанавл.соединение тут,
            // ведь у сервера несколько клиентов и ему нужжно работаь с конкретным, в то время как у клиента всего один сервер
            // для каждого клиента будет свой поток через один порт
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8); 

            while (true) // бесконечно работаем с клиентов
            {
                string message = sReader.ReadLine();
                Console.WriteLine($"Клиент написал - {message}");

                Console.WriteLine("Напишите сообщение клиенту: ");
                string answer = Console.ReadLine();
                sWriter.WriteLine(answer);
                sWriter.Flush();
            }
        }
    }
}