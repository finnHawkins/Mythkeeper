using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public class UIButton : UIObject {

    public event EventHandler ButtonClicked;

    private int width { get;set;}
    private int height { get;set;}

    private Texture2D btnImg;
    private Texture2D btnPressedImg;
    private Rectangle position;
    private readonly ContentManager content;

    public UIButton(String UItag, String val, int x, int y, Color fontColour, ContentManager cm, int w = 200, int h = 50) : base(UItag, val, x, y, fontColour) {

      width = w;
      height = h;
      content = cm;
      selected = false;

    }
    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    public override void LoadContent(SpriteFont sf) {

      font = sf;
      btnImg = content.Load<Texture2D>("UI\\btn");
      btnPressedImg = content.Load<Texture2D>("UI\\btnPressed");

      position = new Rectangle((int)x, (int)y, width, height);

    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    /// <param name="gd">Graphics device to allow creation of a new spritebatch.</param>
    public override void LoadContent(SpriteFont sf, GraphicsDevice gd) {
      Console.WriteLine(UItag + ": wrong LoadContent call, dickhead");
    }

    public override void Draw(SpriteBatch spriteBatch) {

      spriteBatch.Begin();

      Vector2 fontVector = font.MeasureString(value);
      Vector2 txtPos = new Vector2(x + ((width / 2) - (fontVector.X / 2)), y + ((height / 2) - (fontVector.Y / 2)));

      if (selected) {
        spriteBatch.Draw(btnPressedImg, position, Color.White);
      } else {
        spriteBatch.Draw(btnImg, position, Color.White);
      }

      spriteBatch.DrawString(font, value, txtPos, fontColour);

      spriteBatch.End();

    }

    public void Update() {

      if (selected) {
        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
          var ev = ButtonClicked;
          if (ev != null) {
            ev(this, EventArgs.Empty);
          }
        }
      }

    }

  }
}
