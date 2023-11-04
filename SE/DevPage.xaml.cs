using QRCoder;
using System.Text.RegularExpressions;

namespace SE;

public partial class DevPage : ContentPage
{
    private QRCodeGenerator qrGenerator;
    private QRCodeData qrCodeData;
    private PngByteQRCode qRCode;
    private ImageSource qrImageSource;
    public DevPage()
    {
        InitializeComponent();
        OutputFormatLabel.Text = "ScoutName" + " | " + "EX" + " | " + "matchNumber" + " | " + "allianceIsBlue" + " | " + "teamNumber" + " | " + "auto1" + " | " + "auto2" + " | " + "auto3" + " | " + "auto4" + " | " + "auto5" + " | " + "auto6" + " | " + "teleop1" + " | " + "teleop2" + " | " + "teleop3" + " | " + "teleop4" + " | " + "teleop5" + " | " + "teleop6" + " | " + "robotDied" + " | " + "fieldFault" + " | " + "Timer" + " | " + "ClickCount" + " | " + "robotSpeed" + " | " + "givesDefense" + " | " + "takesDefense" + " | " + "vNum/vID";
        GenerateQR();
    }

    public void GenerateQR()
    {
        string qr_content = "ScoutName" + "\t" + "EX" + "\t" + "matchNumber" + "\t" + "allianceIsBlue" + "\t" + "teamNumber" + "\t" + "auto1" + "\t" + "auto2" + "\t" + "auto3" + "\t" + "auto4" + "\t" + "auto5" + "\t" + "auto6" + "\t" + "teleop1" + "\t" + "teleop2" + "\t" + "teleop3" + "\t" + "teleop4" + "\t" + "teleop5" + "\t" + "teleop6" + "\t" + "robotDied" + "\t" + "fieldFault" + "\t" + "Timer" + "\t" + "ClickCount" + "\t" + "robotSpeed" + "\t" + "givesDefense" + "\t" + "takesDefense" + "\t" + "vNum/vID";
        qrGenerator = new QRCodeGenerator();
        qrCodeData = qrGenerator.CreateQrCode(qr_content, QRCodeGenerator.ECCLevel.L);
        qRCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        qrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        QrCodeImage.Source = qrImageSource;
    }
}