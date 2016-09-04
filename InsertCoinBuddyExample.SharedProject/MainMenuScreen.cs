using System;
using HadoukInput;
using InsertCoinBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InsertCoinBuddyExample
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	public class MainMenuScreen : MenuScreen, IMainMenu, IGameScreen
	{
		/// <summary>
		/// The credit manager.
		/// </summary>
		private IInsertCoinComponent _insertCoinComponent;

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen() : base("Main Menu")
		{
		}

		public override void LoadContent()
		{
			_insertCoinComponent = ScreenManager.Game.Services.GetService(typeof(IInsertCoinComponent)) as IInsertCoinComponent;


			base.LoadContent();
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
		}

		public void HandleInput(InputState input)
		{
			//Listen for P1 game start...
			if (input.IsNewKeyPress(Keys.Q))
			{
				if (_insertCoinComponent.StartGame(PlayerIndex.One))
				{
					LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen(_insertCoinComponent));
					_insertCoinComponent.GameInPlay = true;
				}
			}

			//Listen for P2 game start...
			if (input.IsNewKeyPress(Keys.W))
			{
				if (_insertCoinComponent.StartGame(PlayerIndex.Two))
				{
					LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen(_insertCoinComponent));
					_insertCoinComponent.GameInPlay = true;
				}
			}
		}
	}
}