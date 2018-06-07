using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cobra.Screeens.Mission1
{
    class Mission1 : GameScene
    {
        SpriteBatch spriteBatch;
        PlatformMetal metal1;
        PlatformMetal metal2;
        PlatformMetal metal3;
        PlatformMetal metal4;

        List<PlatformMetal> metPlats = new List<PlatformMetal>();


        MerlinsQuest.CollisionDetection cDetect;

        public Boolean missionReset = false;

        SpriteFont regularFont;

        const int GRAVITY = 7;

        Stage stage;

        Characters.Cobra cobra;

        Texture2D backDrop;


        public Mission1(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            stage = new Stage(game, spriteBatch);
            cobra = new Characters.Cobra(game, spriteBatch);
            cDetect = new MerlinsQuest.CollisionDetection(game, spriteBatch);


            Texture2D platTex1 = game.Content.Load<Texture2D>("images/metal");
            Texture2D platTex2 = game.Content.Load<Texture2D>("images/metal");
            Texture2D platTex3 = game.Content.Load<Texture2D>("images/metal");
            Texture2D platTex4 = game.Content.Load<Texture2D>("images/metal");
            //platforms
            metal1 = new PlatformMetal(game, spriteBatch, platTex1);
            metal1.PlatComp.position = new Vector2(400, 500 + metal1.PlatComp.platTex.Height + cobra.cobraStandingRightSide.Height );
            metal2 = new PlatformMetal(game, spriteBatch, platTex2);
            metal2.PlatComp.position = new Vector2(1000, 500 + metal2.PlatComp.platTex.Height + cobra.cobraStandingRightSide.Height);
            metal3 = new PlatformMetal(game, spriteBatch, platTex2);
            metal3.PlatComp.position = new Vector2(1400, 500 + metal3.PlatComp.platTex.Height + cobra.cobraStandingRightSide.Height);
            metal4 = new PlatformMetal(game, spriteBatch, platTex2);
            metal4.PlatComp.position = new Vector2(1800, 500 + metal4.PlatComp.platTex.Height + cobra.cobraStandingRightSide.Height);

            metPlats.Add(metal1);
            metPlats.Add(metal2);
            metPlats.Add(metal3);
            metPlats.Add(metal4);
            //fonts


            cobra.currentTexture = cobra.cobraStandingRightSide;
            

            //add
            this.Components.Add(stage);
            this.Components.Add(metal1);
            this.Components.Add(metal2);
            this.Components.Add(metal3);
            this.Components.Add(metal4);
            this.Components.Add(cobra);
            
            
            //show
            stage.show();
            metal1.show();
            metal2.show();
            metal3.show();
            metal4.show();


        }



        public override void Initialize()
        {
            base.Initialize();

          


        }

        private KeyboardState oldState;
        int secondHalfLength = 0;
        int jumpLength = 0;

        private bool brickCollision;
        private bool spacePressed;

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (cobra.dead == true && ks.IsKeyDown(Keys.Enter))
            {
              
                missionReset = true;
        

            }

            if (cobra.position.Y > 800)
            {
                cobra.dead = true;
            }
            else
            {
                cobra.dead = false;
            }

            if (cobra.dead == false)
            {
                // <-- -->
                #region LEFTRIGHT


                if (ks.IsKeyDown(Keys.Right) && stage.StageComp.position.X > -8800)
                {

                    stage.StageComp.position.X = stage.StageComp.position.X - 5;

                    for (int i = 0; i < metPlats.Count; i++)
                    {
                        metPlats[i].PlatComp.position.X = metPlats[i].PlatComp.position.X - 5;
                    }
                    cobra.MovingRight = true;
                    cobra.MovingLeft = false;
                }
                if (ks.IsKeyDown(Keys.Left) && stage.StageComp.position.X < 0)
                {
                    stage.StageComp.position.X = stage.StageComp.position.X + 5;

                    for (int i = 0; i < metPlats.Count; i++)
                    {
                        metPlats[i].PlatComp.position.X = metPlats[i].PlatComp.position.X + 5;
                    }
                    cobra.MovingLeft = true;
                    cobra.MovingRight = false;

                }
             


                if (ks.IsKeyUp(Keys.Right))
                {
                    cobra.MovingRight = false;
                }
                if (ks.IsKeyUp(Keys.Left))
                {
                    cobra.MovingLeft = false;
                }
                
                //shooting

                if(ks.IsKeyDown(Keys.F))
                {
                    cobra.shooting = true;
                    Console.WriteLine("SHOOTING");
                }
                else
                {
                    cobra.shooting = false;
                    cobra.shootingTimer = 0;
                }

               
                //jumping




                if(ks.IsKeyDown(Keys.Space) && cobra.Jumping == false && spacePressed == false)
                {
                    spacePressed = true;
                }


                if (ks.IsKeyUp(Keys.Space) && cobra.Jumping == false && spacePressed == true)
                {
                    cobra.Jumping = true;
                }
                if (cobra.Jumping == true)
                {
                    spacePressed = false;
                    if (cobra.jumpCounter < 21)
                    {
                        cobra.position.Y = cobra.position.Y - 4;
                    }
                    else if (cobra.jumpCounter > 20 && cobra.jumpCounter < 41)
                    {
                        cobra.Falling = true;
              
                    }
          
                 }













                #endregion

                #region collisions

                 brickCollision = false;
                for (int i = 0; i < metPlats.Count; i++)
                {
                    if(cDetect.CollidedBrick(metPlats[i].PlatComp.platTex, cobra.currentTexture, metPlats[i].PlatComp.position, cobra.position))
                        brickCollision = true;
                        
                }  



                if (brickCollision == true)
                {
                    cobra.Falling = false;
                }
                else
                {
                    if (cobra.Jumping == false)
                    {
                        cobra.Falling = true;
                    }
                    else
                    {
                        cobra.Falling = false;
                    }

                }
               

                if (cobra.Falling == true)
                {
                    cobra.position.Y = cobra.position.Y + GRAVITY;
                }
                #endregion


                oldState = ks;

              
                base.Update(gameTime);
            }

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

           


            spriteBatch.End();

            base.Draw(gameTime);
        }






    }
}
