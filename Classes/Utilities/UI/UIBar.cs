using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class UIBar : UIObject {

    private int width { get; set; }
    private int height { get; set; }
    private float maxVal { get; set; }
    private float currentVal { get; set; }

    public UIBar(String UItag, String val, int w, int h, int x, int y, float maxVal, float currentVal, Color fontColour) : base(UItag, val, x, y, fontColour) {

      this.maxVal = maxVal;
      this.currentVal = currentVal;
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
