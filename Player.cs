using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;

namespace Mythkeeper {
    class Player {
        /// <summary>
        /// The player character controller
        ///</summary>

        private ContentManager content;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicDevice;

        // Animations
        private AnimatedSprite idleAnim1;
        private AnimatedSprite idleAnim2;
        private Animation drawSwordAnim;
        private Animation sheatheSwordAnim;
        private Animation deathAnim;

        // Movement Animations
        private Animation climbAnim;
        private Animation crouchAnim;
        private Animation fallAnim;
        private Animation jumpAnim;
        private Animation rollAnim;
        private Animation slideAnim;
        private Animation moveAnim;
        private Animation standAnim;

        private Animation wallSlideAnim;

        // Attack Animations
        private Animation mageAtkAnim;
        private Animation mageAtkHoldAnim;
        private Animation airAtk1;
        private Animation airAtk2;
        private Animation airAtk31;
        private Animation airAtk32;
        private Animation airAtk33;
        private Animation meleeAtk1;
        private Animation meleeAtk2;
        private Animation meleeAtk3;


        // Sounds

        // Private variables
        private Boolean swordSheathed;
        private AnimatedSprite currentAnimation;

        public Player(GraphicsDevice gd) {

            content = MKGame.GetNewContentManagerInstance();
            graphicDevice = gd;
            Console.WriteLine("player class initialised");

            swordSheathed = false;

        }

        public void LoadContent() {

            spriteBatch = new SpriteBatch(graphicDevice);

            Texture2D idle1 = content.Load<Texture2D>("entities\\player\\spr_pIdle1_4");
            idleAnim1 = new AnimatedSprite(idle1, 1, 4, 4);
            Texture2D idle2 = content.Load<Texture2D>("entities\\player\\spr_pIdle2_4");
            idleAnim2 = new AnimatedSprite(idle2, 1, 4, 4);

        }

        public void Draw() {

            currentAnimation.Draw(spriteBatch, new Vector2(400, 200));

        }

        public void Update(GameTime gameTime) {

            currentAnimation = swordSheathed ? idleAnim1 : idleAnim2;

            if(Keyboard.GetState().IsKeyDown(Keys.Q)) {
                swordSheathed = !swordSheathed;
            }

            currentAnimation.Update(gameTime);

        }














    }
}
