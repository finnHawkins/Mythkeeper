﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

    /// <summary>
    ///  List of possible game modes available
    /// </summary>
    public enum gameMode {
        normal,
        bossRush,
        hardcore,
        timed,
        corruption
    }

    /// <summary>
    /// List of game states
    /// </summary>
    public enum gameScreen {
        title,
        mainMenu,
        saveFile,
        levelScreen,
        mainSetting,
        inputSettings,
        audioSettings, // - this might just be able to be a volume slider on the main settings screen
        graphicsSettings, // - this might just be able to be a resolution dropdown picker on the main settings screen
        credits,
        pauseMenu,
        loading
    }

    /// <summary>
    /// Game Manager class
    /// </summary>
    class GameManager {


        private int difficulty;
        private int obolsLeft;
        private TimeSpan lastSaved;
        private bool acceptInput;
        private Level currentLevel { get; set;}
        private Level[] levelOrder;
        private gameMode gameMode { get; set; }
        private gameScreen gameState { get; set; }

        //Challenge mode vars

        //Settings vars

        public GameManager(int difficulty, int obolsLeft) {

            this.difficulty = difficulty;
            this.obolsLeft = obolsLeft;
            this.acceptInput = false;
        }

        private void generateLevels() {

            //levelOrder[0] = new Level();


        }

        public void Update(GameTime gameTime) {

            if (acceptInput) {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                    Console.WriteLine("quit");
                } else {

                }

            } else {

                showSplashAnimation(gameTime);

            }

        }

        private void showSplashAnimation(GameTime gameTime) {

            if (gameTime.TotalGameTime.TotalSeconds >= 5) {
                Console.WriteLine("input enabled");
                acceptInput = true;
            }

        }

    }
}