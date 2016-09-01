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
		private ICreditsManager _creditManager;

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen() : base("Main Menu")
		{
		}

		public override void LoadContent()
		{
			_creditManager = ScreenManager.Game.Services.GetService(typeof(ICreditsManager)) as ICreditsManager;


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
				if (_creditManager.StartGame(PlayerIndex.One))
				{
					LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen(_creditManager));
					_creditManager.GameInPlay = true;
				}
			}

			//Listen for P2 game start...
			if (input.IsNewKeyPress(Keys.W))
			{
				if (_creditManager.StartGame(PlayerIndex.Two))
				{
					LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen(_creditManager));
					_creditManager.GameInPlay = true;
				}
			}
		}
	}
}