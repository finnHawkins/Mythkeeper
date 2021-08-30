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
        private AnimatedSprite deathAnim;

        // Movement Animations
        private AnimatedSprite climbAnim;
        private AnimatedSprite crouchAnim;
        private AnimatedSprite fallAnim;
        private AnimatedSprite jumpAnim;
        private AnimatedSprite rollAnim;
        private AnimatedSprite slideAnim;
        private AnimatedSprite moveAnim;
        private AnimatedSprite standAnim;

        private AnimatedSprite wallSlideAnim;

        // Attack Animations
        private AnimatedSprite mageAtkAnim;
        private AnimatedSprite mageAtkHoldAnim;
        private AnimatedSprite airAtk1;
        private AnimatedSprite airAtk2;
        private AnimatedSprite airAtk31;
        private AnimatedSprite airAtk32;
        private AnimatedSprite airAtk33;
        private AnimatedSprite meleeAtk1;
        private AnimatedSprite meleeAtk2;
        private AnimatedSprite meleeAtk3;

        // Sounds



        // Private variables
        private Boolean swordSheathed;

        //0 - idle, 1 - moving, 2 - crouching, 3 - sliding, 4 - jumping
        //private int movementStatus;
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
        private float playerSpeed;

        //1 - left, 2 - right
        private int playerDirection;

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
            playerSpeed = (float) 2.5;

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
            Texture2D move = content.Load<Texture2D>("entities\\player\\spr_pMove_6");
            moveAnim = new AnimatedSprite(move, 1, 6, 6, false);

            currentAnimation = idleAnimSS;

        }

        public void Draw() {

            currentAnimation.Draw(spriteBatch, new Vector2(playerX, playerY));

        }

        public void Update(GameTime gameTime) {

            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (animationDelay == 0) {
                if (!spriteBuffer.IsEmpty()) {

                    currentAnimation = spriteBuffer.DequeueAnim(0);
                    animationDelay = frameRate / currentAnimation.fps;

                } else {

                    checkKeypress();

                }
            } else {

                animationDelay = animationDelay < 0 ? 0 : animationDelay- currentAnimation.fps;

            }

            currentAnimation.Update(gameTime);

        }

        public void checkKeypress() {


            //if the player is not crouching and they press the Q key
            //their weapon is sheathed or unsheathed depending on whether
            //it was sheathed or unsheathed previously
            if (!isCrouching && !isMoving) {

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
                movePlayer();
            } else {

                isMoving = false;

                //if(!swordSheathed) {

                //    spriteBuffer.QueueAnim(drawSwordAnim);
                //    spriteBuffer.QueueAnim(idleAnimSU);

                //} else {

                currentAnimation = swordSheathed ? idleAnimSS : idleAnimSU;

                //}

            }

        }

        public void movePlayer() {

            //if(!swordSheathed) {

            //    spriteBuffer.QueueAnim(sheatheSwordAnim);
            //    spriteBuffer.QueueAnim(moveAnim);

            //} else {

            currentAnimation = moveAnim;

            //}

            KeyboardState kbState = Keyboard.GetState();

            if(kbState.IsKeyDown(Keys.A)) {

                playerX--;

            } else if (kbState.IsKeyDown(Keys.D)) {

                playerX++;

            }
            
            if (kbState.IsKeyDown(Keys.W)) {

                playerY--;

            } else if (kbState.IsKeyDown(Keys.S)) {

                playerY++;

            }



        }
    }
}
