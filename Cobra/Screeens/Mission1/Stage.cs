using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cobra.Screeens.Mission1
{
    class Stage : GameScene
    {
        SpriteBatch spriteBatch;
        Texture2D backdrop;

        StageComponent stageComp;
        PlatformMetal platform;


        public StageComponent StageComp
        {
            get
            {
                return stageComp;
            }
            set
            {
                stageComp = value;
            }

        }
        public Stage(Game game,
            SpriteBatch spriteBatch)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            backdrop = game.Content.Load<Texture2D>("images/stageBackground");


            stageComp = new StageComponent(game, spriteBatch,
                backdrop, platform);

            this.Components.Add(stageComp);



        }

        public override void Initialize()
        {
            base.Initialize();
        }

     
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
          
            base.Draw(gameTime);
        }
    }
}
