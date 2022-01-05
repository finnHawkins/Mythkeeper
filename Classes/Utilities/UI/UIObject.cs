using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sun.net.www.content.text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public abstract class UIObject {

    /// <summary>
    /// Reserved values: <c>health</c>, <c>stamina</c>, <c>essence</c>,<c>progress</c>,
    /// <c>timer</c>, <c>obols</c>.
    /// Stores a string value to identify it from other UI elements.
    /// </summary>
    public string UItag { get; set; }

    /// <summary>
    /// Value to be displayed on-screen.
    /// </summary>
    public string value { get; set; }

    /// <summary>
    /// X co-ordinate of element.
    /// </summary>
    public float x { get; set; }

    /// <summary>
    /// Y co-ordinate of element.
    /// </summary>
    public float y { get; set; }

    /// <summary>
    /// Scale of element.
    /// </summary>
    public float scale { get; set; }

    /// <summary>
    /// Stores the font required to draw text.
    /// </summary>
    public SpriteFont font { get; set; }

    /// <summary>
    /// Stores the spritebatch required to draw element/text.
    /// </summary>
    public SpriteBatch spriteBatch;

    /// <summary>
    /// Stores the font colour.
    /// </summary>
    public Color fontColour;

    /// <summary>
    /// Creates a generic UI object.
    /// </summary>
    /// <param name="UItag">Identifier for the UI element.</param>
    /// <param name="val">Value to be displayed on element.</param>
    /// <param name="x">X coordinate of element.</param>
    /// <param name="y">Y coordinate of element.</param>
    /// <param name="fontColour">The element's text colour.</param>
    /// <param name="scale">Scale of element (for different resolutions, not required).</param>
    public UIObject(string UItag, string val, float x, float y, Color fontColour, float scale = 1f) {

      this.UItag = UItag;
      this.value = val;
      this.x = x;
      this.y = y;
      this.scale = scale;
      this.fontColour = fontColour;

    }

    public UIObject(string UItag, float x, float y, float scale = 1f) {

      this.UItag = UItag;
      this.x = x;
      this.y = y;
      this.scale = scale;

    }

    /// <summary>
    /// Loads the required content so the UI element can be drawn.
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text.</param>
    /// <param name="gd">Graphics device to allow creation of a new spritebatch.</param>
    public abstract void LoadContent(SpriteFont sf, GraphicsDevice gd);

    /// <summary>
    /// Draws the UI element to the screen.
    /// </summary>
    public abstract void Draw();

  }
}
