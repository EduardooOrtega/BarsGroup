using System.Threading;

public class Program
{
    /// <summary>
    /// Предоставляет возможность обработать запрос.
    /// </summary>
    public interface IRequestHandler
    {
        /// <summary>
        /// Обработать запрос.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="arguments">Аргументы запроса.</param>
        /// <returns>Результат выполнения запроса.</returns>
        string HandleRequest(string message, string[] arguments);
    }


    /// <summary>
    /// Тестовый обработчик запросов.
    /// </summary>
    public class DummyRequestHandler : IRequestHandler
    {
        /// <inheritdoc />
        public string HandleRequest(string message, string[] arguments)
        {
            // Притворяемся, что делаем что то.
            Thread.Sleep(10_000);
            if (message.Contains("упади"))
            {
                throw new Exception("Я упал, как сам просил");
            }
            return Guid.NewGuid().ToString("D");
        }
    }

    /// <summary>
    /// Метод для запуска потока нового запроса
    /// </summary>
    /// <param name="message">сообщение</param>
    /// <param name="handler"></param>
    /// <param name="arguments">аргумент запроса</param>
    public static void QueryCall(string message, string[] arguments)
    {
        string messageID = Guid.NewGuid().ToString("D");
        DummyRequestHandler Handler = new DummyRequestHandler();

        Console.WriteLine($"Было отправлено сообщение {message}. Присвоен индентефикатор {messageID}");
        try
        {
            Console.WriteLine($"Сообщение с индентификатором {messageID} получило ответ {Handler.HandleRequest(message, arguments)}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Сообщение с индентификатором {messageID} упало с ошибкой {e.Message}");
        }


    }
    public static void Main()
    {

        string command = "";
        List<string> arguments = new List<string>();
        string message = "";

        while (command != "/q")
        {
            Console.WriteLine("Введите текст запроса. Для выхода /q");
            command = Console.ReadLine();

            if (command == "/q")
            {
                break;
            }
            else
            {
                Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны enter");
                message = command;
                command = Console.ReadLine();
                while (command != "")
                {
                    arguments.Add(command);
                    Console.WriteLine("Введите следующий аргумент сообщения. Если аргументы не нужны enter");
                    command = Console.ReadLine();
                }
            }
            Thread t = new Thread(call => QueryCall(message, arguments.ToArray()));
            t.Start();

            arguments = new List<string>();//создаём новы лист аргуметов для каждого запроса
        }

        Console.WriteLine("Выход из приложения");
    }
}

