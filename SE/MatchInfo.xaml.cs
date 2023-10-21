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
            match.matchNumber = int.Parse(MatchNumberEntry.Text.ToString());
            match.teamNumber = int.Parse(TeamNumberEntry.Text.ToString());
        }
        catch
        {
            await DisplayAlert("Alert", "Please insure that all the fields are filled out correctly.", "OK");
            if(!AllianceLabel.Text.Contains("Pink"))
            {
                await Navigation.PushAsync(new ScoutingPage(match));
            }
            else
            {
                await DisplayAlert("Alert", "Please select an alliance.", "OK");
            }
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