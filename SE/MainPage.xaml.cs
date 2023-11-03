namespace SE;

public partial class MainPage : ContentPage
{
    private XMLParser parser;
    private Match match;
    private int clickCount = 0;
    private int unlockNumber = 1;

	public MainPage()
	{
		InitializeComponent();
        parser = new XMLParser();
        match = new Match();
        VersionNumberLabel.Text = parser.GetItemById("AppVersion");
    }

    // https://raw.githubusercontent.com/frc5687/ScoutEye/main/configs/config.xml

    private async void OnToScoutingClicked(object sender, EventArgs e)
	{
		try
		{
            await Navigation.PushAsync(new MatchInfo(ScoutNameEntry.Text.ToString()));
        }
        catch
		{
			await DisplayAlert("Alert", "Please enter a name", "OK");
		}
    }

    private async void OnHorusClicked(object sender, EventArgs e)
    {
        if(clickCount == unlockNumber)
        {
            match.scoutName = "Honey Thief";
            match.matchNumber = 0;
            match.teamNumber = 5687;

            await Navigation.PushAsync(new ScoutingPage(match));
        }
        else
        {
            clickCount++;
        }
    }

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
}

