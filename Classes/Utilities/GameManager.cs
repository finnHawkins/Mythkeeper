using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
    splashScreen,
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

    private GraphicsDevice graphicsDevice;
    private Player player;
    private UIManager uiManager;
    public static ContentManager content;

    private Level currentLevel { get; set; }
    private Level[] levelOrder;

    private int difficulty;
    private int obolsLeft;
    private TimeSpan lastSaved;
    private float timer;
    private bool acceptInput;
    private gameScreen gameScreen;
    private gameMode gameMode;

    //Challenge mode vars

    //Settings vars

    public GameManager(GraphicsDevice gd, ContentManager cm) {

      graphicsDevice = gd;
      player = new Player(gd);
      currentLevel = new Level(gd);
      uiManager = new UIManager(gd, cm);
      content = cm;

      gameScreen = gameScreen.splashScreen;
      
      //this.acceptInput = false;
    }

    public void LoadContent() {

      currentLevel.LoadContent();
      player.LoadContent();
      uiManager.LoadContent();


    }

    public void Draw(GameTime gt) {

      currentLevel.Draw(gt);
      player.Draw();
      uiManager.Draw();

    }

    public void Update(GameTime gameTime, MKGame game) {

      player.Update(gameTime);
      uiManager.Update(gameTime);

      UIText timer = uiManager.getTimer();
      timer.value = gameTime.TotalGameTime.ToString();

      if (gameScreen == gameScreen.splashScreen) {

        if (gameTime.TotalGameTime.TotalSeconds >= 5) {

          gameScreen = gameScreen.title;

        } else {

          if (Keyboard.GetState().IsKeyDown(Keys.Space)) {

            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.timer >= 1.25) {
              Console.WriteLine("skipped cutscene");
              gameScreen = gameScreen.title;
              this.timer = 0;
            }

          } else {
            this.timer = 0;
          }

        }

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
          //save game
          //quit game
          game.endGame();

        } else {

          showSplashAnimation(gameTime);

        }

      }

    }
    private void generateLevels() {

      //levelOrder[0] = new Level();


    }

    private void showSplashAnimation(GameTime gameTime) {

      if (gameTime.TotalGameTime.TotalSeconds >= 5) {
        Console.WriteLine("input enabled");
        acceptInput = true;
      }

    }

  }
}
