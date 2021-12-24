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

      UIObjects.Add(new UIButton("hello", "hello", 36, 36, Color.White));
      //UIObjects.Add(new UIText("text", "Hello there", 64, 64, Color.Red));
      UIObjects.Add(new UIBar("health", "", 64, 64, 12, 12, 100, 100, Color.White));
      UIObjects.Add(new UIButton("beans", "beans", 200,20, Color.White));

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

      foreach (UIObject obj in UIObjects) {

        if (obj.UItag == "timer") {

          obj.value = gameTime.ElapsedGameTime.TotalSeconds.ToString();

        }

      }

    }




    }
  }
