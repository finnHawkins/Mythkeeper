using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public class UIButton : UIObject {

    private int width { get;set;}
    private int height { get;set;}

    private Texture2D btnImg;
    private Rectangle position;
    private readonly ContentManager content;

    public UIButton(String UItag, String val, int x, int y, Color fontColour, ContentManager cm, int w = 100, int h = 28) : base(UItag, val, x, y, fontColour) {

      width = w;
      height = h;
      content = cm;

    }
    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    public override void LoadContent(SpriteFont sf) {

      font = sf;
      btnImg = content.Load<Texture2D>("UI\\btn");

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
      Vector2 txtPos = new Vector2(x + ((width / 2) - (fontVector.X / 2)), y + (height - (fontVector.Y)));

      spriteBatch.Draw(btnImg, position, Color.White);
      spriteBatch.DrawString(font, value, txtPos, fontColour);

      spriteBatch.End();

    }

    public void Update() {

      var mouseState = Mouse.GetState();

      var mouseLoc = new Point(mouseState.X, mouseState.Y);

      if(position.Contains(mouseLoc)) {

        Console.WriteLine("MOUSE OVER BUTTON " + UItag);

      }

    }

    public void Click() {



    }

  }
}
