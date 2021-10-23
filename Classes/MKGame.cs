﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;

namespace Mythkeeper {
    public class MKGame : Game {
        private GraphicsDeviceManager gdm;
        private SpriteBatch spriteBatch;
        private Rectangle mainScreen;
        public static ContentManager content;
        private Player player;
        public float frameRate { get; set; }
        private Level thislevel;
        private GameManager mkGM;

        public MKGame() {
            gdm = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            content = Content;
        }

        protected override void Initialize() {

            player = new Player(GraphicsDevice);
            thislevel = new Level(GraphicsDevice);
            mkGM = new GameManager(1,1);
            base.Initialize();

        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainScreen = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            player.LoadContent();
            thislevel.LoadContent();

        }

        protected override void Update(GameTime gameTime) {

            base.Update(gameTime);
            mkGM.Update(gameTime);
            player.Update(gameTime);

            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
            thislevel.Draw(gameTime);
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