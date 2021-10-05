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
        private bool newGame;
        private Level currentLevel { get; set;}
        private Level[] levelOrder;

        public GameManager(int gameMode, int difficulty, int obolsLeft, int diffMultiplier, bool newGame) {
            this.gameMode = gameMode;
            this.difficulty = difficulty;
            this.obolsLeft = obolsLeft;
            this.diffMultiplier = diffMultiplier;
            this.newGame = newGame;
            if (newGame) {
                generateLevels();
                this.currentLevel = levelOrder[0];
            }
        }

        private void generateLevels() {

            //levelOrder[0] = new Level();


        }
    }
}
