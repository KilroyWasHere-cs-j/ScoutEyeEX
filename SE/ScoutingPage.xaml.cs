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
        // Find a better way of doing this
        ObservableCollection<object> data = new ObservableCollection<object>();
        foreach (var i in GetFill("Auto0Items"))
        {
            data.Add(i);
        }   
        PickerColumn pickerColumn = new PickerColumn()
        {
            HeaderText = "Select City",
            ItemsSource = data,
            SelectedIndex = 0,
        };
        this.auto1.Columns.Add(pickerColumn);

        ObservableCollection<object> data1 = new ObservableCollection<object>();
        foreach (var i in GetFill("Auto1Items"))
        {
            data1.Add(i);
        }
        PickerColumn pickerColumn1 = new PickerColumn()
        {
            HeaderText = "Select City",
            ItemsSource = data1,
            SelectedIndex = 0,
        };
        this.auto2.Columns.Add(pickerColumn1);

        ObservableCollection<object> data2 = new ObservableCollection<object>();
        foreach (var i in GetFill("Auto2Items"))
        {
            data2.Add(i);
        }
        PickerColumn pickerColumn2 = new PickerColumn()
        {
            HeaderText = "Select City",
            ItemsSource = data2,
            SelectedIndex = 0,
        };
        this.auto3.Columns.Add(pickerColumn2);

        ObservableCollection<object> data3 = new ObservableCollection<object>();
        foreach (var i in GetFill("Auto3Items"))
        {
            data3.Add(i);
        }
        PickerColumn pickerColumn3 = new PickerColumn()
        {
            HeaderText = "Select City",
            ItemsSource = data3,
            SelectedIndex = 0,
        };
        this.auto4.Columns.Add(pickerColumn3);

        ObservableCollection<object> data4 = new ObservableCollection<object>();
        foreach (var i in GetFill("Auto4Items"))
        {
            data4.Add(i);
        }
        PickerColumn pickerColumn4 = new PickerColumn()
        {
            HeaderText = "Select City",
            ItemsSource = data4,
            SelectedIndex = 0,
        };
        this.auto5.Columns.Add(pickerColumn4);

        ObservableCollection<object> data5 = new ObservableCollection<object>();
        foreach (var i in GetFill("Auto1Items"))
        {
            data5.Add(i);
        }
        PickerColumn pickerColumn5 = new PickerColumn()
        {
            HeaderText = "Select City",
            ItemsSource = data5,
            SelectedIndex = 0,
        };
        this.auto6.Columns.Add(pickerColumn5);

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

    private void Clear()
    {

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
                Clear();
                break;
            case false:
                break;
        }
    }
    #endregion
}