using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System.Collections;

namespace Mythkeeper {
    class Player {
        /// <summary>
        /// The player character controller
        ///</summary>

        private readonly ContentManager content;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicDevice;

        // Animations
        private AnimatedSprite pSprite;
        private Vector2 pPos;
        private float animationDelay;
        private ArrayList spriteQueue;

        // Sounds



        // Private variables
        private Boolean swordSheathed;
        private int playerMaxHealth;
        private int playerHealth;

        //0 - idle, 1 - moving, 2 - crouching, 3 - sliding, 4 - jumping
        //private int movementStatus;
        private Boolean isMoving;
        private Boolean isJumping;
        private Boolean isCrouching;
        private Boolean isHit;
        private Boolean isSliding;
        private static int maxSlideDistance = 50;


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

            playerX = 400;
            playerY = 200;
            playerSpeed = (float) 2.5;

            spriteQueue = new ArrayList();
        }

        public void LoadContent() {

            spriteBatch = new SpriteBatch(graphicDevice);
            var spriteSheet = content.Load<SpriteSheet>("playersheet.sf", new JsonContentLoader());
            pSprite = new AnimatedSprite(spriteSheet);
          
            spriteQueue.Add("idleAnimU");

            pPos = new Vector2(100, 100);

        }

        public void Draw() {

            spriteBatch.Begin();
            spriteBatch.Draw(pSprite, pPos);
            spriteBatch.End();

        }

        public void Update(GameTime gameTime) {

            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();
            var walkSpeed = deltaSeconds * 128;

            //if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) {
            //    spriteQueue.Add("atkAnim1");
            //    animation = "atkAnim1";
            //    pPos.Y -= walkSpeed;
            //}

            //if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down)) {
            //    spriteQueue.Add("atkAnim2");
            //    animation = "atkAnim2";
            //    pPos.Y += walkSpeed;
            //}

            //if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left)) {
            //    animation = "atkAnim3";
            //    spriteQueue.Add("atkAnim3");
            //    pPos.X -= walkSpeed;
            //}

            //if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right)) {
            //    animation = "deathAnim";
            //    spriteQueue.Add("deathAnim");
            //    pPos.X += walkSpeed;
            //}

            if (animationDelay <= 0) {

                if (Keyboard.GetState().IsKeyDown(Keys.Q)) {

                    if (swordSheathed) {

                        spriteQueue.Add("drawAnim");
                        spriteQueue.Add("idleAnimU");
                        swordSheathed = false;
                        spriteQueue.RemoveAt(0);
                        animationDelay = 10;
                    } else {

                        spriteQueue.Add("sheatheAnim");
                        spriteQueue.Add("idleAnimS");
                        swordSheathed = true;
                        spriteQueue.RemoveAt(0);
                        animationDelay = 10;

                    }

                }

                if (pSprite.Play((string)spriteQueue[0]).IsLooping) {



                } else {

                    var currFrame = pSprite.Play((string)spriteQueue[0]).CurrentFrameIndex;
                    var spriteFrameCount = pSprite.Play((string)spriteQueue[0]).KeyFrames.Length;

                    Console.WriteLine(currFrame + " ; " + spriteFrameCount);

                    if (currFrame == spriteFrameCount - 1) {

                        spriteQueue.RemoveAt(0);

                    }

                }

                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) {

                    if (isCrouching) {

                        spriteQueue.Add("idleAnimC");
                        spriteQueue.RemoveAt(0);

                    } else {

                        spriteQueue.Add("idleAnimS");
                        spriteQueue.RemoveAt(0);

                    }
                    isCrouching = !isCrouching;
                    animationDelay = 10;

                }

            } else {

                animationDelay--;

            }

