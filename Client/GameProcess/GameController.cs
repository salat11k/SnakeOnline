using Services;
using SnakeGame_Client_.GameProcess.DataTypes;
using System.Net;
using System.Net.Sockets;
using static System.Console;

namespace SnakeGame_Client_.GameProcess
{
    public class GameController
    {
        private readonly Vector2Int _mapSize;
        private readonly int _pixelSize;
        private List<Snake> _snakes;


        public GameController(Vector2Int size, int pixelSize)
        {
            _mapSize = size;
            _pixelSize = pixelSize;
        }

        public async Task StartGame(int port)
        {
            using var client = new TcpClient();

            await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), port);

            InitConsole();
            DrawConsole();

            while (true)
            {
                await PutData(client);
            }
        }
        private async Task PutData(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] data = new byte[6000];

            int size = await stream.ReadAsync(data);
            var newArray = new byte[size];

            Array.Copy(data, newArray, newArray.Length);

            ClearSnakes();
             _snakes = DataSerializer.DeserializeObject<List<Snake>>(newArray);
            DrawSnakes();
        }
        private void InitConsole()
        {
            SetWindowSize(_mapSize.X * _pixelSize, _mapSize.Y * _pixelSize);
            SetBufferSize(_mapSize.X * _pixelSize, _mapSize.Y * _pixelSize);

            CursorVisible = false;
        }
        private void DrawConsole()
        {
            for (int i = 0; i < _mapSize.X; i++)
            {
                new Pixel(new Vector2Int(i, 0), ConsoleColor.DarkGray).Draw();
                new Pixel(new Vector2Int(i, _mapSize.Y - 1), ConsoleColor.DarkGray).Draw();
            }

            for (int i = 0; i < _mapSize.Y; i++)
            {
                new Pixel(new Vector2Int(0, i), ConsoleColor.DarkGray).Draw();
                new Pixel(new Vector2Int(_mapSize.X - 1,i), ConsoleColor.DarkGray).Draw();
            }
        }
        private void ClearSnakes()
        {
            if (_snakes != null)
                foreach (var snake in _snakes)
                    snake.ClearSnake();
        }
        private void DrawSnakes()
        {
            foreach (var snake in _snakes)
                snake.DrawSnake();
        }
        
    }
}
