namespace SE;

/// <summary>
/// This is the MatchInfo page of the app. The user is brought here before going to the scouting page confirm alliance, match number, and team number.
/// 
/// It loads it's data to and from the Match object.
/// 
/// Author: Gabriel Tower
/// Written: 11/2023
/// 
/// Kilroy Was Here
/// </summary>

public partial class MatchInfo : ContentPage
{
	private Match match;
    private LastMatchInfo lastMatchInfo;

	public MatchInfo(LastMatchInfo lastMatchInfo)
	{
		InitializeComponent();
        // Initialize the Match object
		match = new Match();
        // Sets the scouts name
        match.scoutName = lastMatchInfo.scoutName;

        // Sets the match number
        MatchNumberEntry.Text = lastMatchInfo.matchNumber.ToString();
	}

    #region Event Handlers
    /// <summary>
    /// Runs when the scout button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnScoutButtonClicked(object sender, EventArgs e)
	{
        // attempt to parse the match number and team number
        try
        {
            match.matchNumber = (int)Int64.Parse(MatchNumberEntry.Text.ToString());
            match.teamNumber = (int)Int64.Parse(TeamNumberEntry.Text.ToString());
            // check to make sure that the user has selected an alliance
            if (!AllianceLabel.Text.Contains("Pink"))
            {
                await Navigation.PushAsync(new ScoutingPage(match));
            }
        }
        catch
        {
            // could not parse the match number or team number
            // most likely because the user did not enter a number
            await DisplayAlert("Alert", "Please insure that Match Number and Team Number are correctly completed.", "OK");
        }
    }

    /// <summary>
    /// Runs when the dev button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnToDevClicked(object sender, EventArgs e)
    {
        // check to make sure that the user has entered the correct password
        try
        {
            // pEaK SeCuRiTy
            if (match.scoutName.Contains("Admin"))
            {
               // await Navigation.PushAsync(new DevPage());
            }
        }
        catch
        {
            // the user entered the wrong password
            await DisplayAlert("Alert", "Invaild Dev password", "OK");
        }
    }

    /// <summary>
    /// Runs when the alliance button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnAllianceToggledClicked(object sender, EventArgs e)
	{
        // toggle the alliance
        // logical or
        match.isBlue ^= true;
        if (match.isBlue == true)
        {
            // set the match alliance field
            AllianceLabel.Text = "Blue Alliance";
        }
        else
        {
            // set the match alliance field
            AllianceLabel.Text = "Red Alliance";
        }
    }
    #endregion
}