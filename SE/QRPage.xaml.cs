using QRCoder;

namespace SE;

public partial class QRPage : ContentPage
{
    private QRCodeGenerator qrGenerator;
    private QRCodeData qrCodeData;
    private PngByteQRCode qRCode;
    private ImageSource qrImageSource;
    private Match match;
    private LastMatchInfo lastMatchInfo;
    public QRPage(Match _match)
	{
		InitializeComponent();
        match = _match;
        GenerateQR();
    }

	public void GenerateQR()
	{
        string qr_content = match.scoutName + "\t" + "EX" + "\t" + match.matchNumber + "\t" + match.isBlue + "\t" + match.teamNumber + "\t" + match.auto1 + "\t" + match.auto2 + "\t" + match.auto3 + "\t" + match.auto4 + "\t" + match.auto5 + "\t" + match.auto6 + "\t" + match.teleop1 + "\t" + match.teleop2 + "\t" + match.teleop3 + "\t" + match.teleop4 + "\t" + match.teleop5 + "\t" + match.teleop6 + "\t" + match.robotDied + "\t" + match.fieldFault + "\t" + "00:00:00" + "\t" + "00" + "\t" + match.robotSpeed + "\t" + match.givesDefense + "\t" + match.takesDefense + "\t" + "EX";     
        OutputLabel.Text = qr_content;

        LoggedMatchInfo.Text = "Scout Name: " + match.scoutName + " Match Number: " + match.matchNumber;
        qrGenerator = new QRCodeGenerator();
        qrCodeData = qrGenerator.CreateQrCode(qr_content, QRCodeGenerator.ECCLevel.L);
        qRCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        qrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        QrCodeImage.Source = qrImageSource;
        lastMatchInfo.scoutName = match.scoutName;
        lastMatchInfo.matchNumber = match.matchNumber + 1;
    }

    private async void OnToNextMatchClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Has your tablets QR code been successfully scanned and recorded by the teams lead scout?", "Yes", "No");
        switch (response)
        {
            case true:
                match.matchNumber++;
                await Navigation.PushAsync(new MatchInfo(lastMatchInfo));
                break;
            case false:
                break;
        }
    }
}