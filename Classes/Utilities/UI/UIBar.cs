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
    private Texture2D fullBar { get; set; }
    private Texture2D emptyBar { get; set; }
    private Color color { get; set; }
    private bool isVertical { get; set; }


    public UIBar(String UItag, int w, int h, int x, int y, float maxVal, float currentVal, bool isVertical, Color barColour) : base(UItag, x, y) {

      this.maxVal = maxVal;
      this.currentVal = currentVal;
      width = w;
      height = h;
      color = barColour;
      this.isVertical = isVertical;

    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    /// <param name="gd">Graphics device to allow creation of a new spritebatch.</param>
    public override void LoadContent(SpriteFont sf, GraphicsDevice gd) {

      spriteBatch = new SpriteBatch(gd);
      font = sf;
      fullBar = new Texture2D(gd, width, height);
      emptyBar = new Texture2D(gd, width, height);


      Color[] data = new Color[width * height];
      for (int i = 0; i < data.Length; ++i) data[i] = Color.Silver;
      emptyBar.SetData(data);

      for (int i = 0; i < data.Length; ++i) data[i] = color;
      fullBar.SetData(data);

    }

    public override void Draw() {

      spriteBatch.Begin();

      Rectangle barPos = new Rectangle((int) x, (int) y, width, height);

      float barPercent = currentVal / maxVal;
      Rectangle barContentPos = new Rectangle();

      if (isVertical) {

        int barHeight = (int)(height * barPercent);
        barContentPos = new Rectangle((int) x, (int) y + (height - barHeight), width, barHeight);

      } else {

        barContentPos = new Rectangle((int) x, (int) y, (int)(width * barPercent), height);

      }

      spriteBatch.Draw(emptyBar, barPos, Color.White);
      spriteBatch.Draw(fullBar, barContentPos, Color.White);

      spriteBatch.End();

    }

  }
}
