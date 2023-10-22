namespace SE;

public partial class MatchInfo : ContentPage
{
	Match match;
	public MatchInfo(string scoutName)
	{
		InitializeComponent();
		match = new Match();
		match.scoutName = scoutName;
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