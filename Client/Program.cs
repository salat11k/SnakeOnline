using SnakeGame_Client_.GameProcess;
using SnakeGame_Client_.GameProcess.DataTypes;

class Program
{
    static async Task Main()
    {
        await ConnectToServer();
        Console.ReadKey();
    }

    private static async Task ConnectToServer()
    {
        Console.WriteLine("Введите порт сервера");
        var line = Console.ReadLine();
        int port = int.Parse(line);

        var gc = new GameController(new Vector2Int(30, 20), 3);
        await gc.StartGame(port);
    }
}