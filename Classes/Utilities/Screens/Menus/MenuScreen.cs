using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public abstract class MenuScreen : Screen {

    protected List<UIObject> menuObjects;
    protected int selectedButtonIndex;

    public MenuScreen(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) : base(bgImg, gd, cm, gm) {

    }
  }
}
