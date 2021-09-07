using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
    class GameManager {

        private int gameMode;
        private int difficulty;
        private int obolsLeft;
        private int diffMultiplier;
        private int scaleRate;
        private TimeSpan lastSaved;



        public GameManager(int gameMode, int difficulty, int obolsLeft, int diffMultiplier) {
            this.gameMode = gameMode;
            this.difficulty = difficulty;
            this.obolsLeft = obolsLeft;
            this.diffMultiplier = diffMultiplier;
        }
    }
}
