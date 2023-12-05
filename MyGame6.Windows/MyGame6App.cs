using Stride.Engine;

namespace MyGame6
{
    class MyGame6App
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
