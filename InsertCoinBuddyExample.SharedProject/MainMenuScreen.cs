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
			base.LoadContent();

			_insertCoinComponent = ScreenManager.Game.Services.GetService(typeof(IInsertCoinComponent)) as IInsertCoinComponent;
			_insertCoinComponent.Credits.OnGameStart += OnStartGame;
		}

		public override void UnloadContent()
		{
			base.UnloadContent();

			_insertCoinComponent.Credits.OnGameStart -= OnStartGame;
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
				_insertCoinComponent.PlayerButtonPressed(PlayerIndex.One);
			}

			//Listen for P2 game start...
			if (input.IsNewKeyPress(Keys.W))
			{
				_insertCoinComponent.PlayerButtonPressed(PlayerIndex.Two);
			}
		}

		public void OnStartGame(object obj, GameStartEventArgs e)
		{
			LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen());
		}
	}
}