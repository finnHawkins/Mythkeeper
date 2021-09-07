using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

/*
   Source code from
   http://rbwhitaker.wikidot.com/monogame-texture-atlases-2

    Framerate variables added by me to ensure
    that sprites are displaying
    at the intended framerate

*/

namespace Mythkeeper {
    public class AnimatedSprite {

        public Texture2D texture { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        private int currentFrame;
        private int frameCount;
        public int fps;
        private int elapsedFrames;
        public Boolean looping;

        public AnimatedSprite(Texture2D spriteTexture, int spriteRows, int spriteCols, int FPS, Boolean loop) {

            texture = spriteTexture;
            rows = spriteRows;
            cols = spriteCols;
            currentFrame = 0;
            frameCount = rows * cols;
            fps = FPS;
            looping = loop;
            
        }

        public void Update(GameTime gameTime) {

            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;

            elapsedFrames++;

            if(elapsedFrames >= frameRate / fps) {
                currentFrame++;
                elapsedFrames = 0;
                if (currentFrame == frameCount) { currentFrame = 0; }
            }

        }

        public void Draw(SpriteBatch spritebatch, Vector2 location) {

            int width = texture.Width / cols;
            int height = texture.Height / rows;
            int row = currentFrame / cols;
            int column = currentFrame % cols;


            Rectangle sourceRect = new Rectangle(width * column, height * row, width, height);
            Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, width, height);

            spritebatch.Begin();
            spritebatch.Draw(texture, destRect, sourceRect, Color.White);
            spritebatch.End();

        }


    }
}
