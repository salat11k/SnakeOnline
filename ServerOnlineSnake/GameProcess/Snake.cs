using Newtonsoft.Json;
using ServerOnlineSnake.GameProcess.DataTypes;

namespace ServerOnlineSnake.GameProcess
{
    public class Snake
    {
        public event Action OnCollisionEnter;

        private const int START_LENGTH = 2;


        private Pixel _head;
        private Queue<Pixel> _body;
     //   private InputController _input;
        private ConsoleColor _headColor;
        private ConsoleColor _bodyColor;
        private int _pixelSize;

        #region Propertys
        [JsonProperty("head")]
        public Pixel Head { get => _head;private set => _head = value; }
        [JsonProperty("body")]
        public Queue<Pixel> Body { get => _body; private set => _body = value; }
        [JsonProperty("headcolor")]
        public ConsoleColor HeadColor { get => _headColor; private set => _headColor = value; }
        [JsonProperty("bodycolor")]
        public ConsoleColor BodyColor { get => _bodyColor; private set => _bodyColor = value; }
        [JsonProperty("pixelsizefromsnake")]
        public int PixelSize { get => _pixelSize; private set => _pixelSize = value; }
        #endregion

        public Snake(Vector2Int startPosition,int pixelSize,ConsoleColor bodyColor,ConsoleColor headColor)
        {
            _headColor = headColor;
            _bodyColor = bodyColor;
            _pixelSize = pixelSize;
            _head = new(startPosition,_headColor, pixelSize);
            _body = new();

            for (int i = START_LENGTH; i >= 0; i--)
            {
                _body.Enqueue(new Pixel(new Vector2Int(_head.PixelCoordinate.X - i - 1, startPosition.Y), _bodyColor,pixelSize));
            }
        }
        public Snake() { }

        public void Move()
        {

            _body.Enqueue(new Pixel(_head.PixelCoordinate, _bodyColor,_pixelSize));
            _body.Dequeue();

            _head = new Pixel(new Vector2Int(_head.PixelCoordinate.X, _head.PixelCoordinate.Y + 1), _headColor,_pixelSize); /* _input.CurrentDirection switch
            {
                Direction.Right => new Pixel(new Vector2Int(_head.PixelCoordinate.X + 1, _head.PixelCoordinate.Y), _headColor, _pixelSize),
                Direction.Left => new Pixel(new Vector2Int(_head.PixelCoordinate.X - 1, _head.PixelCoordinate.Y), _headColor, _pixelSize),
                Direction.Up => new Pixel(new Vector2Int(_head.PixelCoordinate.X, _head.PixelCoordinate.Y - 1), _headColor, _pixelSize),
                Direction.Down => new Pixel(new Vector2Int(_head.PixelCoordinate.X, _head.PixelCoordinate.Y + 1), _headColor, _pixelSize),
                _ => new Pixel(new Vector2Int(_head.PixelCoordinate.X + 1, _head.PixelCoordinate.Y), _headColor, _pixelSize)
            }; */

        }
        public void CheckCollision(Vector2Int mapSize)
        {
            if(_head.PixelCoordinate.X == mapSize.X - 1 ||
                _head.PixelCoordinate.X == 0 ||
                _head.PixelCoordinate.Y == mapSize.Y - 1 ||
                _head.PixelCoordinate.Y == 0 ||
                _body.Any(p => p.PixelCoordinate == _head.PixelCoordinate))
            {
                OnCollisionEnter?.Invoke();
            }
        }
        public override string ToString()
        {
            return $"Head: {_head.PixelCoordinate}";
        }
    }
}
