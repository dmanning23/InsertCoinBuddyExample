using System;
using FontBuddyLib;
using HadoukInput;
using InsertCoinBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
using System.Threading;

namespace InsertCoinBuddyExample
{
	/// <summary>
	/// This screen displays on top of all the other screens
	/// </summary>
	internal class GameplayScreen : Screen, IGameScreen
	{
		#region Fields

		const float TextVelocity = 3.0f;

		/// <summary>
		/// current location of the text
		/// </summary>
		Vector2 TextLocation = Vector2.Zero;

		/// <summary>
		/// current direction the text is travelling in
		/// </summary>
		Vector2 TextDirection;

		/// <summary>
		/// thing for writing text
		/// </summary>
		FontBuddy Text;

		IInsertCoinComponent _insertCoinComponent;

		#endregion //Fields

		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public GameplayScreen()
		{
			TextLocation = new Vector2(Resolution.TitleSafeArea.Center.X, Resolution.TitleSafeArea.Center.Y);
			TextDirection = new Vector2(TextVelocity, TextVelocity);
			Text = new FontBuddy();

			CoveredByOtherScreens = false;
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			base.LoadContent();

			_insertCoinComponent = ScreenManager.Game.Services.GetService(typeof(IInsertCoinComponent)) as IInsertCoinComponent;
			_insertCoinComponent.Credits.OnGameStart += OnStartGame;

			//Thread.Sleep(2000);
			Text.Font = ScreenManager.Game.Content.Load<SpriteFont>(@"Fonts\ArialBlack72");
		}

		public override void UnloadContent()
		{
			base.UnloadContent();

			_insertCoinComponent.Credits.OnGameStart -= OnStartGame;
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

			if (HasFocus)
			{
				//move the text
				TextLocation += TextDirection;

				//bounce the text off the walls
				if ((TextLocation.X - 256) <= 0)
				{
					TextDirection.X = TextVelocity;
				}
				else if ((TextLocation.X + 256) >= Resolution.ScreenArea.Right)
				{
					TextDirection.X = -TextVelocity;
				}

				if (TextLocation.Y <= 0)
				{
					TextDirection.Y = TextVelocity;
				}
				else if ((TextLocation.Y + 128) >= Resolution.ScreenArea.Bottom)
				{
					TextDirection.Y = -TextVelocity;
				}
			}
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			//draw the text
			ScreenManager.SpriteBatchBegin();
			Text.Write("Gameplay Screen!!!", TextLocation, Justify.Center, 1.0f, Color.Red, ScreenManager.SpriteBatch, Time);

			Vector2 quitLocation = new Vector2(Resolution.TitleSafeArea.Center.X, Resolution.TitleSafeArea.Top);

			Text.Write("Press 'space' to end game", quitLocation, Justify.Center, 0.75f, Color.Green, ScreenManager.SpriteBatch, Time);

			ScreenManager.SpriteBatchEnd();
		}

		public void HandleInput(InputState input)
		{
			if (IsActive)
			{
				//Listen for P1 game start...
				if (input.IsNewKeyPress(Keys.Q))
				{
					_insertCoinComponent.PlayerButtonPressed(PlayerIndex.One);
				}

				//Listen for P2 game start...
				if (input.IsNewKeyPress(Keys.W))
				{
					_insertCoinComponent.PlayerButtonPressed(PlayerIndex.Two);
				}
			}

			//does the uesr want to exit?
			if (input.IsNewKeyPress(Keys.Space))
			{
				//Load the main menu back up
				LoadingScreen.Load(ScreenManager, true, null, ScreenManager.MainMenuStack());

				//the game isn't playing anymore
				_insertCoinComponent.GameFinished();
			}
		}

		public void OnStartGame(object obj, GameStartEventArgs e)
		{
			ScreenManager.AddScreen(new NewChallengerScreen(), null);
		}

		#endregion
	}
}