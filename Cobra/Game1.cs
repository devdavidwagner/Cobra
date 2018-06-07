using Cobra.Screeens.Mission1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cobra
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private StartMenu startMenu;
        private Mission1 mission1;
        private SoundEffect cobraTheme;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        private void hideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in this.Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //scenes

            startMenu = new StartMenu(this, spriteBatch);
            mission1 = new Mission1(this, spriteBatch);

            this.Components.Add(startMenu);
            this.Components.Add(mission1);

            hideAllScenes();

            cobraTheme = Content.Load<SoundEffect>("Themes/cobratheme");

            startMenu.show();


            cobraTheme.Play();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        KeyboardState previous_ks;
        protected override void Update(GameTime gameTime)
        {
            KeyboardState current_ks = Keyboard.GetState();


            if(mission1.missionReset == true)
            {
                this.Components.Remove(mission1);


                mission1 = new Mission1(this, spriteBatch);

                this.Components.Add(mission1);
                hideAllScenes();
                mission1.show();


            }

        
            int selectedIndex = 0;
            if (startMenu.Enabled)
            {
                if (selectedIndex == 0 && current_ks.IsKeyDown(Keys.Enter) && previous_ks.IsKeyUp(Keys.Enter))
                {
                    //DEPLOY
                    startMenu.hide();
                    mission1.show();
                  


                }

                previous_ks = current_ks;
            }

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
