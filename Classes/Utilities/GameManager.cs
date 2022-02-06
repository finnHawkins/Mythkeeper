using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

  public enum language {
    english,
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
    keybindDisplay,
    credits,
    pauseMenu,
    loading,
    death
  }

  /// <summary>
  /// Game Manager class
  /// </summary>
  public class GameManager {

    private GraphicsDevice graphicsDevice;
    private Player player;
    public static ContentManager content;
    private MKGame game;

    private Level currentLevel;
    private List<Level> levelOrder;

    private language language;

    private int difficulty;
    private int obolsLeft;
    private TimeSpan lastSaved;
    private float timer;
    private bool displayTimer;
    private bool displayScore;
    private bool highlightDoors;
    private int saveFileNo;

    private int musicVolume;
    private int fxVolume;

    private gameScreen gameScreen;
    private gameMode gameMode;
    protected Screen screen;


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

    public GameManager(GraphicsDevice gd, ContentManager cm, MKGame game) {

      graphicsDevice = gd;
      player = new Player(gd);
      currentLevel = new Level(gd);
      content = cm;
      this.game = game;

      gameScreen = gameScreen.splashScreen;
      gameMode = gameMode.normal;

      gameTimer = new UIText("timer", "", gd.Viewport.Width - 125, gd.Viewport.Y, Color.DarkOrchid, false);
      score = new UIText("score", "Score: 0", gd.Viewport.Width - 125, gd.Viewport.Y + 15, Color.DarkOrchid, false);
      progress = new UIBar("progress", 15, 150, gd.Viewport.Width - 20, 90, 100, 75, true, Color.Honeydew);
      essence = new UIImg("essence", 35, 35, 0, 45, "UI\\essence", content);
      obols = new UIImg("obols", 35, 35, 155, 5, "UI\\obol", content);

      screen = new SplashScreen("rooms\\splashscreen", graphicsDevice, content, this);

      readRoomFile();

    }

    public void LoadContent() {

      spriteBatch = new SpriteBatch(graphicsDevice);
      spriteFont = content.Load<SpriteFont>("UI\\mainFont");

      //UIBar is the only class that needs a graphicsDevice parameter, the rest only need a spritefont
      gameTimer.LoadContent(spriteFont, graphicsDevice);
      score.LoadContent(spriteFont, graphicsDevice);
      progress.LoadContent(spriteFont, graphicsDevice);
      essence.LoadContent(spriteFont);
      obols.LoadContent(spriteFont);

      screen.LoadContent();
      //currentLevel.LoadContent();
      player.LoadContent();

    }

    public void Draw(GameTime gt) {


      screen.Draw(gt);
     // currentLevel.Draw(gt);

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
          //essence.Draw(spriteBatch);
          //obols.Draw(spriteBatch);
          //player.Draw();

          break;
        case gameMode.hardcore:
          //progress.Draw(spriteBatch);
          //essence.Draw(spriteBatch);
          //player.Draw();
          break;


      }

    }

    public void Update(GameTime gameTime) {

      switch (gameScreen) {
        case gameScreen.splashScreen:
        case gameScreen.title:
        case gameScreen.mainMenu:
        case gameScreen.credits:
        case gameScreen.mainSetting:

          screen.Update(gameTime);
          break;

        case gameScreen.saveFile:
          break;
        case gameScreen.levelScreen:

          player.Update(gameTime);
          gameTimer.value = gameTime.TotalGameTime.ToString();
          break;

        case gameScreen.keybindDisplay:
          break;
        case gameScreen.pauseMenu:
          break;
        case gameScreen.loading:
          break;
        case gameScreen.death:
          break;
      }

    }
    private void generateLevels() {

      //levelOrder[0] = new Level();


    }

    public void changeScreen(gameScreen gameScreen) {

      this.gameScreen = gameScreen;

      switch (gameScreen) {
        case gameScreen.title:
          screen = new TitleScreen("rooms\\castledoors", graphicsDevice, content, this);
          screen.LoadContent();
          break;
        case gameScreen.mainMenu:
          screen = new MainMenu("rooms\\mansion", graphicsDevice, content, this);
          screen.LoadContent();
          break;
        case gameScreen.saveFile:
          Console.WriteLine("loading save file screen...");

          break;
        case gameScreen.levelScreen:
          Console.WriteLine("loading game screen...");
          break;
        case gameScreen.mainSetting:
          screen = new SettingsMenu("rooms\\castleWall", graphicsDevice, content, this);
          screen.LoadContent();
          break;
        case gameScreen.keybindDisplay:
          Console.WriteLine("loading keybind screen...");
          break;
        case gameScreen.credits:
          Console.WriteLine("loading credits screen...");
          screen = new CreditScreen("rooms\\castleWall", graphicsDevice, content, this);
          screen.LoadContent();
          break;
        case gameScreen.pauseMenu:
          break;
        case gameScreen.loading:
          break;
        case gameScreen.death:
          break;
      }
    }

    public void quit() {
      game.endGame();
    }

    public void toggleFS() {
      Console.WriteLine("toggling fullscreeen");
      game.toggleFullScreen();
    }

    private static void generateSeed() {



    }

    public void toggleDoorGuides() {
      Console.WriteLine("toggling door highlighting");
      highlightDoors = !highlightDoors;
    }

    public void changeLanguage(language lang) {

      Console.WriteLine("changing language");
      language = lang;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="volume">1 for music, 2 for sfx</param>
    /// <param name="modifier"></param>
    public void changeVolume(int volume, int modifier) {
      if(volume == 1) {
        musicVolume += modifier;
        Console.Write("Music: ");

        if (musicVolume > 100) {
          musicVolume = 100;
        } else if (musicVolume < 0) {
          musicVolume = 0;
        }

      } else {
        fxVolume += modifier;
        Console.Write("SFX: ");

        if (fxVolume > 100) {
          fxVolume = 100;
        } else if (fxVolume < 0) {
          fxVolume = 0;
        }

      }
      Console.Write("changed volume by " + modifier);
    }

    private static void readRoomFile() {

      try {

        Stream stream = TitleContainer.OpenStream("Content/rooms.xml");

        string rooms = "";

        using (StreamReader reader = new System.IO.StreamReader(stream)) {
          rooms = reader.ReadToEnd();
        }

        //XElement element;

        //Console.WriteLine(rooms);

      } catch (System.IO.FileNotFoundException) {

        Console.WriteLine("rooms.xml not found!");

      }

    }
  }
}
