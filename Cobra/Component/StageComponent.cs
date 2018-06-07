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
    class StageComponent : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        PlatformMetal platform;
        public Texture2D stage;
        public Vector2 position;

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

        public Texture2D Stage
        {
            get
            {
                return stage;
            }
            set
            {
                stage = value;
            }
        }




        public StageComponent(Game game,
            SpriteBatch spriteBatch,
            Texture2D stage,
            PlatformMetal platform
            )
            : base(game)
        {

            this.spriteBatch = spriteBatch;
            this.stage = stage;
            this.platform = platform;


            position = new Vector2(-20, 0);

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
            spriteBatch.Begin();
         
            spriteBatch.Draw(stage, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
