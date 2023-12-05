using QRCoder;

namespace SE;

/// <summary>
/// This page compiles and displays the QR  code for the currently logged match.
/// 
/// 
/// Author: Gabriel Tower
/// Wihtten: 11/2023
/// 
/// Kilroy Was Here
/// </summary>

public partial class QRPage : ContentPage
{
    // Initialize private QRCodeGenerator, QRCodeData, PngByteQRCode, ImageSource, and Match objects
    private QRCodeGenerator qrGenerator;
    private QRCodeData qrCodeData;
    private PngByteQRCode qRCode;
    private ImageSource qrImageSource;
    private Match match;
    private LastMatchInfo lastMatchInfo;

    public QRPage(Match _match)
	{
		InitializeComponent();
        // set local match to the match passed in
        match = _match;
        // Generate the QR code
        GenerateQR();
    }

    /// <summary>
    /// Generate and display the QR code for the currently logged match
    /// </summary>
	public void GenerateQR()
	{
        // Compile the QR code content all the data is stored in the match object
        string qr_content = match.scoutName + "\t" + "EX" + "\t" + match.matchNumber + "\t" + match.isBlue + "\t" + match.teamNumber + "\t" + match.auto1 + "\t" + match.auto2 + "\t" + match.auto3 + "\t" + match.auto4 + "\t" + match.auto5 + "\t" + match.auto6 + "\t" + match.teleop1 + "\t" + match.teleop2 + "\t" + match.teleop3 + "\t" + match.teleop4 + "\t" + match.teleop5 + "\t" + match.teleop6 + "\t" + match.robotDied + "\t" + match.fieldFault + "\t" + "00:00:00" + "\t" + "00" + "\t" + match.robotSpeed + "\t" + match.givesDefense + "\t" + match.takesDefense + "\t" + "EX";    
        
        // Post the raw QR code content to the QRCodeOutputLabel
        OutputLabel.Text = qr_content;

        // Post the match info to the LoggedMatchInfoLabel
        LoggedMatchInfo.Text = "Scout Name: " + match.scoutName + " Match Number: " + match.matchNumber;

        // Generate the QR code
        qrGenerator = new QRCodeGenerator();
        qrCodeData = qrGenerator.CreateQrCode(qr_content, QRCodeGenerator.ECCLevel.L);

        // Convert the QR code to a PNG and set the QRCodeImage source to the PNG
        qRCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeBytes = qRCode.GetGraphic(20);
        qrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        // Render the QR code on the page
        QrCodeImage.Source = qrImageSource;

        // Chache the relevant match info in the lastMatchInfo object
        lastMatchInfo.scoutName = match.scoutName;
        lastMatchInfo.matchNumber = match.matchNumber + 1;
    }

    /// <summary>
    /// This method is called when the user clicks the "To Next Match" button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnToNextMatchClicked(object sender, EventArgs e)
    {
        // Ask the user if the QR code has been scanned
        bool response = await DisplayAlert("Alert", "Has your tablets QR code been successfully scanned and recorded by the teams lead scout?", "Yes", "No");
        switch (response)
        {
            case true:
                // Increment the match number and push the MatchInfo page
                match.matchNumber++;
                await Navigation.PushAsync(new MatchInfo(lastMatchInfo));
                break;
            case false:
                // Do nothing
                break;
        }
    }
}