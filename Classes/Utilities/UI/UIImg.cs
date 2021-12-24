using Microsoft.Xna.Framework;
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
    /// Whether the text value should be shown alongside image
    /// </summary>
    private bool showVal { get; set; }

    /// <summary>
    /// Where in relation to the image the text should be
    /// if the image is the centre in a 3x3 grid.
    /// Set to 0 if showVal is false.
    /// </summary>
    private int textPosition { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UItag"></param>
    /// <param name="val"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="showVal"></param>
    /// <param name="fontColour"></param>
    public UIImg(String UItag, String val, int w, int h, int x, int y, bool showVal, Color fontColour) : base(UItag, val, x, y, fontColour) {

      this.showVal = showVal;
      width = w;
      height = h;

    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    /// <param name="gd">Graphics device to allow creation of a new spritebatch.</param>
    public override void LoadContent(SpriteFont sf, GraphicsDevice gd) {

      spriteBatch = new SpriteBatch(gd);
      font = sf;

    }

    public override void Draw() {

    }

  }
}
