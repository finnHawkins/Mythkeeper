using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class UIText : UIObject {

    Color selectedColour;
    Boolean centreText;

    /// <summary>
    /// Constructor for UI text element.
    /// </summary>
    /// <param name="UItag">Identifier for text element, e.g. <c>timer</c> or <c>score</c>.</param>
    /// <param name="val">Actual value to be shown by text, e.g. Score: 100.</param>
    /// <param name="x">X coordinate of element.</param>
    /// <param name="y">Y coordinate of element.</param>
    /// <param name="fontColour">Text colour.</param>
    public UIText(String UItag, String val, int x, int y, Color fontColour, bool centreText) : base(UItag, val, x, y, fontColour) {
      this.selectedColour = Color.SkyBlue;
      this.centreText = centreText;
      this.selected = false;
    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    public override void LoadContent(SpriteFont sf) {

      Console.WriteLine(UItag + ": wrong LoadContent call, dickhead");

    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    /// <param name="gd">Graphics device to allow creation of a new spritebatch.</param>
    public override void LoadContent(SpriteFont sf, GraphicsDevice gd) {

      font = sf;

      if (centreText) {
        Vector2 fontVector = font.MeasureString(value);
        x = (gd.Viewport.Width / 2) - (fontVector.X / 2);
      }
    }

    /// <summary>
    /// Draws the text element at the position provided by parameters.
    /// </summary>
    public override void Draw(SpriteBatch spriteBatch) {

      spriteBatch.Begin();
      Vector2 position = new Vector2(x, y);

      if (selected) {
        spriteBatch.DrawString(font, value, position, selectedColour, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
      } else {
        spriteBatch.DrawString(font, value, position, fontColour, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
      }

      spriteBatch.End();

    }

  }
}