            pSprite.Play((string)spriteQueue[0]);
            pSprite.Update(deltaSeconds);

        }

        public void checkKeypress() {


            //if the player is not crouching and they press the Q key
            //their weapon is sheathed or unsheathed depending on whether
            //it was sheathed or unsheathed previously
            //if (!isCrouching && !isMoving) {

            //    if (Keyboard.GetState().IsKeyDown(Keys.Q)) {

            //        if (swordSheathed) {

            //            spriteBuffer.QueueAnim(drawSwordAnim);
            //            spriteBuffer.QueueAnim(idleAnimSU);
            //            swordSheathed = false;

            //        } else {

            //            spriteBuffer.QueueAnim(sheatheSwordAnim);
            //            spriteBuffer.QueueAnim(idleAnimSS);
            //            swordSheathed = true;
            //        }

            //    }
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) {

            //    if (isMoving) {
            //        isSliding = true;

            //    } else {

            //        if (isCrouching) {

            //            if(swordSheathed) {

            //                currentAnimation = idleAnimSS;

            //            } else {

            //                spriteBuffer.QueueAnim(idleAnimSS);
            //                spriteBuffer.QueueAnim(drawSwordAnim);
            //                spriteBuffer.QueueAnim(idleAnimSU);

            //            }


            //        } else {

            //            if (swordSheathed) {

            //                currentAnimation = crouchAnim;

            //            } else {

            //                spriteBuffer.QueueAnim(sheatheSwordAnim);
            //                spriteBuffer.QueueAnim(crouchAnim);

            //            }

            //        }

            //        isCrouching = !isCrouching;
            //    }

            //}


            //if (Keyboard.GetState().IsKeyDown(Keys.Space)) {

            //    isJumping = true;

            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.A) ||
            //    Keyboard.GetState().IsKeyDown(Keys.W) ||
            //    Keyboard.GetState().IsKeyDown(Keys.S) ||
            //    Keyboard.GetState().IsKeyDown(Keys.D)) {

            //    isMoving = true;
            //    movePlayer();
            //} else {

            //    isMoving = false;

            //    if(KeyboardExtended.GetState().WasKeyJustDown(Keys.A) ||
            //       KeyboardExtended.GetState().WasKeyJustDown(Keys.D) ||
            //       KeyboardExtended.GetState().WasKeyJustDown(Keys.S) ||
            //       KeyboardExtended.GetState().WasKeyJustDown(Keys.W)) {

            //        if (!swordSheathed) {

            //            spriteBuffer.QueueAnim(drawSwordAnim);
            //            spriteBuffer.QueueAnim(idleAnimSU);

            //        } else {

            //            if (spriteBuffer.IsEmpty()) {

            //                currentAnimation = swordSheathed ? idleAnimSS : idleAnimSU;
            //            }
            //        }


            //    } else {

            //        if (spriteBuffer.IsEmpty()) {

            //            currentAnimation = swordSheathed ? idleAnimSS : idleAnimSU;
            //        }

            //    }

            //}

        }

        public void movePlayer() {

            //if (KeyboardExtended.GetState().WasKeyJustUp(Keys.A) ||
            //       KeyboardExtended.GetState().WasKeyJustUp(Keys.D) ||
            //       KeyboardExtended.GetState().WasKeyJustUp(Keys.S) ||
            //       KeyboardExtended.GetState().WasKeyJustUp(Keys.W)) {

            //    if (!swordSheathed) {

            //        spriteBuffer.QueueAnim(sheatheSwordAnim);
            //        spriteBuffer.QueueAnim(moveAnim);

            //    } else {

            //        if (spriteBuffer.IsEmpty()) {

            //            currentAnimation = moveAnim;

            //        }

            //    }
            //} else {

            //    if (spriteBuffer.IsEmpty()) {

            //        currentAnimation = moveAnim;

            //    }

            //}

            //KeyboardState kbState = Keyboard.GetState();

            //if(kbState.IsKeyDown(Keys.A)) {

            //    playerX--;

            //} else if (kbState.IsKeyDown(Keys.D)) {

            //    playerX++;

            //}
            
            //if (kbState.IsKeyDown(Keys.W)) {

            //    playerY--;

            //} else if (kbState.IsKeyDown(Keys.S)) {

            //    playerY++;

            //}



        }
    }
}
