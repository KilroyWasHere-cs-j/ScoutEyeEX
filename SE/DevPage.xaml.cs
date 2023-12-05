using QRCoder;

namespace SE;

public partial class DevPage : ContentPage
{
    private Match match;

    public DevPage(Match match)
    {
        InitializeComponent();
        // set local match object to the match object passed in
        this.match = match;
    }
}