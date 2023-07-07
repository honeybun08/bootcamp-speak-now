namespace Client // для использ. одних и тех же перемнных в разных файлах, тут могут лежать неск.классов
{
    class Program
    {
        static void Main(string[] args) // функция void
        {
            Console.WriteLine("Это наш клиент");
            OurClient ourClient = new OurClient(); // благодаря namespace можно обратиться к классу OurClient
        }
    }
}
