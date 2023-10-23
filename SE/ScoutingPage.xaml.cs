namespace SE;
using Syncfusion.Maui.Picker;
using System.Collections.ObjectModel;

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
        //ObservableCollection<object> cityName = new ObservableCollection<object>();
        //cityName.Add("Chennai");
        //cityName.Add("Mumbai");
        //cityName.Add("Delhi");
        //cityName.Add("Kolkata");
        //cityName.Add("Bangalore");
        //cityName.Add("Hyderabad");
        //cityName.Add("Pune");
        //cityName.Add("Ahmedabad");
        //cityName.Add("Jaipur");
        //cityName.Add("Lucknow");
        //cityName.Add("Chandigarh");
        //PickerColumn pickerColumn = new PickerColumn()
        //{
        //    HeaderText = "Select City",
        //    ItemsSource = cityName,
        //    SelectedIndex = 1,
        //};
        //this.picker.Columns.Add(pickerColumn);

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
       // auto1.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto0Hide"));
        auto1Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto0Hide"));
        auto2.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto1Hide"));
        auto2Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto1Hide"));
        auto3.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto2Hide"));
        auto3Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto2Hide"));
        auto4.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto3Hide"));
        auto4Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto3Hide"));
        auto5.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto4Hide"));
        auto5Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto4Hide"));
        auto6.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto5Hide"));
        auto6Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Auto5Hide"));

        // Determine visibility of teleoperated trackables and their respective labels
        teleop1.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop0Hide"));
        teleop1Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop0Hide"));
        teleop2.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop1Hide"));
        teleop2Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop1Hide"));
        teleop3.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop2Hide"));
        teleop3Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop2Hide"));
        teleop4.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop3Hide"));
        teleop4Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop3Hide"));
        teleop5.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop4Hide"));
        teleop5Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop4Hide"));
        teleop6.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop5Hide"));
        teleop6Label.IsVisible = !Convert.ToBoolean(parser.GetItemById("Teleop5Hide"));

        // Get ready from stupid stupid code

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