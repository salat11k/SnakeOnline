using Newtonsoft.Json;
using System.ComponentModel.Design.Serialization;

namespace SnakeGame_Client_.GameProcess.DataTypes
{
    
    public struct Pixel
    {
        private const char PIXEL_CHAR = '█';

        [JsonProperty("pixelcoordinate")]
        public Vector2Int PixelCoordinate { get; private set; }
        [JsonProperty("pixelcolor")]
        public ConsoleColor PixelColor { get; private set; }
        [JsonProperty("pixelsizefrompixel")]
        public int PixelSize { get; private set; } = 3;


        public Pixel(Vector2Int pixelCoordinate, ConsoleColor pixelColor, int pixelSize = 3)
        {
            PixelCoordinate = pixelCoordinate;
            PixelColor = pixelColor;
            PixelSize = pixelSize;
        }
        public Pixel() { }

        public void Draw()
        {
            Console.ForegroundColor = PixelColor;

            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition(PixelCoordinate.X * PixelSize + x, PixelCoordinate.Y * PixelSize + y);
                    Console.Write(PIXEL_CHAR);
                }
            }
        }
        public void Clear()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition(PixelCoordinate.X * PixelSize + x, PixelCoordinate.Y * PixelSize + y);
                    Console.Write(" ");
                }
            }
        }
    }
}
