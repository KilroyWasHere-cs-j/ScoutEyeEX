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
        OutputFormatLabel.Text = "ScoutName" + " | " + "EX" + " | " +
            "matchNumber" + " | " + 
            "allianceIsBlue" + " | " +
            "teamNumber" + " | " + 
            "Starting Position" + " | " + 
            "1st Note" + " | " + 
            "2nd Note" + " | " + 
            "3rd Note" + " | " + 
            "4th Note" + " | " + 
            "6th Note" + " | " + 
            "Shots Successful" + " | " + 
            "Full Field Cycle" + " | " +
            "Notes in Speaker" + " | " +
            "Notes in Amplifier" + " | " + 
            "Missed Shots" + " | " + 
            "Climb" + " | " + 
            "robotDied" + " | " + 
            "fieldFault" + " | " + 
            "Timer" + " | " + 
            "ClickCount" + " | " + 
            "robotSpeed" + " | " + 
            "givesDefense" + " | " + 
            "takesDefense" + " | " + 
            "vNum/vID";

        // Generate the QR code
        GenerateQR();
    }

    /// <summary>
    /// Generates and displays a QR code based on a sting
    /// </summary>
    public void GenerateQR()
    {
        // Data to be encoded in the QR code
        string qr_content = "ScoutName" + "\t" + 
            "EX" + "\t" + "matchNumber" + "\t" + 
            "allianceIsBlue" + "\t" + 
            "teamNumber" + "\t" + 
            "Starting Position" + "\t" + 
            "1st Note" + "\t" + 
            "2nd Note" + "\t" + 
            "3rd Note" + "\t" + 
            "4th Note" + "\t" + 
            "5th Note" + "\t" + 
            "6th Note" + "\t" + 
            "Shots Successful" + "\t" + 
            "Full Field Cycle" + "\t" + 
            "Notes in Amp" + "\t" + 
            "Notes in Spk" + "\t" + 
            "Missed Shots" + "\t" +
            "Climb" + "\t" +
            "robotDied" + "\t" + 
            "fieldFault" + "\t" + 
            "Timer" + "\t" + 
            "ClickCount" + "\t" + 
            "robotSpeed" + "\t" + 
            "givesDefense" + "\t" + 
            "takesDefense" + "\t" + 
            "vNum/vID";
        
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