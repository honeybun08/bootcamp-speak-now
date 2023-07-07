using System.Net.Sockets; // чтобы подключить заготовленные библиотеки для работы с протоколом TCP 
using System.Text;

namespace Client
{
    class OurClient
    {   // позволяет работать с TCP
        private TcpClient client; // описание клиента, чтобы к нему обратиться
        private StreamWriter sWriter; // StreamWriter = класс, помогает писать данные на сервер
        private StreamReader sReader;

        public OurClient() // чтобы можно было к этому сторонним образом обратиться
        {
            client = new TcpClient("127.0.0.1", 5555); // IP-адрес и порт приема данных
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8); //(поток чтения) здесь клиент подключ.к серверу и устанвливаем поток общения между ними
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8); // (поток записи)

            HandleCommunication();
        }

        void HandleCommunication() // на вход ничего не принимает, т.к. все данные из 9 строки передадутся ему
        {
            while (true) // бесконечный цикл, т.к. нужно всегда держать соединение с сервером
            {
                Console.Write("> ");
                string message = Console.ReadLine();
                sWriter.WriteLine(message); // подготовака отправки сообщения серверу по потоку от клиента
                sWriter.Flush(); // отправка сообщения немедленно!

                string answerServer = sReader.ReadLine();
                Console.WriteLine($"Сервер ответил -> {answerServer}");
            }
        }


    }
}