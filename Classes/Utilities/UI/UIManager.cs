using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public class UIManager {

    private List<UIObject> UIObjects;
    private readonly ContentManager content;
    private SpriteBatch spriteBatch;
    private SpriteFont spriteFont;
    private GraphicsDevice graphicDevice;


    public UIManager(GraphicsDevice gd, ContentManager cm) {

      graphicDevice = gd;
      content = cm;

      UIObjects = new List<UIObject>();

      //UIObjects.Add(new UIButton("hello", "hello", 36, 36, Color.White, content));
      UIObjects.Add(new UIText("timer", "", graphicDevice.Viewport.Width - 125, graphicDevice.Viewport.Y, Color.DarkOrchid));
      UIObjects.Add(new UIText("score", "Score: 0", graphicDevice.Viewport.Width - 125, graphicDevice.Viewport.Y + 15, Color.DarkOrchid));
      UIObjects.Add(new UIBar("health", 150, 15, 0, 5, 100, 92, false, Color.Crimson));
      UIObjects.Add(new UIBar("stamina", 150, 15, 0, 22, 100, 100, false, Color.SeaGreen));
      UIObjects.Add(new UIBar("progress", 15, 150, graphicDevice.Viewport.Width - 20, 90, 100, 75, true, Color.Honeydew));
      UIObjects.Add(new UIImg("essence", 35, 35, 0, 45, "UI\\essence", content));
      UIObjects.Add(new UIImg("obols", 35, 35, 155, 5, "UI\\obol", content));



    }

    public void LoadContent() {

      spriteBatch = new SpriteBatch(graphicDevice);
      spriteFont = content.Load<SpriteFont>("mainFont");

      foreach (UIObject obj in UIObjects) {
        obj.LoadContent(spriteFont, graphicDevice);
      }

    }

    public void Draw() {

      foreach (UIObject obj in UIObjects) {
        obj.Draw();
      }

    }

    public void Update(GameTime gameTime) {

    }

    public UIBar getBarByTag(string tag) {

      UIBar bar = (UIBar) UIObjects.Find(x => x.UItag == tag);

      return bar;

    }

    public UIText getTimer() {
      return (UIText)UIObjects.Find(x => x.UItag == "timer");
    }

  }
}
