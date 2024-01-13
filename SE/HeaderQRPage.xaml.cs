using QRCoder;

namespace SE;

/// <summary>
/// This code is used to generate a QR code for the header of the scouting page
/// This allows the user to scan the QR code and have the data headers automatically filled in Excel or equivalent spreadsheet software
/// 
/// Author: Gabriel Tower
/// Written: 11/2023
/// 
/// Kilroy Was Here
/// </summary>

public partial class HeaderQRPage : ContentPage
{
    // Setup objects for QR code generation
    private QRCodeGenerator qrGenerator;
    private QRCodeData qrCodeData;
    private PngByteQRCode qRCode;
    private ImageSource qrImageSource;

    public HeaderQRPage()
	{
		InitializeComponent();

        // TODO: Use the XML config file to load in the column header names

        // This is a plain text version of the QR code
        OutputFormatLabel.Text = "ScoutName" + " | " + "EX" + " | " + "matchNumber" + " | " + "allianceIsBlue" + " | " + "teamNumber" + " | " + "auto1" + " | " + "auto2" + " | " + "auto3" + " | " + "auto4" + " | " + "auto5" + " | " + "auto6" + " | " + "teleop1" + " | " + "teleop2" + " | " + "teleop3" + " | " + "teleop4" + " | " + "teleop5" + " | " + "teleop6" + " | " + "robotDied" + " | " + "fieldFault" + " | " + "Timer" + " | " + "ClickCount" + " | " + "robotSpeed" + " | " + "givesDefense" + " | " + "takesDefense" + " | " + "vNum/vID";

        // Generate the QR code
        GenerateQR();
    }

    /// <summary>
    /// Generates and displays a QR code based on a sting
    /// </summary>
    public void GenerateQR()
    {
        // Data to be encoded in the QR code
        string qr_content = "ScoutName" + "\t" + "EX" + "\t" + "matchNumber" + "\t" + "allianceIsBlue" + "\t" + "teamNumber" + "\t" + "auto1" + "\t" + "auto2" + "\t" + "auto3" + "\t" + "auto4" + "\t" + "auto5" + "\t" + "auto6" + "\t" + "teleop1" + "\t" + "teleop2" + "\t" + "teleop3" + "\t" + "teleop4" + "\t" + "teleop5" + "\t" + "teleop6" + "\t" + "robotDied" + "\t" + "fieldFault" + "\t" + "Timer" + "\t" + "ClickCount" + "\t" + "robotSpeed" + "\t" + "givesDefense" + "\t" + "takesDefense" + "\t" + "vNum/vID";
        
        // New QR code generator
        qrGenerator = new QRCodeGenerator();
        // Create a QR code based on the data
        qrCodeData = qrGenerator.CreateQrCode(qr_content, QRCodeGenerator.ECCLevel.L);
        // Create a PNG image of the QR code
        qRCode = new PngByteQRCode(qrCodeData);

        // Draw the QR code on the screen
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        qrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        // Defines where the QR code is rendered
        QrCodeImage.Source = qrImageSource;
    }
}