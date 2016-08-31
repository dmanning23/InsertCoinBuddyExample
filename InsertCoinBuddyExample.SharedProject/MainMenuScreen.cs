using MenuBuddy;

namespace InsertCoinBuddyExample
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	public class MainMenuScreen : MenuScreen, IMainMenu
	{
		#region Methods

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen() : base("Main Menu")
		{
		}

		public override void LoadContent()
		{
		}

		#endregion //Methods
	}
}