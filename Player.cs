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

        private readonly ContentManager content;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicDevice;

        // Animations
        private AnimatedSprite idleAnimSS;
        private AnimatedSprite idleAnimSU;
        private AnimatedSprite drawSwordAnim;
        private AnimatedSprite sheatheSwordAnim;
        private Animation deathAnim;

        // Movement Animations
        private Animation climbAnim;
        private AnimatedSprite crouchAnim;
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
        private Boolean isMoving;
        private Boolean isJumping;
        private Boolean isCrouching;
        private Boolean isHit;
        private Boolean isSliding;
        private static int maxSlideDistance = 50;

        private AnimatedSprite currentAnimation;
        private float animationDelay;
        private AnimationBuffer spriteBuffer;

        private int playerX;
        private int playerY;
        private int playerHealth;

        public Player(GraphicsDevice gd) {

            content = MKGame.GetNewContentManagerInstance();
            graphicDevice = gd;

            swordSheathed = false;
            isMoving = false;
            isJumping = false;
            isCrouching = false;
            isHit = false;

            animationDelay = 0;
            spriteBuffer = new AnimationBuffer();

            playerX = 400;
            playerY = 200;
            playerHealth = 100;



        }

        public void LoadContent() {

            spriteBatch = new SpriteBatch(graphicDevice);

            Texture2D idle1 = content.Load<Texture2D>("entities\\player\\spr_pIdle1_4");
            idleAnimSS = new AnimatedSprite(idle1, 1, 4, 4, true);
            Texture2D idle2 = content.Load<Texture2D>("entities\\player\\spr_pIdle2_4");
            idleAnimSU = new AnimatedSprite(idle2, 1, 4, 4, true);
            Texture2D draw = content.Load<Texture2D>("entities\\player\\spr_pUnsheathe_3");
            drawSwordAnim = new AnimatedSprite(draw, 1, 3, 3, false);
            Texture2D sheathe = content.Load<Texture2D>("entities\\player\\spr_pSheathe_4");
            sheatheSwordAnim = new AnimatedSprite(sheathe, 1, 4, 4, false);
            Texture2D crouch = content.Load<Texture2D>("entities\\player\\spr_pCrouch_4");
            crouchAnim = new AnimatedSprite(crouch, 1, 4, 4, false);

            currentAnimation = idleAnimSS;

        }

        public void Draw() {

            currentAnimation.Draw(spriteBatch, new Vector2(playerX, playerY));

        }

        public void Update(GameTime gameTime) {

            //if the spritebuffer is empty 
            //depending on what key is pressed, add the right animation to the spritebuffer
            //if it was a movement key, move the character
            //otherwise
            //

            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (animationDelay == 0) {
                if (!spriteBuffer.IsEmpty()) {

                    currentAnimation = spriteBuffer.DequeueAnim(0);
                    animationDelay = frameRate / currentAnimation.fps;

                } else {

                    checkKeypress();

                    //currentAnimation = swordSheathed ? idleAnimSS : idleAnimSU;

                }
            } else {

                animationDelay = animationDelay < 0 ? 0 : animationDelay- currentAnimation.fps;

            }

            currentAnimation.Update(gameTime);

        }

        public void checkKeypress() {

            if (!isCrouching) {

                if (Keyboard.GetState().IsKeyDown(Keys.Q)) {

                    if (swordSheathed) {

                        spriteBuffer.QueueAnim(drawSwordAnim);
                        spriteBuffer.QueueAnim(idleAnimSU);
                        swordSheathed = false;

                    } else {

                        spriteBuffer.QueueAnim(sheatheSwordAnim);
                        spriteBuffer.QueueAnim(idleAnimSS);
                        swordSheathed = true;
                    }

                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) {

                if (isMoving) {
                    isSliding = true;
                } else {

                    if (isCrouching) {

                        if(swordSheathed) {

                            currentAnimation = idleAnimSS;

                        } else {

                            spriteBuffer.QueueAnim(idleAnimSS);
                            spriteBuffer.QueueAnim(drawSwordAnim);
                            spriteBuffer.QueueAnim(idleAnimSU);

                        }


                    } else {

                        if (swordSheathed) {

                            currentAnimation = crouchAnim;

                        } else {

                            spriteBuffer.QueueAnim(sheatheSwordAnim);
                            spriteBuffer.QueueAnim(crouchAnim);

                        }

                    }

                    isCrouching = !isCrouching;
                }

            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {

                isJumping = true;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) ||
                Keyboard.GetState().IsKeyDown(Keys.W) ||
                Keyboard.GetState().IsKeyDown(Keys.S) ||
                Keyboard.GetState().IsKeyDown(Keys.D)) {

                isMoving = true;

            }


        }
    }
}
