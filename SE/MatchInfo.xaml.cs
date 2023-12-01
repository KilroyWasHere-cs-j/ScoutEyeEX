namespace SE;

public partial class MatchInfo : ContentPage
{
	private Match match;
    private LastMatchInfo lastMatchInfo;
	public MatchInfo(LastMatchInfo lastMatchInfo)
	{
		InitializeComponent();
		match = new Match();
        match.scoutName = lastMatchInfo.scoutName;
        MatchNumberEntry.Text = lastMatchInfo.matchNumber.ToString();
	}

	private async void OnScoutButtonClicked(object sender, EventArgs e)
	{
        try
        {
            match.matchNumber = (int)Int64.Parse(MatchNumberEntry.Text.ToString());
            match.teamNumber = (int)Int64.Parse(TeamNumberEntry.Text.ToString());
            if (!AllianceLabel.Text.Contains("Pink"))
            {
                await Navigation.PushAsync(new ScoutingPage(match));
            }
        }
        catch
        {
            await DisplayAlert("Alert", "Please insure that Match Number and Team Number are correctly completed.", "OK");
        }
    }

    private async void OnToDevClicked(object sender, EventArgs e)
    {
        try
        {
            if (match.scoutName.Contains("Admin"))
            {
                await Navigation.PushAsync(new DevPage());
            }
        }
        catch
        {
            await DisplayAlert("Alert", "Invaild Dev password", "OK");
        }
    }

    private void OnAllianceToggledClicked(object sender, EventArgs e)
	{
        match.isBlue ^= true;
        if (match.isBlue == true)
        {
            AllianceLabel.Text = "Blue Alliance";
        }
        else
        {
            AllianceLabel.Text = "Red Alliance";
        }
    }
}