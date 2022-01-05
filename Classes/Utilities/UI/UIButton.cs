using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public class UIButton : UIObject {

    private int width { get;set;}
    private int height { get;set;}

    private Texture2D btnImg;
    private readonly ContentManager content;

    public UIButton(String UItag, String val, int x, int y, Color fontColour, ContentManager cm, int w = 100, int h = 28) : base(UItag, val, x, y, fontColour) {

      width = w;
      height = h;
      content = cm;

    }

    public override void LoadContent(SpriteFont sf, GraphicsDevice gd) {

      spriteBatch = new SpriteBatch(gd);

      font = sf;
      btnImg = content.Load<Texture2D>("UI\\btn");

    }

    public override void Draw() {

      spriteBatch.Begin();

      Rectangle pos = new Rectangle((int)x, (int)y, width, height);

      Vector2 fontVector = font.MeasureString(value);
      Vector2 txtPos = new Vector2(x + ((width / 2) - (fontVector.X / 2)), y + (height - (fontVector.Y)));

      spriteBatch.Draw(btnImg, pos, Color.White);
      spriteBatch.DrawString(font, value, txtPos, fontColour);

      spriteBatch.End();

    }

  }
}
