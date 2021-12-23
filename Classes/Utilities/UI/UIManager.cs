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


    public UIManager(GraphicsDevice gd) {

      graphicDevice = gd;
      content = MKGame.GetNewContentManagerInstance();

      UIObjects = new List<UIObject>();

      UIObjects.Add(new UIButton(12, 12, 12, 12, "hello"));
      UIObjects.Add(new UIText(12, 12, "stinky"));
      UIObjects.Add(new UIBar(64, 64, 12, 12, "health"));
      UIObjects.Add(new UIButton(12, 12, 12, 12, "beans"));

    }

    public void LoadContent() {

      spriteBatch = new SpriteBatch(graphicDevice);
      spriteFont = content.Load<SpriteFont>("mainFont");

    }

    public void Draw() {

      spriteBatch.Begin();
      // Finds the center of the string in coordinates inside the text rectangle
      Vector2 textMiddlePoint = spriteFont.MeasureString("hello world") / 2;
      // Places text in center of the screen
      Vector2 position = new Vector2(64,12);
      spriteBatch.DrawString(spriteFont, "MonoGame Font Test", position, Color.White, 0, textMiddlePoint, 1.0f, SpriteEffects.None, 0.5f);
      spriteBatch.End();

    }

    public void Update(GameTime gameTime) {

      foreach (UIObject obj in UIObjects) {

        string value = obj.UIval;

        Console.WriteLine(value);



      }

    }




    }
  }
