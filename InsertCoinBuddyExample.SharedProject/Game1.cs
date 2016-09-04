using InputHelper;
using InsertCoinBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InsertCoinBuddyExample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : ControllerGame
	{
		/// <summary>
		/// The credit manager.
		/// </summary>
		private IInsertCoinComponent _insertCoin;

		/// <summary>
		/// Component used to save system settings
		/// </summary>
		private ISettingsComponent _settings;

		public Game1()
		{
			//FullScreen = true;

			var debug = new DebugInputComponent(this, ResolutionBuddy.Resolution.TransformationMatrix);

			//Setup the credits manager.
			_insertCoin = new InsertCoinComponent(this, "coindrop", "gamestart", 3); //$.75 per game
			Components.Add(_insertCoin);

			//Add the settings manager
			_settings = new SettingsComponent<SettingsScreen>(this, Keys.K, Buttons.Back);
			Components.Add(_settings);
		}

		protected override void LoadContent()
		{
			// Activate the first screens.
			ScreenManager.SetTopScreen(new InsertCoinScreen(@"Fonts\ArialBlack24", @"Fonts\ArialBlack24", _insertCoin), null);

			base.LoadContent();
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void InitStyles()
		{
			base.InitStyles();
			//DefaultStyles.Instance().MainStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuEntryStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuTitleStyle.HasOutline = true;
			//DefaultStyles.Instance().MessageBoxStyle.HasOutline = true;
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// TODO: Add your update logic here
			base.Update(gameTime);
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new BackgroundScreen(), new MainMenuScreen() };
		}
	}
}

