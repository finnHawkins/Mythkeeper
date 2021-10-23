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
        private static int jumpHeight = 50;
        private int groundLevel;

        private int playerX;
        private int playerY;
        private float playerSpeed;

        //1 - left, 0 - right
        private bool playerLeft;

        public Player(GraphicsDevice gd) {

            content = MKGame.GetNewContentManagerInstance();
            graphicDevice = gd;

            swordSheathed = false;
            isMoving = false;
            isJumping = false;
            isCrouching = false;
            isHit = false;

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
            var kbState = Keyboard.GetState();
            playerSpeed = deltaSeconds * 128;


            isMoving = false;

            if(kbState.IsKeyDown(Keys.Space)) {

                isJumping = true;
                spriteQueue.Add("jumpAnim");
                spriteQueue.RemoveAt(0);

            }

            if (spriteQueue.Count == 1) {

                if (kbState.IsKeyDown(Keys.D1)) {
                    spriteQueue.Add("atkAnim1");
                    spriteQueue.Add("idleAnimU");
                    spriteQueue.RemoveAt(0);

                } else if (kbState.IsKeyDown(Keys.D2)) {
                    spriteQueue.Add("atkAnim2");
                    spriteQueue.Add("idleAnimU");
                    spriteQueue.RemoveAt(0);

                } else if (kbState.IsKeyDown(Keys.D3)) {
                    spriteQueue.Add("atkAnim3");
                    spriteQueue.Add("idleAnimU");
                    spriteQueue.RemoveAt(0);

                }

                if (kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Up)) {
                    spriteQueue.Add("runAnim");
                    spriteQueue.RemoveAt(0);
                    pPos.Y -= playerSpeed;
                    isMoving = true;
                }

                if (kbState.IsKeyDown(Keys.S) || kbState.IsKeyDown(Keys.Down)) {
                    spriteQueue.Add("runAnim");
                    spriteQueue.RemoveAt(0);
                    pPos.Y += playerSpeed;
                    isMoving = true;
                }

                if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left)) {
                    spriteQueue.Add("runAnim");
                    spriteQueue.RemoveAt(0);
                    pPos.X -= playerSpeed;
                    isMoving = true;
                }

                if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right)) {
                    spriteQueue.Add("runAnim");
                    spriteQueue.RemoveAt(0);
                    pPos.X += playerSpeed;
                    isMoving = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Q)) {

                    if (swordSheathed) {

                        spriteQueue.Add("drawAnim");
                        spriteQueue.Add("idleAnimU");
                        swordSheathed = false;
                        spriteQueue.RemoveAt(0);
                    } else {

                        spriteQueue.Add("sheatheAnim");
                        spriteQueue.Add("idleAnimS");
                        swordSheathed = true;
                        spriteQueue.RemoveAt(0);

                    }

                }

                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) {

                    if (isCrouching) {

                        if(swordSheathed) {

                            spriteQueue.Add("idleAnimC");
                            spriteQueue.RemoveAt(0);

                        } else {

                            spriteQueue.Add("sheatheAnim");
                            spriteQueue.Add("idleAnimC");
                            spriteQueue.RemoveAt(0);
                        }


                    } else {

                        if (swordSheathed) {

                            spriteQueue.Add("idleAnimS");
                            spriteQueue.RemoveAt(0);

                        } else {

                            spriteQueue.Add("drawAnim");
                            spriteQueue.Add("idleAnimU");
                            spriteQueue.RemoveAt(0);
                        }

                    }
                    isCrouching = !isCrouching;

                }

            } else {

                if (pSprite.Play((string)spriteQueue[0]).IsLooping) {



                } else {

                    var currFrame = pSprite.Play((string)spriteQueue[0]).CurrentFrameIndex;
                    var spriteFrameCount = pSprite.Play((string)spriteQueue[0]).KeyFrames.Length;

                    if (currFrame == spriteFrameCount - 1) {

                        spriteQueue.RemoveAt(0);

                    }

                }

            }

            //if(!isMoving && !isJumping) {

            //    spriteQueue.RemoveAt(0);
            //    if (swordSheathed) {
            //        spriteQueue.Add("idleAnimS");
            //    } else {
            //        spriteQueue.Add("idleAnimU");
            //    }

            //}

            pSprite.Play((string)spriteQueue[0]);
            pSprite.Update(deltaSeconds);

        }

    }
}
