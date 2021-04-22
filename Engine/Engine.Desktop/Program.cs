using System;

namespace Engine.Desktop
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game.Game())
                game.Run();

            Engine.GameMain.platform = Platform.Desktop;
        }
    }
}
