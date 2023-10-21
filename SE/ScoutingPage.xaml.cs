namespace SE;

public partial class ScoutingPage : ContentPage
{
	private Match match;
    private XMLParser parser;
	public ScoutingPage(Match _match)
	{
		InitializeComponent();
        parser = new XMLParser();
		match = _match;
		WelcomeMessageLabel.Text = "Lets Scout " + match.scoutName + "!";
		MatchNumberLabel.Text = "Match Num: " + match.matchNumber;
		TeamNumberLabel.Text = "Team Num: " + match.teamNumber;
        LoadPage();
    }
    private void LoadPage()
	{
        // Name all the trackables
        auto1Label.Text = parser.GetItemById("Auto0");
        auto2Label.Text = parser.GetItemById("Auto1");
        auto3.Title = parser.GetItemById("Auto2");
        auto4.Title = parser.GetItemById("Auto3");
        auto5.Title = parser.GetItemById("Auto4");
        auto6.Title = parser.GetItemById("Auto5");

        teleop1.Title = parser.GetItemById("Teleop0");
        teleop2.Title = parser.GetItemById("Teleop1");
        teleop3.Title = parser.GetItemById("Teleop2");
        teleop4.Title = parser.GetItemById("Teleop3");
        teleop5.Title = parser.GetItemById("Teleop4");
        teleop6.Title = parser.GetItemById("Teleop5");


    }

    #region EventHandlers
    private async void OnLogMatchClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Are you sure you want to submit this match? This action cannot be undone.", "Yes", "No");
        switch (response)
        {
            case true:
                await Navigation.PushAsync(new QRPage(match));
                break;
            case false:
                break;
        }
    }

    private async void OnClearClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Are you sure you want to clear this match? This action cannot be undone.", "Yes", "No");
        switch (response)
        {
            case true:
                break;
            case false:
                break;
        }
    }
    #endregion
}