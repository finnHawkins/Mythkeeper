using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public abstract class Screen {

    public const double INPUT_DELAY = 0.15;

    protected Texture2D background;
    protected Rectangle mainScreen;
    protected readonly ContentManager content;
    protected string bgImg;
    protected double timer;
    protected GraphicsDevice graphicsDevice;
    protected SpriteBatch spriteBatch;
    protected SpriteFont spriteFont;
    protected GameManager gameManager;

    public Screen(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) {
      this.bgImg = bgImg;
      graphicsDevice = gd;
      content = cm;
      gameManager = gm;

      spriteFont = cm.Load<SpriteFont>("UI\\mainFont");

    }

    public abstract void LoadContent();
    public abstract void Draw(GameTime gameTime);
    public abstract void Update(GameTime gameTime);

  }
}
