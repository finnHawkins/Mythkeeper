using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class CreditScreen : Screen {

    UIText creditText;

    public CreditScreen(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) : base(bgImg, gd, cm, gm) {

      string credits = "Programming: Finnski\n";
      credits += "Assets: *insert here*\n";
      credits += "Music: *insert here*\n";
      credits += "SFX: *insert here*\n";

      creditText = new UIText("creditText", credits, gd.Viewport.Width, gd.Viewport.Height, Color.Honeydew);

      timer = INPUT_DELAY;
    }

    public override void Draw(GameTime gameTime) {

      spriteBatch.Begin();
      spriteBatch.Draw(background, mainScreen, Color.White);
      spriteBatch.End();

      creditText.Draw(spriteBatch);
       
    }

    public override void LoadContent() {

      spriteFont = content.Load<SpriteFont>("mainFont");

      spriteBatch = new SpriteBatch(graphicsDevice);
      background = content.Load<Texture2D>(bgImg);
      mainScreen = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      Vector2 fontVector = spriteFont.MeasureString(creditText.value);
      creditText.x = (graphicsDevice.Viewport.Width / 2) - (fontVector.X / 2);
      creditText.y = (graphicsDevice.Viewport.Height / 2) - (fontVector.Y / 2);

      creditText.LoadContent(spriteFont);

    }

    public override void Update(GameTime gameTime) {

      KeyboardState kbState = Keyboard.GetState();
      if (timer == 0) {

        if (kbState.IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown)) {
         
          gameManager.changeScreen(gameScreen.mainMenu);
        
        }

      } else {
        if (timer <= 0) {
          timer = 0;
          Console.WriteLine("input allowed");
        } else {
          this.timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
      }

    }
  }
}
