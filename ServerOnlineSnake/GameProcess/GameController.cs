using ServerOnlineSnake.GameProcess.DataTypes;
using System.Diagnostics;
using System.Text;

namespace ServerOnlineSnake.GameProcess
{
    public class GameController
    {
        public event Action<List<Snake>> OnMoveEnded;

        private readonly Vector2Int _mapSize;
        private readonly int _pixelSize;

        private int _frameDelay = 300;
        private bool _isCollisionEnter = false;
        private Stopwatch _stopWatch;
        private List<Snake> _snakes;

        private StringBuilder _sb  = new();
        public GameController(int mapWidth, int mapHeight, int pixelSize)
        {
            _mapSize = new(mapWidth, mapHeight);
            _pixelSize = pixelSize;
            _stopWatch = new();

            Console.WriteLine("GameController was created");
            InitSnakes();
        }

        public void StartGame()
        {
            Console.WriteLine("Game was started");
            while (true)
            {
                _stopWatch.Restart();

                while (_stopWatch.ElapsedMilliseconds <= _frameDelay)
                {
                }

                foreach (var snake in _snakes)
                {
                    snake.Move();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"snake  {snake.ToString()}");
                }

                OnMoveEnded?.Invoke(_snakes);
            }
        }

        private void InitSnakes()
        {
            _snakes = new() { 
                new Snake(new Vector2Int(4, 4), 2,ConsoleColor.Red,ConsoleColor.DarkRed),
                new Snake(new Vector2Int(16, 4), 2,ConsoleColor.Green,ConsoleColor.DarkGreen)
            };
            Console.WriteLine("Snakes was created");
        }
    }
}
