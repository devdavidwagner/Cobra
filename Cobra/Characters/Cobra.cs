using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cobra.Characters
{
    class Cobra : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        public Vector2 position;

        private Texture2D cobraJumpingRightSide1;
        private Texture2D cobraJumpingRightSide2;

        private Texture2D cobraJumpingLeftSide1;
        private Texture2D cobraJumpingLeftSide2;

        public Texture2D cobraStandingRightSide;
        private Texture2D cobraStandingRightSide2;
        private Texture2D cobraStandingRightSide3;
        private Texture2D cobraStandingRightSide4;

        private Texture2D cobraShootingRightSide;
        private Texture2D cobraShootingRightSide2;
        private Texture2D cobraShootingRightSide3;
        private Texture2D cobraShootingRightSide4;

        private Texture2D cobraStandingLeftSide;
        private Texture2D cobraStandingLeftSide2;
        private Texture2D cobraStandingLeftSide3;
        private Texture2D cobraStandingLeftSide4;

        public  Texture2D currentTexture;

        private Texture2D[] cobraRightSideShooting = new Texture2D[4];
        private Texture2D[] cobraRightSide = new Texture2D[4];
        private Texture2D[] cobraLeftSide = new Texture2D[4];
        private Texture2D[] cobraJumpingRightSide = new Texture2D[2];
        private Texture2D[] cobraJumpingLeftSide = new Texture2D[2];
        public Texture2D[] CobraSpritesRight
        {
            get
            {
                return cobraRightSide;
            }
            set
            {
                cobraRightSide = value;
            }
        
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }


        SpriteFont regularFont;


        public Cobra(Game game,
            SpriteBatch spriteBatch
            )
            : base(game)
        {
            regularFont = game.Content.Load<SpriteFont>("fonts/regular");
            this.spriteBatch = spriteBatch;


            cobraStandingRightSide = game.Content.Load<Texture2D>("images/cobraStandingRightSide");
            cobraStandingRightSide2 = game.Content.Load<Texture2D>("images/cobraStandingRightSide2");
            cobraStandingRightSide3 = game.Content.Load<Texture2D>("images/cobraStandingRightSide3");
            cobraStandingRightSide4 = game.Content.Load<Texture2D>("images/cobraStandingRightSide4");

            cobraRightSide[0] = cobraStandingRightSide;
            cobraRightSide[1] = cobraStandingRightSide2;
            cobraRightSide[2] = cobraStandingRightSide3;
            cobraRightSide[3] = cobraStandingRightSide4;

            cobraStandingLeftSide = game.Content.Load<Texture2D>("images/cobraStandingLeftSide");
            cobraStandingLeftSide2 = game.Content.Load<Texture2D>("images/cobraStandingLeftSide2");
            cobraStandingLeftSide3 = game.Content.Load<Texture2D>("images/cobraStandingLeftSide3");
            cobraStandingLeftSide4 = game.Content.Load<Texture2D>("images/cobraStandingLeftSide4");

            cobraLeftSide[0] = cobraStandingLeftSide;
            cobraLeftSide[1] = cobraStandingLeftSide2;
            cobraLeftSide[2] = cobraStandingLeftSide3;
            cobraLeftSide[3] = cobraStandingLeftSide4;

            cobraJumpingRightSide1 = game.Content.Load<Texture2D>("images/JumpRightSide1");
            cobraJumpingRightSide2 = game.Content.Load<Texture2D>("images/JumpRightSide2");

            cobraJumpingLeftSide1 = game.Content.Load<Texture2D>("images/JumpLeftSide1");
            cobraJumpingLeftSide2 = game.Content.Load<Texture2D>("images/JumpLeftSide2");

            //shooting
            cobraShootingRightSide = game.Content.Load<Texture2D>("images/cobraShootingRight1");
            cobraShootingRightSide2 = game.Content.Load<Texture2D>("images/cobraShootingRight2");
            cobraShootingRightSide3 = game.Content.Load<Texture2D>("images/cobraShootingRight3");
            cobraShootingRightSide4 = game.Content.Load<Texture2D>("images/cobraShootingRight4");

            cobraRightSideShooting[0] = cobraShootingRightSide;
            cobraRightSideShooting[1] = cobraShootingRightSide2;
            cobraRightSideShooting[2] = cobraShootingRightSide3;
            cobraRightSideShooting[3] = cobraShootingRightSide4;

            cobraJumpingRightSide[0] = cobraJumpingRightSide1;
            cobraJumpingRightSide[1] = cobraJumpingRightSide2;

            cobraJumpingLeftSide[0] = cobraJumpingLeftSide1;
            cobraJumpingLeftSide[1] = cobraJumpingLeftSide2;

            whiteRectangle = game.Content.Load<Texture2D>("images/rectangle");


            position = new Vector2(400, 500);

        }

        public override void Initialize()
        {
            base.Initialize();
        }


        public Boolean dead;


        public override void Update(GameTime gameTime)
        {
             
     
            base.Update(gameTime);
        }


        private Boolean movingLeft = false;

        public Boolean MovingLeft
        {
            get
            {
                return movingLeft;
            }
            set
            {
                movingLeft = value;
            }
        }

        private Boolean movingRight = false;

        public Boolean MovingRight
        {
            get
            {
                return movingRight;
            }
            set
            {
                movingRight = value;
            }
        }

        private int rightMovingCounter = 0;
        private int leftMovingCounter = 0;

        private string lastDir;

        public Boolean Falling;
        public Boolean Jumping;
        

        public Boolean shooting;
        public int shootingTimer;

        Texture2D whiteRectangle;
        public int jumpCounter = 0;
        Vector2 origin;

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
           

            if (Jumping == true)
            {
                jumpCounter++;

                if (movingRight == true || movingRight == false && movingLeft == false)
                {
                    if (jumpCounter < 11)
                    {
                        currentTexture = cobraJumpingRightSide[0];
                    }
                    if (jumpCounter > 10 && jumpCounter < 40)
                    {
                        currentTexture = cobraJumpingRightSide[1];
                    }

                    if (jumpCounter > 40)
                    {
                        jumpCounter = 0;
                        Jumping = false;
                    }
                }
                
                else if(movingLeft == true)
                {
                    if (jumpCounter < 11)
                    {
                        currentTexture = cobraJumpingLeftSide[0];

                    }
                    if (jumpCounter > 10 && jumpCounter < 40)
                    {
                        currentTexture = cobraJumpingLeftSide[1];
                    }

                    if (jumpCounter > 40)
                    {
                        jumpCounter = 0;
                        Jumping = false;
                    }
                }
             

            }
            else
            {
                if (shooting == true)
                {
                    shootingTimer++;
                    Console.WriteLine(shootingTimer);
                  
                        if (shootingTimer < 11)
                        {
                            currentTexture = cobraRightSideShooting[0];
                        }
                        if (shootingTimer > 10 && shootingTimer < 21)
                        {
                            currentTexture = cobraRightSideShooting[1];
                        }
                        if (shootingTimer > 20 && shootingTimer < 31)
                        {
                            currentTexture = cobraRightSideShooting[2];
                        }
                        if (shootingTimer > 30 && shootingTimer < 41)
                        {
                            currentTexture = cobraRightSideShooting[3];
                        }
                        if (shootingTimer > 40 && shootingTimer < 51)
                        {
                            currentTexture = cobraRightSideShooting[1];
                        }
                        if (shootingTimer > 50 && shootingTimer < 61)
                        {
                            currentTexture = cobraRightSideShooting[0];
                        }
                        if (shootingTimer > 60)
                        {
                            shootingTimer = 0;
                            shooting = false;
                        }
                  
                }
                else
                {

                    if (movingRight == true)
                    {
                        lastDir = "right";

                        if (rightMovingCounter < 21)
                        {
                            currentTexture = cobraRightSide[2];
                        }
                        else if (rightMovingCounter > 20 && rightMovingCounter < 41)
                        {
                            currentTexture = cobraRightSide[1];
                        }

                        if (rightMovingCounter > 40)
                        {
                            rightMovingCounter = 0;
                            currentTexture = cobraRightSide[1];
                        }
                        rightMovingCounter++;

                    }
                    else
                    {
                        rightMovingCounter = 0;
                    }
                    if (movingLeft == true)
                    {
                        lastDir = "left";
                        if (leftMovingCounter < 21)
                        {
                            currentTexture = cobraLeftSide[1];
                        }
                        else if (leftMovingCounter > 20 && rightMovingCounter < 41)
                        {
                            currentTexture = cobraLeftSide[2];
                        }

                        if (leftMovingCounter > 40)
                        {
                            leftMovingCounter = 0;
                            currentTexture = cobraLeftSide[1];
                        }
                        leftMovingCounter++;
                        Console.WriteLine(leftMovingCounter);
                    }
                    else
                    {
                        leftMovingCounter = 0;
                    }

                    if (movingLeft == false && movingRight == false)
                    {
                        if (lastDir == "right")
                        {
                            currentTexture = cobraRightSide[3];
                        }
                        else if (lastDir == "left")
                        {
                            currentTexture = cobraLeftSide[3];
                        }
                        else
                        {
                            currentTexture = cobraRightSide[3];

                        }

                    }
                }



            }
            if (dead == true)
            {
           
                spriteBatch.Draw(whiteRectangle, new Rectangle(300, 75, 400, 100), Color.White);
                spriteBatch.DrawString(regularFont, "COBRA IS DEAD! \n PRESS ENTER TO RESTART", new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2 - regularFont.MeasureString("COBRA ARE DEAD! /n PRESS ENTER TO RESTART").Length() / 2 + 50, GraphicsDevice.Viewport.Bounds.Height / 2 - 300), Color.Green);
            }
            else
            {
                spriteBatch.Draw(currentTexture, position, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 1f);

            }

            lastDir = "";
          
                spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
