﻿using System;

namespace Mythkeeper {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var game = new MKGame())
                game.Run();
        }
    }
}
