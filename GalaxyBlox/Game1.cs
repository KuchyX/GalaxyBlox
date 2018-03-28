using GalaxyBlox.Models;
using GalaxyBlox.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GalaxyBlox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static Game1 ActiveGame;
        public static ContentManager GameContent;

        public static Random Random;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            ActiveGame = this;
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

            Static.Settings.Game.LoadAll();

            GameContent = Content;
            Random = new Random(unchecked((int)DateTime.Now.Ticks));

            new Rooms.MenuRoom("Room_Menu", Static.Settings.Game.WindowSize, new Vector2()).Show();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Static.Contents.Textures.Pix = Content.Load<Texture2D>("Sprites/pixel");
            Static.Contents.Fonts.PlainTextFont = Content.Load<SpriteFont>("Fonts/PlainText");
            Static.Contents.Fonts.PixelArtTextFont = Content.Load<SpriteFont>("Fonts/PixelArtText");

            Static.Contents.Textures.ControlButton_fall = Content.Load<Texture2D>("Sprites/btn_control_down");
            Static.Contents.Textures.ControlButton_left = Content.Load<Texture2D>("Sprites/btn_control_left");
            Static.Contents.Textures.ControlButton_right = Content.Load<Texture2D>("Sprites/btn_control_right");
            Static.Contents.Textures.ControlButton_rotate = Content.Load<Texture2D>("Sprites/btn_control_rotate");

            Static.Contents.Textures.Button_pause = Content.Load<Texture2D>("Sprites/btn_pause");
            Static.Contents.Textures.Button_exit = Content.Load<Texture2D>("Sprites/btn_exit");
            Static.Contents.Textures.Button_play = Content.Load<Texture2D>("Sprites/btn_play");
            Static.Contents.Textures.Button_settings= Content.Load<Texture2D>("Sprites/btn_settings");
            Static.Contents.Textures.Button_highscore= Content.Load<Texture2D>("Sprites/btn_highscore");
            Static.Contents.Textures.Button_left= Content.Load<Texture2D>("Sprites/btn_left");
            Static.Contents.Textures.Button_right = Content.Load<Texture2D>("Sprites/btn_right");
            Static.Contents.Textures.Button_left_small = Content.Load<Texture2D>("Sprites/btn_left_small");
            Static.Contents.Textures.Button_right_small = Content.Load<Texture2D>("Sprites/btn_right_small");
            Static.Contents.Textures.Button_up_medium = Content.Load<Texture2D>("Sprites/btn_up_medium");
            Static.Contents.Textures.Button_down_medium = Content.Load<Texture2D>("Sprites/btn_down_medium");
            Static.Contents.Textures.Button_empty = Content.Load<Texture2D>("Sprites/btn_empty");
            Static.Contents.Textures.Button_bonus = Content.Load<Texture2D>("Sprites/btn_bonus");

            Static.Contents.Textures.BackgroundGame = Content.Load<Texture2D>("Backgrounds/Background");
            Static.Contents.Textures.BackgroundMenu = Static.Contents.Textures.BackgroundGame;
            Static.Contents.Textures.Dialog_background = Content.Load<Texture2D>("Backgrounds/dialog_background");
            Static.Contents.Textures.Dialog_inside = Content.Load<Texture2D>("Backgrounds/dialog_inside");

            Static.Contents.Textures.GameUI_top_background = Content.Load<Texture2D>("Backgrounds/ui_top_background");
            Static.Contents.Textures.GameUI_bottom_classic_background = Content.Load<Texture2D>("Backgrounds/ui_down_classic_background");
            Static.Contents.Textures.GameUI_bottom_normal_background = Content.Load<Texture2D>("Backgrounds/ui_down_normal_background");
            Static.Contents.Textures.GameUI_playingArena_border = Content.Load<Texture2D>("Backgrounds/playing_arena_border");

            Static.Contents.Textures.Dialog_icon_questionMark = Content.Load<Texture2D>("Sprites/dialog_icon_questionMark");
            Static.Contents.Textures.Dialog_icon_settings = Content.Load<Texture2D>("Sprites/dialog_icon_settings");
            Static.Contents.Textures.Dialog_icon_highscore = Content.Load<Texture2D>("Sprites/dialog_icon_highscore");

            Static.Contents.Textures.Star_small = Content.Load<Texture2D>("Sprites/star_small");
            Static.Contents.Textures.Star_medium_01 = Content.Load<Texture2D>("Sprites/star_medium_01");
            Static.Contents.Textures.Star_medium_02 = Content.Load<Texture2D>("Sprites/star_medium_02");
            Static.Contents.Textures.Star_big = Content.Load<Texture2D>("Sprites/star_big");

            Static.Contents.Textures.Logo = Content.Load<Texture2D>("Sprites/logo");

            /// loading sprites

            Static.Contents.Sprites.Pix = new Sprite(Static.Contents.Textures.Pix, Static.Contents.Textures.Pix.GetRectangle());

            Static.Contents.Sprites.ControlButton_fall = new Sprite(Static.Contents.Textures.ControlButton_fall, Static.Contents.Textures.ControlButton_fall.GetRectangle());
            Static.Contents.Sprites.ControlButton_left = new Sprite(Static.Contents.Textures.ControlButton_left, Static.Contents.Textures.ControlButton_left.GetRectangle());
            Static.Contents.Sprites.ControlButton_right = new Sprite(Static.Contents.Textures.ControlButton_right, Static.Contents.Textures.ControlButton_right.GetRectangle());
            Static.Contents.Sprites.ControlButton_rotate = new Sprite(Static.Contents.Textures.ControlButton_rotate, Static.Contents.Textures.ControlButton_rotate.GetRectangle());

            Static.Contents.Sprites.Button_pause = new Sprite(Static.Contents.Textures.Button_pause, Static.Contents.Textures.Button_pause.GetRectangle());
            Static.Contents.Sprites.Button_exit = new Sprite(Static.Contents.Textures.Button_exit, Static.Contents.Textures.Button_exit.GetRectangle());
            Static.Contents.Sprites.Button_play = new Sprite(Static.Contents.Textures.Button_play, Static.Contents.Textures.Button_play.GetRectangle());
            Static.Contents.Sprites.Button_settings = new Sprite(Static.Contents.Textures.Button_settings, Static.Contents.Textures.Button_settings.GetRectangle());
            Static.Contents.Sprites.Button_highscore = new Sprite(Static.Contents.Textures.Button_highscore, Static.Contents.Textures.Button_highscore.GetRectangle());
            Static.Contents.Sprites.Button_left = new Sprite(Static.Contents.Textures.Button_left, Static.Contents.Textures.Button_left.GetRectangle());
            Static.Contents.Sprites.Button_right = new Sprite(Static.Contents.Textures.Button_right, Static.Contents.Textures.Button_right.GetRectangle());
            Static.Contents.Sprites.Button_left_small = new Sprite(Static.Contents.Textures.Button_left_small, Static.Contents.Textures.Button_left_small.GetRectangle());
            Static.Contents.Sprites.Button_right_small = new Sprite(Static.Contents.Textures.Button_right_small, Static.Contents.Textures.Button_right_small.GetRectangle());
            Static.Contents.Sprites.Button_up_medium = new Sprite(Static.Contents.Textures.Button_up_medium, Static.Contents.Textures.Button_up_medium.GetRectangle());
            Static.Contents.Sprites.Button_down_medium = new Sprite(Static.Contents.Textures.Button_down_medium, Static.Contents.Textures.Button_down_medium.GetRectangle());
            Static.Contents.Sprites.Button_empty = new Sprite(Static.Contents.Textures.Button_empty, Static.Contents.Textures.Button_empty.GetRectangle());
            Static.Contents.Sprites.Button_bonus = new Sprite(Static.Contents.Textures.Button_bonus, Static.Contents.Textures.Button_bonus.GetRectangle());

            Static.Contents.Sprites.BackgroundGame = new Sprite(Static.Contents.Textures.BackgroundGame, Static.Contents.Textures.BackgroundGame.GetRectangle());
            Static.Contents.Sprites.BackgroundMenu = new Sprite(Static.Contents.Textures.BackgroundMenu, Static.Contents.Textures.BackgroundMenu.GetRectangle());
            Static.Contents.Sprites.Dialog_background = new Sprite(Static.Contents.Textures.Dialog_background, Static.Contents.Textures.Dialog_background.GetRectangle());
            Static.Contents.Sprites.Dialog_inside = new Sprite(Static.Contents.Textures.Dialog_inside, Static.Contents.Textures.Dialog_inside.GetRectangle());

            Static.Contents.Sprites.GameUI_top_background = new Sprite(Static.Contents.Textures.GameUI_top_background, Static.Contents.Textures.GameUI_top_background.GetRectangle());
            Static.Contents.Sprites.GameUI_bottom_classic_background = new Sprite(Static.Contents.Textures.GameUI_bottom_classic_background, Static.Contents.Textures.GameUI_bottom_classic_background.GetRectangle());
            Static.Contents.Sprites.GameUI_bottom_normal_background = new Sprite(Static.Contents.Textures.GameUI_bottom_normal_background, Static.Contents.Textures.GameUI_bottom_normal_background.GetRectangle());
            Static.Contents.Sprites.GameUI_playingArena_border = new Sprite(Static.Contents.Textures.GameUI_playingArena_border, Static.Contents.Textures.GameUI_playingArena_border.GetRectangle());

            Static.Contents.Sprites.Dialog_icon_questionMark = new Sprite(Static.Contents.Textures.Dialog_icon_questionMark, Static.Contents.Textures.Dialog_icon_questionMark.GetRectangle());
            Static.Contents.Sprites.Dialog_icon_settings = new Sprite(Static.Contents.Textures.Dialog_icon_settings, Static.Contents.Textures.Dialog_icon_settings.GetRectangle());
            Static.Contents.Sprites.Dialog_icon_highscore = new Sprite(Static.Contents.Textures.Dialog_icon_highscore, Static.Contents.Textures.Dialog_icon_highscore.GetRectangle());

            Static.Contents.Sprites.Star_small = new Sprite(Static.Contents.Textures.Star_small, Static.Contents.Textures.Star_small.GetRectangle());
            Static.Contents.Sprites.Star_medium_01 = new Sprite(Static.Contents.Textures.Star_medium_01, Static.Contents.Textures.Star_medium_01.GetRectangle());
            Static.Contents.Sprites.Star_medium_02 = new Sprite(Static.Contents.Textures.Star_medium_02, Static.Contents.Textures.Star_medium_02.GetRectangle());
            Static.Contents.Sprites.Star_big = new Sprite(Static.Contents.Textures.Star_big, Static.Contents.Textures.Star_big.GetRectangle());

            Static.Contents.Sprites.Logo = new Sprite(Static.Contents.Textures.Logo, Static.Contents.Textures.Logo.GetRectangle());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            //Static.Contents.Textures.Pix.Dispose();
            //Static.Contents.Textures.Pix = null;
            //Static.Contents.Textures.ControlButton_fall.Dispose();
            //Static.Contents.Textures.ControlButton_fall = null;
            //Static.Contents.Textures.ControlButton_left.Dispose();
            //Static.Contents.Textures.ControlButton_left = null;
            //Static.Contents.Textures.ControlButton_right.Dispose();
            //Static.Contents.Textures.ControlButton_right = null;
            //Static.Contents.Textures.ControlButton_rotate.Dispose();
            //Static.Contents.Textures.ControlButton_rotate = null;
            //Static.Contents.Textures.ControlButton_pause.Dispose();
            //Static.Contents.Textures.ControlButton_pause = null;
            //Static.Contents.Textures.BackgroundGame.Dispose();
            //Static.Contents.Textures.BackgroundGame = null;
            //Static.Contents.Textures.BackgroundMenu.Dispose();
            //Static.Contents.Textures.BackgroundMenu = null;
            //Static.Contents.Textures.BorderedButtonBackground.Dispose();
            //Static.Contents.Textures.BorderedButtonBackground = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            RoomManager.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            RoomManager.Draw(gameTime, spriteBatch, GraphicsDevice);
        }
    }
}
