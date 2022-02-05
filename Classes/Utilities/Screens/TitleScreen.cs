using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class TitleScreen : Screen {

    private UIText knockText;

    public TitleScreen(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) : base(bgImg, gd, cm, gm) {

      int sbHeight = 25;
      int sbY = (int)((int)gd.Viewport.Height - (sbHeight * 2));

      knockText = new UIText("knockTag", "Press Space to knock", 0, sbY, Color.Honeydew);
      timer = 0;

    }

    public override void Draw(GameTime gameTime) {


      spriteBatch.Begin();
      spriteBatch.Draw(background, mainScreen, Color.White);
      spriteBatch.End();

      knockText.Draw(spriteBatch);

    }

    public override void LoadContent() {

      spriteFont = content.Load<SpriteFont>("mainFont");

      spriteBatch = new SpriteBatch(graphicsDevice);
      background = content.Load<Texture2D>(bgImg);
      mainScreen = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);


      Vector2 fontVector = spriteFont.MeasureString(knockText.value);
      knockText.x = (graphicsDevice.Viewport.Width / 2) - (fontVector.X / 2);

      knockText.LoadContent(spriteFont);
    }

    public override void Update(GameTime gameTime) {

      if(timer >=0.55) {
        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
          Console.WriteLine("moved to menu");
          gameManager.changeScreen(gameScreen.mainMenu);
        } else if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
          Console.WriteLine("exiting game");
          gameManager.quit();
        }

      } else {
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
      }
    }
  }
}