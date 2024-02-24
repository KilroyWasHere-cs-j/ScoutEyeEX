namespace SE;

using System.Xml;

/// <summary>
/// This class is used to parse the XML file that contains the settings for the app
/// 
/// Author: Gabriel Tower
/// Written: 11/2023
/// 
/// Last Updated: 2/24/2024
/// 
/// Kilroy Was Here
/// </summary>

public class XMLParser
{
    // Initialize the XmlDocument object
    private XmlDocument xmlDoc;
    public XMLParser()
    {
        xmlDoc = new XmlDocument();
        LoadXML();
    }

    /// <summary>
    /// This method loads the XML file into the XmlDocument object
    /// </summary>
    private void LoadXML()
    {
        // This the why we currently store the XML file. It will be updated once we have a server to host the file
        string xml = "<settings>\r\n  " +
            "<AppName>ScoutEye</AppName>\r\n" +
            "<GameName>Crescendo</GameName> " +
            "<AppVersion>v4.0</AppVersion>\r\n  " +
            "<DefaultComboValue>0</DefaultComboValue>\r\n  " +
            "<ClickCounterLabel>Click Count</ClickCounterLabel>\r" +
            "<Auto0>Starting Position</Auto0>\r\n  " +
            "<Auto0Items>1,2,3,4,5</Auto0Items>\r\n  " +
            "<Auto0Hide>false</Auto0Hide>\r\n  " +

            "<Auto1>1st Note</Auto1>\r\n  " +
            "<Auto1Items>1,2,3,4,5,6,7,8</Auto1Items>\r\n  " +
            "<Auto1Hide>false</Auto1Hide>\r\n  " +

            "<Auto2>2nd Note</Auto2>\r\n  " +
            "<Auto2Items>1,2,3,4,5,6,7,8</Auto2Items>\r\n  " +
            "<Auto2Hide>false</Auto2Hide>\r\n  " +

            "<Auto3>3rd Note</Auto3>\r\n  " +
            "<Auto3Items>1,2,3,4,5,6,7,8</Auto3Items>\r\n  " +
            "<Auto3Hide>false</Auto3Hide>\r\n  " +

            "<Auto4>4th Note</Auto4>\r\n  " +
            "<Auto4Items>1,2,3,4,5,6,7,8</Auto4Items>\r\n  " +
            "<Auto4Hide>false</Auto4Hide>\r\n  " +

            "<Auto5>5th Note</Auto5>\r\n  " +
            "<Auto5Items>1,2,3,4,5,6,7,8</Auto5Items>\r\n  " +
            "<Auto5Hide>false</Auto5Hide>\r\n  " +

            "<Auto6>Full Field Cycles</Auto6>\r\n  " +
            "<Auto6Items>NumFill</Auto6Items>\r\n" +
            "<Auto6Hide>false</Auto6Hide>\r\n  " +

            "<Teleop0>Missed Shots</Teleop0>\r\n  " +
            "<Teleop0Items>1,2,3,4,5,6,7,8</Teleop0Items>\r\n " +
            "<Teleop0Hide>false</Teleop0Hide>\r\n  " +

            "<Teleop1>Full Field Cycles</Teleop1>\r\n  " +
            "<Teleop1Items>NumFill</Teleop1Items>\r\n  " +
            "<Teleop1Hide>false</Teleop1Hide>\r\n  " +

            "<Teleop2>Notes in Spk</Teleop2>\r\n  " +
            "<Teleop2Items>NumFill</Teleop2Items>\r\n  " +
            "<Teleop2Hide>false</Teleop2Hide>\r\n  " +

            "<Teleop3>Notes in Amp</Teleop3>\r\n  " +
            "<Teleop3Items>NumFill</Teleop3Items>\r\n  " +
            "<Teleop3Hide>false</Teleop3Hide>\r\n  " +

            "<Teleop4>Missed Shots</Teleop4>\r\n  " +
            "<Teleop4Items>NumFill</Teleop4Items>\r\n  " +
            "<Teleop4Hide>false</Teleop4Hide>\r\n  " +

            "<Teleop5>Climb</Teleop5>\r\n  " +
            "<Teleop5Items>Success,Fail,Not Attempted,Parked</Teleop5Items>\r\n  " +
            "<Teleop5Hide>false</Teleop5Hide>\r\n" +
            "</settings>";
        xmlDoc.LoadXml(xml);
    }

    /// <summary>
    /// This method returns the value of the item with the given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetItemById(string id)
    {
        try
        {
            // Get inner text of the item from an ID
            XmlNodeList item = xmlDoc.GetElementsByTagName(id);
            return item[0].InnerText.ToString();
        }
        catch
        {
            return "NULL";
        }
    }
}
