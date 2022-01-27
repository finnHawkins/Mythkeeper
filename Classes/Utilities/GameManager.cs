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
    loading,
    death
  }

  /// <summary>
  /// Game Manager class
  /// </summary>
  class GameManager {

    private GraphicsDevice graphicsDevice;
    private Player player;
    public static ContentManager content;

    private Level currentLevel { get; set; }
    private Level[] levelOrder;

    private int difficulty;
    private int obolsLeft;
    private TimeSpan lastSaved;
    private float timer;
    private bool displayTimer;
    private bool displayScore;

    private gameScreen gameScreen;
    private gameMode gameMode;

    private SpriteBatch spriteBatch;
    private SpriteFont spriteFont;

    //Challenge mode vars

    //Settings vars

    //UI elements
    UIText gameTimer;
    UIText score;
    UIBar progress;
    UIImg essence;
    UIImg obols;

    public GameManager(GraphicsDevice gd, ContentManager cm) {

      graphicsDevice = gd;
      player = new Player(gd);
      currentLevel = new Level(gd);
      content = cm;

      gameScreen = gameScreen.splashScreen;
      gameMode = gameMode.normal;

      gameTimer = new UIText("timer", "", gd.Viewport.Width - 125, gd.Viewport.Y, Color.DarkOrchid);
      score = new UIText("score", "Score: 0", gd.Viewport.Width - 125, gd.Viewport.Y + 15, Color.DarkOrchid);
      progress = new UIBar("progress", 15, 150, gd.Viewport.Width - 20, 90, 100, 75, true, Color.Honeydew);
      essence = new UIImg("essence", 35, 35, 0, 45, "UI\\essence", content);
      obols = new UIImg("obols", 35, 35, 155, 5, "UI\\obol", content);

    }

    public void LoadContent() {

      spriteBatch = new SpriteBatch(graphicsDevice);
      spriteFont = content.Load<SpriteFont>("mainFont");

      //UIBar is the only class that needs a graphicsDevice parameter, the rest only need a spritefont
      gameTimer.LoadContent(spriteFont);
      score.LoadContent(spriteFont);
      progress.LoadContent(spriteFont, graphicsDevice);
      essence.LoadContent(spriteFont);
      obols.LoadContent(spriteFont);


      currentLevel.LoadContent();
      player.LoadContent();

    }

    public void Draw(GameTime gt) {

      currentLevel.Draw(gt);

      if (displayTimer) {
        gameTimer.Draw(spriteBatch);
      }
      if (displayScore) {
        score.Draw(spriteBatch);
      }

      switch (gameMode) {

        case gameMode.normal:
        case gameMode.bossRush:
        case gameMode.timed:
        case gameMode.corruption:
          //progress.Draw(spriteBatch);
          essence.Draw(spriteBatch);
          obols.Draw(spriteBatch);
          break;
        case gameMode.hardcore:
          //progress.Draw(spriteBatch);
          essence.Draw(spriteBatch);
          break;

      }

      if (gameScreen == gameScreen.splashScreen && Keyboard.GetState().IsKeyDown(Keys.Space)) {
        progress.Draw(spriteBatch);
      } else {

      }

      player.Draw();

    }

    public void Update(GameTime gameTime, MKGame game) {

      switch (gameScreen) {
        case gameScreen.splashScreen:
          showSplashAnimation(gameTime);
          break;
        case gameScreen.title:
          break;
        case gameScreen.mainMenu:
          break;
        case gameScreen.saveFile:
          break;
        case gameScreen.levelScreen:
          break;
        case gameScreen.mainSetting:
          break;
        case gameScreen.inputSettings:
          break;
        case gameScreen.audioSettings:
          break;
        case gameScreen.graphicsSettings:
          break;
        case gameScreen.credits:
          break;
        case gameScreen.pauseMenu:
          break;
        case gameScreen.loading:
          break;
        case gameScreen.death:
          break;
      }

      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
        //save game
        //quit game
        game.endGame();

      }

      player.Update(gameTime);

      gameTimer.value = gameTime.TotalGameTime.ToString();

    }
    private void generateLevels() {

      //levelOrder[0] = new Level();


    }

    private void showSplashAnimation(GameTime gameTime) {

      if (gameTime.TotalGameTime.TotalSeconds >= 5) {

        gameScreen = gameScreen.title;
        Console.WriteLine("cutscene ended");

      } else {

        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {

          this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
          progress.setMaxVal(1.25);
          progress.setCurrentVal(timer);

          if (this.timer >= 1.25) {
            Console.WriteLine("skipped cutscene");
            gameScreen = gameScreen.title;
            this.timer = 0;
          }

        } else {
          this.timer = 0;
        }


      }

    }
  }
}
