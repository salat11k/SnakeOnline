using ServerOnlineSnake;
using System;
using System.Xml.Schema;

class Program
{
    static async Task Main()
    {
        Server server = new("127.0.0.1",1111,2);
        await server.StartServer();
        server.StartGame();
    }
}