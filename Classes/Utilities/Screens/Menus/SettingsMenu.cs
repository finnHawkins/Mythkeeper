using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {

  public enum settingAction {
    toggle,
    increase,
    decrease
  }

  public class SettingsMenu : MenuScreen {

    private List<UIText> settingConfigText;
    public SettingsMenu(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) : base(bgImg, gd, cm, gm) {

      int textX = (int)((int) gd.Viewport.Width * 0.1);

      menuObjects = new List<UIObject> {
        new UIText("controls", "View Controls", textX, 25, Color.White, false),
        new UIText("language", "Language", textX, 100, Color.White, false),
        new UIText("music", "Music Volume", textX, 175, Color.White, false),
        new UIText("fx", "FX Volume", textX, 250, Color.White, false),
        new UIText("windowed", "Window Mode", textX, 325, Color.White, false),
        new UIText("doors", "Highlight Doors", textX, 400, Color.White, false)

      };

      textX = (int)((int)graphicsDevice.Viewport.Width * 0.9);

      settingConfigText = new List<UIText> {
        new UIText("controlText", "", textX, 25, Color.White, false),
        new UIText("languageSlider", "< English >", textX, 100, Color.White, false),
        new UIText("musicSlider", "< 100 >", textX, 175, Color.White, false),
        new UIText("fxSlider", "< 100 >", textX, 250, Color.White, false),
        new UIText("windowedToggle", "< Windowed >", textX, 325, Color.White, false),
        new UIText("doorsToggle", "< Yes >", textX, 400, Color.White, false)

      };

      timer = INPUT_DELAY;
      selectedButtonIndex = 0;
    }

    public override void Draw(GameTime gameTime) {

      spriteBatch.Begin();
      spriteBatch.Draw(background, mainScreen, Color.White);
      spriteBatch.End();

      foreach (UIText txt in menuObjects) {
        txt.Draw(spriteBatch);
      }
      foreach (UIText txt in settingConfigText) {
        txt.Draw(spriteBatch);
      }
    }

    public override void LoadContent() {

      spriteBatch = new SpriteBatch(graphicsDevice);
      background = content.Load<Texture2D>(bgImg);
      mainScreen = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      menuObjects[0].toggleSelect();
      settingConfigText[0].toggleSelect();


      foreach (UIText txt in menuObjects) {
        txt.LoadContent(spriteFont, graphicsDevice);
      }

      Vector2 fontVector;

      foreach (UIText txt in settingConfigText) {

          fontVector = spriteFont.MeasureString(txt.value);
          txt.x -= fontVector.X;

        txt.LoadContent(spriteFont, graphicsDevice);
      }
    }

    public override void Update(GameTime gameTime) {

      KeyboardState kbState = Keyboard.GetState();
      if (timer == 0) {

        int indexModifier = 0;
        bool changeIndex = false;

        if (kbState.IsKeyDown(Keys.Escape)) {

          gameManager.changeScreen(gameScreen.mainMenu);

        } else if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right)|| GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight)) {

          optionHandler(selectedButtonIndex, settingAction.increase);

        } else if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft)) {

          optionHandler(selectedButtonIndex, settingAction.decrease);

        } else if (kbState.IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A)) {

          optionHandler(selectedButtonIndex, settingAction.toggle);

        } else if (kbState.IsKeyDown(Keys.S) || kbState.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown)) {

          if (selectedButtonIndex < menuObjects.Count - 1) {
            indexModifier = 1;
            changeIndex = true;
          }

      } else if (kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickUp) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadUp)) {

        if (selectedButtonIndex > 0) {
          indexModifier = -1;
          changeIndex |= true;
        }

      }

        if (changeIndex) {

          menuObjects[selectedButtonIndex].toggleSelect();
          settingConfigText[selectedButtonIndex].toggleSelect();

          int newIndex = selectedButtonIndex += indexModifier;

          menuObjects[newIndex].toggleSelect();
          settingConfigText[newIndex].toggleSelect();

          this.timer = INPUT_DELAY;
        }

      } else {
        if (timer <= 0) {
          timer = 0;
          Console.WriteLine("input allowed");
        } else {
          this.timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
      }

    }

    public void optionHandler(int optionIndex, settingAction action) {

      switch (optionIndex) {
        case 0:
          gameManager.changeScreen(gameScreen.keybindDisplay);
          break;
        case 1:
          gameManager.changeLanguage(language.english);
          break;
        case 2:
          if (action == settingAction.decrease) {
            gameManager.changeVolume(1, -5);
          } else {
            gameManager.changeVolume(1, 5);
          }
          break;
        case 3:
          if (action == settingAction.decrease) {
            gameManager.changeVolume(2, -5);
          } else {
            gameManager.changeVolume(2, 5);
          }
          break;
        case 4:
          gameManager.toggleFS();
          break;
        case 5:
          gameManager.toggleDoorGuides();
          break;

      }

      timer = INPUT_DELAY;

    }
  }
}
