namespace SE;

/// <summary>
/// This is the main page of the app. It allows users to navigate to the ScoutingPage, HeaderQRPage, and MatchInfo pages.
/// 
/// Author: Gabriel Tower
/// Written: 11/2023
/// 
/// Kilroy Was Here
/// </summary>

public partial class MainPage : ContentPage
{
    private XMLParser parser;
    private Match match;
    private LastMatchInfo lastMatchInfo;
    
    // Number of times Horus is clicked
    private int clickCount = 0;
    // Number of times Horus must be clicked to unlock
    private int unlockNumber = 3;

	public MainPage()
	{
		InitializeComponent();
        
        // Initialize the XMLParser, Match, and LastMatchInfo objects
        parser = new XMLParser();
        match = new Match();
        lastMatchInfo = new LastMatchInfo();

        // Set the version number label
        VersionNumberLabel.Text = parser.GetItemById("AppVersion");
        
        // Display the name of the current game
        GameNameLabel.Text = parser.GetItemById("GameName");
    }

    // https://raw.githubusercontent.com/frc5687/ScoutEye/main/configs/config.xml

    #region Event Handlers
    ///<summary>
    ///This method is called when the user clicks the "To Scouting" button
    ///</summary>
    private async void OnToScoutingClicked(object sender, EventArgs e)
    {
        try
        {
            lastMatchInfo.scoutName = ScoutNameEntry.Text.ToString();
            await Navigation.PushAsync(new MatchInfo(lastMatchInfo));
        }
        catch
        {
            await DisplayAlert("Alert", "Please enter a name", "OK");
        }
    }

    ///<summary>
    ///This method is called when the user clicks the "To Settings" button
    ///</summary>
    private async void OnHorusClicked(object sender, EventArgs e)
    {
        if(clickCount == unlockNumber)
        {
            match.scoutName = "Frau Blucher";
            match.matchNumber = 0;
            match.teamNumber = 5687;

            await Navigation.PushAsync(new ScoutingPage(match));
        }
        else
        {
            clickCount++;
        }
    }

    ///<summary>
    ///This method is called when the user clicks the "To Header QR" button
    ///</summary>s
    private async void OnToHeaderQRPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HeaderQRPage());
    }

    ///<summary>
    ///Forces light mode for Windows or Android
    ///</summary>
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
#if WINDOWS
            Microsoft.UI.Xaml.Window window = (Microsoft.UI.Xaml.Window)App.Current.Windows.First<Window>().Handler.PlatformView;
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(800,600));
#endif
#if WINDOWS
          WelcomeLabel.Margin = new Thickness(20, 0, 0, 0);
#endif
    }
    #endregion
}

