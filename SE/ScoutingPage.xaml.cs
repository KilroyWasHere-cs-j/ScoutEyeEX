namespace SE;

using Microsoft.Maui.Controls;

/// <summary>
/// This is the page of the app where users can scout matches.
/// 
/// This entire page is a mess and needs an exorcism
/// 
/// Author: Gabriel Tower
/// Written: 11/2023
/// 
/// Last Updated: 2/24/2024
/// 
/// Kilroy Was Here
/// </summary>

public partial class ScoutingPage : ContentPage
{
    // Initialize the Match and XMLParser objects
    private Match match;
    private XMLParser parser;
    
	public ScoutingPage(Match match)
	{
		InitializeComponent();
        parser = new XMLParser();
		this.match = match;

        // Populate the pages labels with the match number and team number
		WelcomeMessageLabel.Text = "Lets Scout " + match.scoutName + "!";
		MatchNumberLabel.Text = "Match Num: " + match.matchNumber;
		TeamNumberLabel.Text = "Team Num: " + match.teamNumber;

        // Loads the trackables into the page
        LoadPage();
    }

    /// <summary>
    /// Loads the trackables onto the page from an XML file
    /// </summary>
    private void LoadPage()
    {
        int label_count = -1;
        int stepper_count = 0;
        int picker_count = 0;
        int border_count = 0;
        foreach (var autos_child in trackables_auto.Children)
        { 
            switch (autos_child)
            {
                case Label:
                    Label label = (Label)autos_child;
                    if (label_count == -1)
                    {
                        label.Text = "Autonomous";
                        label_count++;
                    }
                    else
                    {
                        label.Text = parser.GetItemById("Auto" + label_count.ToString());
                        label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto" + label_count.ToString() + "Hide"));
                        label_count++;
                    }
                    break;

                case Border:
                    Border border = (Border)autos_child;
                    border.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto" + border_count.ToString() + "Hide"));
                    border_count++;
                    break;

                case Stepper:
                    Stepper stepper = (Stepper)autos_child;
                    stepper.Value = 0;
                    stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto" + stepper_count.ToString() + "Hide"));
                    stepper_count++;
                    break;
            }
        }

        label_count = -1;
        stepper_count = 0;
        picker_count = 0;
        border_count = 0;
        foreach (var teleops_child in trackables_teleop.Children)
        {
            switch (teleops_child)
            {
                case Label:
                    Label label = (Label)teleops_child;
                    if (label_count == -1)
                    {
                        label.Text = "Teleoperated";
                        label_count++;
                    }
                    else
                    {
                        label.Text = parser.GetItemById("Teleop" + label_count.ToString());
                        label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop" + label_count.ToString() + "Hide"));
                        label_count++;
                    }
                    break;

                case Picker:
                    Picker picker = (Picker)teleops_child;
                    picker.SelectedIndex = 0;
                    picker_count++;
                    break;

                case Border:
                    Border border = (Border)teleops_child;
                    border.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop" + border_count.ToString() + "Hide"));
                    border_count++;
                    break;

                case Stepper:
                    Stepper stepper = (Stepper)teleops_child;
                    stepper.Value = 0;
                    stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop" + stepper_count.ToString() + "Hide"));
                    stepper_count++;
                    break;
            }
        }
        // Sets the stepper values to 0

        // Populate the trackable values

        for (int i = 0; i <= 5; i++)
        {
            givesDef.Items.Add(i.ToString());
            takesDef.Items.Add(i.ToString());
        }

        for (int i = 0; i <= 10; i++)
        {
            robotSpeed.Items.Add(i.ToString());
        }

        foreach(var i in GetFill("Auto0Items"))
        {
            auto1.Items.Add(i);
        }

        foreach (var i in GetFill("Auto1Items"))
        {
            auto2.Items.Add(i);
        }

        foreach (var i in GetFill("Auto2Items"))
        {
            auto3.Items.Add(i);
        }

        foreach (var i in GetFill("Auto3Items"))
        {
            auto4.Items.Add(i);
        }

        foreach (var i in GetFill("Auto4Items"))
        {
            auto5.Items.Add(i);
        }

        foreach (var i in GetFill("Auto5Items"))
        {
            auto6.Items.Add(i);
        }

        foreach (var i in GetFill("Auto6Items"))
        {
            auto7.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop0Items"))
        {
            teleop1.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop1Items"))
        {
            teleop2.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop2Items"))
        {
            teleop3.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop3Items"))
        {
            teleop4.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop4Items"))
        {
            teleop5.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop5Items"))
        {
            teleop6.Items.Add(i);
        }

        foreach (var i in GetFill("Teleop6Items"))
        {
            teleop7.Items.Add(i);
        }
    }

    /// <summary>
    /// Gets the fill for a trackable from an XML file
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private string[] GetFill(string id)
    {
        // Gets the value that determine the type of trackable fill
        string content = parser.GetItemById(id);
        // Fill is all possitive intergers from 0 to 1000
        if(content.Contains("NumFill"))
        {
            string[] nums = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                nums[i] = i.ToString();
            }
            return nums;
        }
        else
        // Otherwise the fill is a split the content up by commas
        {
            return content.Split(',');
        }
    }

    /// <summary>
    /// Enters the trackables values into the Match objects respective fields
    /// Will set the value to "0" if no value can be found for a trackable
    /// </summary>
    private async void LogMatch()
    {
        // TODO: Find a way of doing this without try/catch, currently if the trackable is missing an excetable value an exception will be thrown
        try
        {
            match.auto1 = auto1.SelectedItem.ToString();
        }
        catch
        {
            match.auto1 = "0";
        }
        try
        {
            match.auto2 = auto2.SelectedItem.ToString();
        }
        catch
        {
            match.auto2 = "0";
        }
        try
        {
            match.auto3 = auto3.SelectedItem.ToString();
        }
        catch
        {
            match.auto3 = "0";
        }
        try
        {
            match.auto4 = auto4.SelectedItem.ToString();
        }
        catch
        {
            match.auto4 = "0";
        }
        try
        {
            match.auto5 = auto5.SelectedItem.ToString();
        }
        catch
        {
            match.auto5 = "0";
        }
        try
        {
            match.auto6 = auto6.SelectedItem.ToString();
        }
        catch
        {
            match.auto6 = "0";
        }
        try
        {
            match.auto7 = auto7.SelectedItem.ToString();
        }
        catch
        {
            match.auto7 = "0";
        }
        try
        {
            match.teleop1 = teleop1.SelectedItem.ToString();
        }
        catch
        {
            match.teleop1 = "0";
        }
        try
        {
            match.teleop2 = teleop2.SelectedItem.ToString();
        }
        catch
        {
            match.teleop2 = "0";
        }
        try
        {
            match.teleop3 = teleop3.SelectedItem.ToString();
        }
        catch
        {
            match.teleop3 = "0";
        }
        try
        {
            match.teleop4 = teleop4.SelectedItem.ToString();
        }
        catch
        {
            match.teleop4 = "0";
        }
        try
        {
            match.teleop5 = teleop5.SelectedItem.ToString();
        }
        catch
        {
            match.teleop5 = "0";
        }
        try
        {
            match.teleop6 = teleop6.SelectedItem.ToString();
        }
        catch
        {
            match.teleop6 = "0";
        }
        try
        {
            match.teleop7 = teleop7.SelectedItem.ToString();
        }
        catch
        {
            match.teleop7 = "0";
        }
        try
        {
            match.robotSpeed = Convert.ToInt32(robotSpeed.SelectedItem.ToString());
        }
        catch
        {
            match.robotSpeed = 0;
        }
        try
        {
            match.givesDefense = Convert.ToInt32(givesDef.SelectedItem.ToString());
        }
        catch
        {
            match.givesDefense = 0;
        }
        try
        {
            match.takesDefense = Convert.ToInt32(takesDef.SelectedItem.ToString());
        }
        catch
        {
            match.takesDefense = 0;
        }
        try
        {
            match.robotDied = Convert.ToBoolean(robotDied.IsChecked);
        }
        catch
        {
            match.robotDied = false;
        }
        try
        {
            match.fieldFault = Convert.ToBoolean(fieldFault.IsChecked);
        }
        catch
        {
            match.fieldFault = false;
        }
        await Navigation.PushAsync(new QRPage(match));
    }

    /// <summary>
    /// Clears all the trackables and resets the Match object
    /// </summary>
    private void ClearMatch()
    {
        foreach(var autos_child in trackables_auto.Children)
        {
            switch (autos_child)
            {
                case Stepper:
                    Stepper stepper = (Stepper)autos_child;
                    stepper.Value = 0;
                    break;
            }
        }
        foreach(var teleops_child in trackables_teleop.Children)
        {
            switch (teleops_child)
            {
                case Stepper:
                    Stepper stepper = (Stepper)teleops_child;
                    stepper.Value = 0;
                    break;
            }
        }

        robotSpeed.SelectedIndex = 0;
        givesDef.SelectedIndex = 0;
        takesDef.SelectedIndex = 0;

        robotDied.IsChecked = false;
        fieldFault.IsChecked = false;

        match.auto1 = "0";
        match.auto2 = "0";
        match.auto3 = "0";
        match.auto4 = "0";
        match.auto5 = "0";
        match.auto6 = "0";
        match.auto7 = "0";

        match.teleop1 = "0";
        match.teleop2 = "0";
        match.teleop3 = "0";
        match.teleop4 = "0";
        match.teleop5 = "0";
        match.teleop6 = "0";
        match.teleop7 = "0";

        match.robotSpeed = 0;
        match.givesDefense = 0;
        match.takesDefense = 0;

        match.robotDied = false;
        match.fieldFault = false;
    }

    /// <summary>
    /// Reloads the page
    /// </summary>
    private void Dump()
    {
        // Is this even necessary?
        LoadPage();
        DisplayAlert("Alert", "UI cleared", "OK");
    }

    #region EventHandlers

    /// <summary>
    /// This method is called when the user clicks the "Log Match" button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnLogMatchClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Are you sure you want to submit this match? This action cannot be undone.", "Yes", "No");
        switch (response)
        {
            case true:
                LogMatch();
                break;
            case false:
                break;
        }
    }

    /// <summary>
    /// This method is called when the user clicks the "Reset" button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnResetClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Are you sure you want to clear this match? This action cannot be undone.", "Yes", "No");
        switch (response)
        {
            case true:
                ClearMatch();
                Dump();
                break;
            case false:
                break;
        }
    }

    // Please Gabe find a better way of doing this

    // All updates a field when the value of a associated stepper is changed

    private void Auto1StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto1.SelectedIndex = (int)e.NewValue;
    }

    private void Auto2StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto2.SelectedIndex = (int)e.NewValue;
    }

    private void Auto3StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto3.SelectedIndex = (int)e.NewValue;
    }

    private void Auto4StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto4.SelectedIndex = (int)e.NewValue;
    }

    private void Auto5StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto5.SelectedIndex = (int)e.NewValue;
    }

    private void Auto6StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto6.SelectedIndex = (int)e.NewValue;
    }
    private void Auto7StepChanged(object sender, ValueChangedEventArgs e)
    {
        auto7.SelectedIndex = (int)e.NewValue;
    }

    private void Teleop1StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop1.SelectedIndex = (int)e.NewValue;
    }

    private void Teleop2StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop2.SelectedIndex = (int)e.NewValue;
    }

    private void Teleop3StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop3.SelectedIndex = (int)e.NewValue;
    }

    private void Teleop4StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop4.SelectedIndex = (int)e.NewValue;
    }

    private void Teleop5StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop5.SelectedIndex = (int)e.NewValue;
    }

    private void Teleop6StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop6.SelectedIndex = (int)e.NewValue;
    }
    private void Teleop7StepChanged(object sender, ValueChangedEventArgs e)
    {
        teleop7.SelectedIndex = (int)e.NewValue;
    }
    #endregion
}