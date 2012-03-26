using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XANALand.Game;
using GraphicsToolkit.Input;
using GraphicsToolkit;
using GraphicsToolkit.Graphics;
using GraphicsToolkit.Graphics.SceneGraph;

namespace XANALand
{
    public class GameHost : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private PrimitiveBatch primitiveBatch;
        private FirstPersonCamera camera;
        private SceneNode sceneRoot;
        private TerrainNode terrainNode;

        public GameHost()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));

            //Enable anti-aliasing
            graphics.PreferMultiSampling = true;

            //Put our resolution at 720p
            graphics.PreferredBackBufferWidth = Config.ScreenWidth = 1280;
            graphics.PreferredBackBufferHeight = Config.ScreenHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            camera = new FirstPersonCamera(0.5f, 10);
            camera.Pos = new Vector3(3, 3, 13);

            Texture2D heightMap = Content.Load<Texture2D>("heightmap");

            primitiveBatch = new PrimitiveBatch(GraphicsDevice);

            sceneRoot = new SceneNode();
            terrainNode = new TerrainNode(GraphicsDevice, heightMap);

            sceneRoot.AddChild(terrainNode);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            camera.Update(gameTime);

            sceneRoot.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            sceneRoot.Draw(gameTime, Matrix.Identity, primitiveBatch, camera);

            base.Draw(gameTime);
        }
    }
}
