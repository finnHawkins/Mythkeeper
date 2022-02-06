using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class SplashScreen : Screen {

    private UIBar skipCutsceneBar;
    private UIText skipText;

    private static double SKIP_TIME = 1;

    public SplashScreen(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) : base(bgImg, gd, cm, gm) {

      int sbHeight = 25;
      int sbWidth = (int)((int) gd.Viewport.Width * 0.9);

      int sbX = (int)((int)gd.Viewport.Width * 0.05);
      int sbY = (int)((int)gd.Viewport.Height - (sbHeight * 2));

      skipCutsceneBar = new UIBar("skipCS", sbWidth, sbHeight, sbX, sbY, SKIP_TIME, 0, false, Color.Honeydew);
      skipText = new UIText("skipTag", "Hold space to skip cutscene", 0, (sbY - 50), Color.Honeydew, true);
    }

    public override void Draw(GameTime gameTime) {


      spriteBatch.Begin();
      spriteBatch.Draw(background, mainScreen, Color.White);
      spriteBatch.End();

      skipCutsceneBar.Draw(spriteBatch);
      skipText.Draw(spriteBatch);

    }

    public override void LoadContent() {

      spriteBatch = new SpriteBatch(graphicsDevice);
      background = content.Load<Texture2D>(bgImg);
      mainScreen = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      skipCutsceneBar.LoadContent(spriteFont, graphicsDevice);
      skipText.LoadContent(spriteFont, graphicsDevice);

    }

    public override void Update(GameTime gameTime) {
      if (gameTime.TotalGameTime.TotalSeconds >= 5) {
        gameManager.changeScreen(gameScreen.title);
        Console.WriteLine("cutscene ended");
      } else {
        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
          this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
          skipCutsceneBar.setCurrentVal(timer);
          if (this.timer >= SKIP_TIME) {
            Console.WriteLine("skipped cutscene");
            gameManager.changeScreen(gameScreen.title);
            this.timer = 0;
          }
        } else {
          this.timer = 0;
          skipCutsceneBar.setCurrentVal(timer);

        }
      }
    }

  }
}
