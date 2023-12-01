using QRCoder;

namespace SE;

public partial class DevPage : ContentPage
{
    private Match match;

    public DevPage(Match match)
    {
        InitializeComponent();
        this.match = match;
    }


}