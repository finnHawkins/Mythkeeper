using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;

namespace Mythkeeper {
    public class MKGame : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        //private AnimatedSprite playerAnim;
        private Texture2D background;
        private Rectangle mainScreen;
        public static ContentManager content;
        private Player player;

        public MKGame() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            content = Content;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            player = new Player(GraphicsDevice);

            base.Initialize();


        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Texture2D texture = Content.Load<Texture2D>("spr_pIdle1_4");
            background = Content.Load<Texture2D>("rooms\\mansion");
            mainScreen = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            //playerAnim = new AnimatedSprite(texture, 1, 4, 4);

            // TODO: use this.Content to load your game content here

            player.LoadContent();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //playerAnim.Update(gameTime);

            base.Update(gameTime);
            player.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.Draw(background, mainScreen, Color.White);
            spriteBatch.End();

            //playerAnim.Draw(spriteBatch, new Vector2(400, 200));

            base.Draw(gameTime);
            player.Draw();
        }

        /// <summary>
        /// https://community.monogame.net/t/passing-the-contentmanager-to-every-class-feels-wrong-is-it/10470/9
        /// Code copied from the above link for more finessed content managers
        /// </summary>
        /// <returns></returns>
        public static ContentManager GetNewContentManagerInstance() {
            // create a new content manager instance
            ContentManager temp = new ContentManager(content.ServiceProvider, content.RootDirectory);
            temp.RootDirectory = "Content";
            return temp;
        }

        public static ContentManager GetMainContentManager() {

            return content;

        }


    }
}
