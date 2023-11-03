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
        // Name all the autonomous trackables
        auto1Label.Text = parser.GetItemById("Auto0");
        auto2Label.Text = parser.GetItemById("Auto1");
        auto3Label.Text = parser.GetItemById("Auto2");
        auto4Label.Text = parser.GetItemById("Auto3");
        auto5Label.Text = parser.GetItemById("Auto4");
        auto6Label.Text = parser.GetItemById("Auto5");

        // Name all the teleoperated trackables
        teleop1Label.Text = parser.GetItemById("Teleop0");
        teleop2Label.Text = parser.GetItemById("Teleop1");
        teleop3Label.Text = parser.GetItemById("Teleop2");
        teleop4Label.Text = parser.GetItemById("Teleop3");
        teleop5Label.Text = parser.GetItemById("Teleop4");
        teleop6Label.Text = parser.GetItemById("Teleop5");

        // Determine visibility of autonomous trackables and their respective labels
        auto1.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto0Hide"));
        auto1Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto0Hide"));
        auto1Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto0Hide"));
        auto2.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto1Hide"));
        auto2Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto1Hide"));
        auto2Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto1Hide"));
        auto3.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto2Hide"));
        auto3Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto2Hide"));
        auto3Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto2Hide"));
        auto4.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto3Hide"));
        auto4Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto3Hide"));
        auto4Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto3Hide"));
        auto5.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto4Hide"));
        auto5Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto4Hide"));
        auto5Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto4Hide"));
        auto6.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto5Hide"));
        auto6Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto5Hide"));
        auto6Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto5Hide"));

        // Determine visibility of teleoperated trackables and their respective labels
        teleop1.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop0Hide"));
        teleop1Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop0Hide"));
        teleop1Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop0Hide"));
        teleop2.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop1Hide"));
        teleop2Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop1Hide"));
        teleop2Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop1Hide"));
        teleop3.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop2Hide"));
        teleop3Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop2Hide"));
        teleop3Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop2Hide"));
        teleop4.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop3Hide"));
        teleop4Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop3Hide"));
        teleop4Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop3Hide"));
        teleop5.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop4Hide"));
        teleop5Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop4Hide"));
        teleop5Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop4Hide"));
        teleop6.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop5Hide"));
        teleop6Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop5Hide"));
        teleop6Stepper.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop5Hide"));

        auto1Stepper.Value = 1;
        auto2Stepper.Value = 1;
        auto3Stepper.Value = 1;
        auto4Stepper.Value = 1;
        auto5Stepper.Value = 1;
        auto6Stepper.Value = 1;
        teleop1Stepper.Value = 1;
        teleop2Stepper.Value = 1;
        teleop3Stepper.Value = 1;
        teleop4Stepper.Value = 1;
        teleop5Stepper.Value = 1;
        teleop6Stepper.Value = 1;

        auto1.SelectedIndex = 1;
        auto2.SelectedIndex = 1;
        auto3.SelectedIndex = 1;
        auto4.SelectedIndex = 1;
        auto5.SelectedIndex = 1;
        auto6.SelectedIndex = 1;
        teleop1.SelectedIndex = 1;
        teleop2.SelectedIndex = 1;
        teleop3.SelectedIndex = 1;
        teleop4.SelectedIndex = 1;
        teleop5.SelectedIndex = 1;
        teleop6.SelectedIndex = 1;

        for (int i = 0; i <= 5; i++)
        {
            givesDef.Items.Add(i.ToString());
            takesDef.Items.Add(i.ToString());
        }

        for (int i = 0; i <= 10; i++)
        {
            robotSpeed.Items.Add(i.ToString());
        }
        // Get ready from stupid stupid code

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
    }

    private string[] GetFill(string id)
    {
        string content = parser.GetItemById(id);
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
        {
            return content.Split(',');
        }
    }

    private async void LogMatch()
    {
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

    private void ClearMatch()
    {
        auto1.SelectedIndex = 0;
        auto2.SelectedIndex = 0;
        auto3.SelectedIndex = 0;
        auto4.SelectedIndex = 0;
        auto5.SelectedIndex = 0;
        auto6.SelectedIndex = 0;
        teleop1.SelectedIndex = 0;
        teleop2.SelectedIndex = 0;
        teleop3.SelectedIndex = 0;
        teleop4.SelectedIndex = 0;
        teleop5.SelectedIndex = 0;
        teleop6.SelectedIndex = 0;

        auto1Stepper.Value = 0;
        auto2Stepper.Value = 0;
        auto3Stepper.Value = 0;
        auto4Stepper.Value = 0;
        auto5Stepper.Value = 0;
        auto6Stepper.Value = 0;
        teleop1Stepper.Value = 0;
        teleop2Stepper.Value = 0;
        teleop3Stepper.Value = 0;
        teleop4Stepper.Value = 0;
        teleop5Stepper.Value = 0;
        teleop6Stepper.Value = 0;

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
        match.teleop1 = "0";
        match.teleop2 = "0";
        match.teleop3 = "0";
        match.teleop4 = "0";
        match.teleop5 = "0";
        match.teleop6 = "0";

        match.robotSpeed = 0;
        match.givesDefense = 0;
        match.takesDefense = 0;

        match.robotDied = false;
        match.fieldFault = false;
    }

    #region EventHandlers
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

    private async void OnResetClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Are you sure you want to clear this match? This action cannot be undone.", "Yes", "No");
        switch (response)
        {
            case true:
                ClearMatch();  
                break;
            case false:
                break;
        }
    }

    // Please Gabe find a better way of doing this

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
    #endregion
}