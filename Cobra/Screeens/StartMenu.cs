using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Media;

namespace Cobra
{
    public class StartMenu : GameScene
    {
        private MenuComponent menu;


        public MenuComponent Menu
        {
            get
            {
                return menu;
            }

            set
            {
                menu = value;
            }
        }

        private SpriteBatch spriteBatch;
        string[] menuItems = {  "DEPLOY SOLDIER!",
                                "HOW TO PLAY",
                                "CREDITS",
                                "QUIT"};

        public StartMenu(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;

            //check this code very carefully how game reference coming
            // through the constructor is used to acess the Content.
            menu = new MenuComponent(game, spriteBatch,
                game.Content.Load<SpriteFont>("fonts/regular"),
                game.Content.Load<SpriteFont>("fonts/hilight"),
                game.Content.Load<SpriteFont>("fonts/title"),
                game.Content.Load<Texture2D>("images/cobraCover"),
                menuItems
                );

            // never write game.Components.Add()

            this.Components.Add(menu);


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