using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sun.net.www.content.text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public abstract class UIObject {

    /// <summary>
    ///  values <c>health</c>, <c>stamina</c>, <c>essence</c> (may be changed in future),<c>progress</c>
    ///  are reserved for UIBars containing the amount of each one the player has. <c>timer</c> is reserved
    ///  for the speedrun timer.
    /// </summary>
    public string UItag { get; set; }
    public string value { get; set; }
    public float x { get; set; }
    public float y { get; set; }
    public float scale { get; set; }

    /// <summary>
    /// stores the fonts and spritebatch required to draw text
    /// </summary>
    public SpriteFont font { get; set; }
    public SpriteBatch spriteBatch;
    public Color fontColour;

    /// <summary>
    /// Creates a generic UI object
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

    /// <summary>
    /// Loads the required content so the UI element can be draw
    /// </summary>
    /// <param name="sf">Spritefont to be used for drawing text</param>
    /// <param name="gd">graphics device to allow creation of a new spritebatch</param>
    public void LoadContent(SpriteFont sf, GraphicsDevice gd) {

      spriteBatch = new SpriteBatch(gd);
      font = sf;

    }

    /// <summary>
    /// Draws the UI element to the screen
    /// </summary>
    public abstract void Draw();

  }
}
