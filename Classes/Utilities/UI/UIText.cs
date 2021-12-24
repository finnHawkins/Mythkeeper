using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class UIText : UIObject {

    /// <summary>
    /// Constructor for UI text element
    /// </summary>
    /// <param name="UItag">Identifier for text element, e.g. <c>timer</c> or <c>score</c>.</param>
    /// <param name="val">Actual value to be shown by text, e.g. Score: 100</param>
    /// <param name="x">X coordinate of element.</param>
    /// <param name="y">Y coordinate of element.</param>
    /// <param name="fontColour">Text colour.</param>
    public UIText(String UItag, String val, int x, int y, Color fontColour) : base(UItag, val, x, y, fontColour) {

    }

    /// <summary>
    /// Draws the text element at the position provided by parameters.
    /// </summary>
    public override void Draw() {

      spriteBatch.Begin();
      Vector2 position = new Vector2(x, y);
      spriteBatch.DrawString(font, value, position, fontColour, 0, new Vector2(0,0), 1.0f, SpriteEffects.None, 0.5f);
      spriteBatch.End();

    }

  }
}
