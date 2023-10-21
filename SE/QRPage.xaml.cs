using QRCoder;

namespace SE;

public partial class QRPage : ContentPage
{
    QRCodeGenerator qrGenerator;
    QRCodeData qrCodeData;
    PngByteQRCode qRCode;
    ImageSource qrImageSource;
    Match match;
    public QRPage(Match _match)
	{
		InitializeComponent();
        GenerateQR("Hello World");
        match = _match;
	}

	public void GenerateQR(string content)
	{
        qrGenerator = new QRCodeGenerator();
        qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.L);
        qRCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        qrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        QrCodeImage.Source = qrImageSource;
    }

    private async void OnToNextMatchClicked(object sender, EventArgs e)
    {
        bool response = await DisplayAlert("Alert", "Has your tablets QR code been successfully scanned and recorded by the teams lead scout?", "Yes", "No");
        switch (response)
        {
            case true:
                await Navigation.PushAsync(new ScoutingPage(match));
                break;
            case false:
                break;
        }
    }
}