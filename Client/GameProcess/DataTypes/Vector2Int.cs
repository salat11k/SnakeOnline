using Newtonsoft.Json;

namespace SnakeGame_Client_.GameProcess.DataTypes
{

    public struct Vector2Int
    {
        [JsonProperty("x")]
        public int X { get; private set; }
        [JsonProperty("y")]
        public int Y { get; private set; }

        public Vector2Int(int x, int y)
        {
            if (x < 0)
                X = 0;
            else
                X = x;

            if (y < 0)
                Y = 0;
            else
                Y = y;
        }
        public Vector2Int() { }

        public static bool operator ==(Vector2Int first, Vector2Int second)
        {
            return first.X == second.X && first.Y == second.Y ? true : false;
        }

        public static bool operator !=(Vector2Int first, Vector2Int second)
        {
            return first.X != second.X || first.Y != second.Y ? true : false;
        }
    }
}
