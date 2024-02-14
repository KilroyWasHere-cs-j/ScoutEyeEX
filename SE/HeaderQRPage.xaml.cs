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
        OutputFormatLabel.Text = "ScoutName" + " | " + "EX" + " | " + "matchNumber" + " | " + "allianceIsBlue" + " | " + "teamNumber" + " | " + "Mobility" + " | " + "Notes in amp" + " | " + "Notes in spk" + " | " + "auto4" + " | " + "auto5" + " | " + "auto6" + " | " + "Notes in amp" + " | " + "Notes in spk" + " | " + "Notes in amped spk" + " | " + "Notes in trap" + " | " + "Spotlit" + " | " + "Climb" + " | " + "robotDied" + " | " + "fieldFault" + " | " + "Timer" + " | " + "ClickCount" + " | " + "robotSpeed" + " | " + "givesDefense" + " | " + "takesDefense" + " | " + "vNum/vID";

        // Generate the QR code
        GenerateQR();
    }

    /// <summary>
    /// Generates and displays a QR code based on a sting
    /// </summary>
    public void GenerateQR()
    {
        // Data to be encoded in the QR code
        string qr_content = "ScoutName" + "\t" + "EX" + "\t" + "matchNumber" + "\t" + "allianceIsBlue" + "\t" + "teamNumber" + "\t" + "Mobility" + "\t" + "Notes in amp" + "\t" + "Notes in spk" + "\t" + "auto4" + "\t" + "auto5" + "\t" + "auto6" + "\t" + "Notes in amp" + "\t" + "Notes in spk" + "\t" + "Notes in amped" + "\t" + "Notes in trap" + "\t" + "Spotlit" + "\t" + "Climb" + "\t" + "robotDied" + "\t" + "fieldFault" + "\t" + "Timer" + "\t" + "ClickCount" + "\t" + "robotSpeed" + "\t" + "givesDefense" + "\t" + "takesDefense" + "\t" + "vNum/vID";
        
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