using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
    class Level {

        private Texture2D background;
        private Rectangle mainScreen;
        private readonly ContentManager content;
        private string bgImgFileName;
        private Room room;
        private GraphicsDevice graphicDevice;
        private SpriteBatch spriteBatch;

        public Level(GraphicsDevice gd) {

            content = MKGame.GetNewContentManagerInstance();
            graphicDevice = gd;

        }

        public void LoadContent() {

            spriteBatch = new SpriteBatch(graphicDevice);
            background = content.Load<Texture2D>("rooms\\mansion");
            mainScreen = new Rectangle(0, 0, graphicDevice.Viewport.Width, graphicDevice.Viewport.Height);

        }

        public void Draw(GameTime gameTime) {

            spriteBatch.Begin();
            //spriteBatch.Draw(background, mainScreen, Color.White);
            spriteBatch.End();

        }

    }
}
