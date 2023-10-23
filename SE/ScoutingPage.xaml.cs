namespace SE;

using Syncfusion.Maui.Picker;
using System.Collections.ObjectModel;

public partial class ScoutingPage : ContentPage
{
    private Match match;
    private XMLParser parser;

    private int selectedindex;
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
        List<string> trackables = new List<string> { "Auto0", "Auto1", "Auto2", "Auto3", "Auto4", "Auto5", "Teleop0", "Teleop1", "Teleop2", "Teleop3", "Teleop4", "Teleop5"};

        foreach(var trackable in trackables)
        {
            ObservableCollection<object> data = new ObservableCollection<object>();
            foreach (var i in GetFill(trackable + "Items"))
            {
                data.Add(i);
            }
            PickerColumn pickerColumn = new PickerColumn()
            {
                HeaderText = "Peaches",
                ItemsSource = data,
                SelectedIndex = 0,
            };
            switch (trackable)
            {
                case "auto0":
                    this.auto1.Columns.Add(pickerColumn);
                    break;
                case "auto1":
                    this.auto2.Columns.Add(pickerColumn);
                    break;
                case "auto2":
                    this.auto3.Columns.Add(pickerColumn);
                    break;
                case "auto3":
                    this.auto4.Columns.Add(pickerColumn);
                    break;
                case "auto4":
                    this.auto5.Columns.Add(pickerColumn);
                    break;
                case "auto5":
                    this.auto6.Columns.Add(pickerColumn);
                    break;
                case "teleop0":
                    this.teleop1.Columns.Add(pickerColumn);
                    break;
                case "teleop1":
                    this.teleop2.Columns.Add(pickerColumn);
                    break;
                case "teleop2":
                    this.teleop3.Columns.Add(pickerColumn);
                    break;
                case "teleop3":
                    this.teleop4.Columns.Add(pickerColumn);
                    break;
                case "teleop4":
                    this.teleop5.Columns.Add(pickerColumn);
                    break;
                case "teleop5":
                    this.teleop6.Columns.Add(pickerColumn);
                    break;
            }
        }

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

    private void Dump()
    {
        this.auto1.Columns.Clear();
        this.auto2.Columns.Clear();
        this.auto3.Columns.Clear();
        this.auto4.Columns.Clear();
        this.auto5.Columns.Clear();

        LoadPage();
        DisplayAlert("Alert", "UI cleared", "OK");
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
                Dump();
                break;
            case false:
                break;
        }
    }
    #endregion
}