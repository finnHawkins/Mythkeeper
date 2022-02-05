using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
  public class MainMenu : MenuScreen {
    public MainMenu(string bgImg, GraphicsDevice gd, ContentManager cm, GameManager gm) : base(bgImg, gd, cm, gm) {

      menuButtons = new List<UIButton> {
        new UIButton("continueBtn", "Continue", 30, 25, Color.White, cm),
        new UIButton("newGameBtn", "New Game", 30, 100, Color.White, cm),
        new UIButton("loadGameBtn", "Load Game", 30, 175, Color.White, cm),
        new UIButton("settingsBtn", "Settings", 30, 250, Color.White, cm),
        new UIButton("creditsBtn", "Credits", 30, 325, Color.White, cm),
        new UIButton("exitBtn", "Exit", 30, 400, Color.White, cm)

      };

      foreach (UIButton button in menuButtons) {
        button.ButtonClicked += buttonClickHandler;
      }

      timer = INPUT_DELAY;
      selectedButtonIndex = 0;
    }

    public override void Draw(GameTime gameTime) {

      spriteBatch.Begin();
      spriteBatch.Draw(background, mainScreen, Color.White);
      spriteBatch.End();

      foreach (UIButton button in menuButtons) {
        button.Draw(spriteBatch);
      }
    }

    public override void LoadContent() {

      spriteFont = content.Load<SpriteFont>("mainFont");

      spriteBatch = new SpriteBatch(graphicsDevice);
      background = content.Load<Texture2D>(bgImg);
      mainScreen = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      menuButtons[0].toggleSelect();

      foreach (UIButton button in menuButtons) {
        button.LoadContent(spriteFont);
      }
    }

    public override void Update(GameTime gameTime) {
       
      KeyboardState kbState = Keyboard.GetState();
      if(timer == 0) {

        foreach (UIButton button in menuButtons) {
          button.Update();
        }


        int indexModifier = 0;
        bool changeIndex = false;
        if(kbState.IsKeyDown(Keys.S) || kbState.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown)) {
          if (selectedButtonIndex < menuButtons.Count -1) {
            indexModifier = 1;
            changeIndex = true;
          }
        } else if(kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickUp) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadUp)) {
          if (selectedButtonIndex > 0) {
            indexModifier = -1;
            changeIndex |= true;
          }
        }

        if (changeIndex) {
          menuButtons[selectedButtonIndex].toggleSelect();
          selectedButtonIndex += indexModifier;
          menuButtons[selectedButtonIndex].toggleSelect();
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

    public void buttonClickHandler(object sender, EventArgs e) {
      UIObject btn = sender as UIObject;

      switch (btn.UItag) {
        case "continueBtn":
          gameManager.changeScreen(gameScreen.levelScreen);
          break;
        case "newGameBtn":
          gameManager.changeScreen(gameScreen.saveFile);
          break;
        case "loadGameBtn":
          gameManager.changeScreen(gameScreen.saveFile);
          break;
        case "settingsBtn":
          gameManager.changeScreen(gameScreen.mainSetting);
          break;
        case "creditsBtn":
          gameManager.changeScreen(gameScreen.credits);
          break;
        case "exitBtn":
          gameManager.quit();
          break;

      }

    }
  }
}
