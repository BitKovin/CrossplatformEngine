﻿using System;

namespace Engine.Desktop
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Engine.Game1())
                game.Run();
        }
    }
}
