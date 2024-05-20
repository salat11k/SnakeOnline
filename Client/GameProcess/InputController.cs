using SnakeGame_Client_.GameProcess.DataTypes.Enums;
using static System.Console;

namespace SnakeGame_Client_.GameProcess
{
    public class InputController
    {
        public Direction CurrentDirection { get; private set; } = Direction.Right;
        public Direction GetDirection()
        {
            if (!KeyAvailable)
                return CurrentDirection;

            ConsoleKey key = ReadKey(true).Key;

            CurrentDirection = key switch
            {
                ConsoleKey.DownArrow when CurrentDirection != Direction.Up => Direction.Down,
                ConsoleKey.UpArrow when CurrentDirection != Direction.Down => Direction.Up,
                ConsoleKey.LeftArrow when CurrentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when CurrentDirection != Direction.Left => Direction.Right,
                _ => Direction.Right
            };
            return CurrentDirection;
        }
    }
}
