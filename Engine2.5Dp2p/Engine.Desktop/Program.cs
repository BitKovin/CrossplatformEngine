using System;

namespace Engine.Desktop
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game.MyGame())
                game.Run();

            Engine.GameMain.platform = Platform.Desktop;
        }
    }
}
