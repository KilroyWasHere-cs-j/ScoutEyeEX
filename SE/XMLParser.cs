﻿namespace SE;

using System.Xml;

/// <summary>
/// This class is used to parse the XML file that contains the settings for the app
/// 
/// Author: Gabriel Tower
/// Written: 11/2023
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
        string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<settings>\r\n   <AppName>ScoutEye</AppName>\r\n   <GameName>Crescendo</GameName>\r\n   <AppVersion>v3.0EX</AppVersion>\r\n   <DefaultComboValue>0</DefaultComboValue>\r\n   <ClickCounterLabel>Click Count</ClickCounterLabel>\r\n   <Auto0>Mobility</Auto0>\r\n   <Auto0Items>True,False</Auto0Items>\r\n   <Auto0Hide>false</Auto0Hide>\r\n   <Auto1>Notes in Amp</Auto1>\r\n   <Auto1Items>NumFill</Auto1Items>\r\n   <Auto1Hide>false</Auto1Hide>\r\n   <Auto2>Notes in Spk</Auto2>\r\n   <Auto2Items>true, false</Auto2Items>\r\n   <Auto2Hide>false</Auto2Hide>\r\n   <Auto3></Auto3>\r\n   <Auto3Items></Auto3Items>\r\n   <Auto3Hide>true</Auto3Hide>\r\n   <Auto4>Left com</Auto4>\r\n   <Auto4Items>True, False</Auto4Items>\r\n   <Auto4Hide>true</Auto4Hide>\r\n   <Auto5>Hold</Auto5>\r\n   <Auto5Items>NumFill</Auto5Items>\r\n   <Auto5Hide>true</Auto5Hide>\r\n   <Teleop0>Notes in Amp</Teleop0>\r\n   <Teleop0Items>NumFill</Teleop0Items>\r\n   <Teleop0Hide>false</Teleop0Hide>\r\n   <Teleop1>Notes in Spk</Teleop1>\r\n   <Teleop1Items>NumFill</Teleop1Items>\r\n   <Teleop1Hide>false</Teleop1Hide>\r\n   <Teleop2>Notes in Amped Spk</Teleop2>\r\n   <Teleop2Items>True,False</Teleop2Items>\r\n   <Teleop2Hide>false</Teleop2Hide>\r\n   <Teleop3>Notes in Trap</Teleop3>\r\n   <Teleop3Items>Yes,No</Teleop3Items>\r\n   <Teleop3Hide>false</Teleop3Hide>\r\n   <Teleop4>Spotlit</Teleop4>\r\n   <Teleop4Items>Yes,No</Teleop4Items>\r\n   <Teleop4Hide>false</Teleop4Hide>\r\n   <Teleop5>Climb</Teleop5>\r\n   <Teleop5Items>Slow, Medium, Fast</Teleop5Items>\r\n   <Teleop5Hide>true</Teleop5Hide>\r\n</settings>\r\n";
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
