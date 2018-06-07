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
    class PlatformMetal : GameScene
    {
        SpriteBatch spriteBatch;
     

        PlatformComponent platComp;
        PlatformMetal platform;
        Texture2D platTex;


        public PlatformComponent PlatComp
        {
            get
            {
                return platComp;
            }
            set
            {
                platComp = value;
            }

        }
        public PlatformMetal(Game game,
            SpriteBatch spriteBatch,
             Texture2D platTex)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.platTex = platTex;


            platComp = new PlatformComponent(game, spriteBatch,
                platTex);

            this.Components.Add(platComp);



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
