using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class UIImg : UIObject {

    /// <summary>
    /// Width of image.
    /// </summary>
    private int width { get; set; }

    /// <summary>
    /// Height of image.
    /// </summary>
    private int height { get; set; }

    /// <summary>
    /// Where in relation to the image the text should be
    /// if the image is the centre in a 3x3 grid.
    /// Set to 0 if showVal is false.
    /// </summary>
    private int textPosition { get; set; }

    private string imgLocation { get; set; }
    private Texture2D img { get; set; }

    private readonly ContentManager content;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UItag"></param>
    /// <param name="val"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="fontColour"></param>
    public UIImg(String UItag, int w, int h, int x, int y, string textureLocation, ContentManager cm) : base(UItag, x, y) {

      width = w;
      height = h;
      imgLocation = textureLocation;
      content = cm;


    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    /// <param name="gd">Graphics device to allow creation of a new spritebatch.</param>
    public override void LoadContent(SpriteFont sf, GraphicsDevice gd) {

      spriteBatch = new SpriteBatch(gd);
      font = sf;

      img = content.Load<Texture2D>(imgLocation);
      

    }

    public override void Draw() {

      spriteBatch.Begin();

      Rectangle pos = new Rectangle((int)x, (int)y, width, height);

      spriteBatch.Draw(img, pos, Color.White);

      spriteBatch.End();

    }

  }
}
