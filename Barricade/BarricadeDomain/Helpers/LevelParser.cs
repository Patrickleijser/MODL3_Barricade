using BarricadeDomain.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BarricadeDomain.Helpers
{
    class LevelParser
    {
        #region Properties
        public List<StartField> StartFieldsPlayerOne { get; set; }
        public List<StartField> StartFieldsPlayerTwo { get; set; }
        public List<StartField> StartFieldsPlayerThree { get; set; }
        public List<StartField> StartFieldsPlayerFour { get; set; }
        public List<IField> AllFields { get; set; }
        #endregion

        #region Variables
        private XmlDocument _xmlFile;
        private FieldFactory _fieldFactory;
        #endregion

        #region Constructor
        public LevelParser(XmlDocument xmlFile)
        {
            _xmlFile = xmlFile;
            _fieldFactory = new FieldFactory();

            StartFieldsPlayerOne = new List<StartField>();
            StartFieldsPlayerTwo = new List<StartField>();
            StartFieldsPlayerThree = new List<StartField>();
            StartFieldsPlayerFour = new List<StartField>();
            AllFields = new List<IField>();

            // Parse XML and connect the fields
            ParseXML();
        }
        #endregion

        #region Methods
        private void ParseXML()
        {
            XmlElement root = _xmlFile.DocumentElement;
            XmlNodeList xmlRows = root.SelectNodes("row");

            foreach (XmlNode xmlRow in xmlRows)
            {
                XmlNodeList xmlFields = xmlRow.SelectNodes("IField");
                foreach (XmlNode xmlField in xmlFields)
                {

                    IField field = CastToIField(xmlField.Attributes["type"].Value, xmlField.SelectSingleNode("CoordX").InnerText, xmlField.SelectSingleNode("CoordY").InnerText, xmlField.SelectSingleNode("IsFirstRow").InnerText, xmlField.SelectSingleNode("IsVillage").InnerText);
                    List<IField> connectedFields = new List<IField>();
                    XmlNodeList xmlConnectedFields = xmlField.SelectNodes("connectedfields");

                    // Check if barricade
                    if (xmlField.Attributes["isBarricade"] != null && xmlField.Attributes["isBarricade"].Value != null && xmlField.Attributes["isBarricade"].Value == "true")
                    {

                        IMoveable barricade = new Barricade { Position=field };
                        List<IMoveable> moveables = new List<IMoveable>();
                        field.Moveables = moveables;
                        field.Moveables.Add(barricade);
                    }

                    // First add connected fields from CSV data
                    foreach (XmlNode xmlConnectedField in xmlConnectedFields)
                    {
                        XmlNodeList xmlSubFields = xmlConnectedField.SelectNodes("IField");
                        foreach (XmlNode xmlSubField in xmlSubFields)
                        {
                            IField connectedField = CastToIField(xmlSubField.Attributes["type"].Value, xmlSubField.SelectSingleNode("CoordX").InnerText, xmlSubField.SelectSingleNode("CoordY").InnerText, xmlSubField.SelectSingleNode("IsFirstRow").InnerText, xmlSubField.SelectSingleNode("IsVillage").InnerText);
                            connectedFields.Add(connectedField); 
                        }
                    }

                    // Connect siblings if no startfield
                    if (xmlField.Attributes["type"].Value == "startfield")
                    {
                        switch (xmlField.Attributes["playerid"].Value)
                        {
                            case "1":
                                StartFieldsPlayerOne.Add((StartField)field);
                                break;
                            case "2":
                                StartFieldsPlayerTwo.Add((StartField)field);
                                break;
                            case "3":
                                StartFieldsPlayerThree.Add((StartField)field);
                                break;
                            case "4":
                                StartFieldsPlayerFour.Add((StartField)field);
                                break;
                            default:
                                StartFieldsPlayerOne.Add((StartField)field);
                                break;
                        }
                    }
                    else
                    {
                        XmlNode prevSibling = xmlField.PreviousSibling;
                        XmlNode nextSibling = xmlField.NextSibling;

                        if (prevSibling != null)
                        {
                            IField prevField = CastToIField(prevSibling.Attributes["type"].Value, prevSibling.SelectSingleNode("CoordX").InnerText, prevSibling.SelectSingleNode("CoordY").InnerText, prevSibling.SelectSingleNode("IsFirstRow").InnerText, prevSibling.SelectSingleNode("IsVillage").InnerText);
                            connectedFields.Add(prevField);
                        }

                        if (nextSibling != null)
                        {
                            IField nextField = CastToIField(nextSibling.Attributes["type"].Value, nextSibling.SelectSingleNode("CoordX").InnerText, nextSibling.SelectSingleNode("CoordY").InnerText, nextSibling.SelectSingleNode("IsFirstRow").InnerText, nextSibling.SelectSingleNode("IsVillage").InnerText);
                            connectedFields.Add(nextField);
                        }
                    }

                    // Add connected fields to IField object
                    field.ConnectedFields = connectedFields;
                    
                    AllFields.Add(field);
                }
            }
        }

        private IField CastToIField(String type, String coordX, String coordY, String isFirstRow, String isVillage)
        {
            // Create IField via factory method
            IField field = _fieldFactory.GetField(type);

            // Convert string to correct types
            int convertedCoordX = Convert.ToInt32(coordX);
            int convertedCoordY = Convert.ToInt32(coordY);
            Boolean convertedIsFirstRow = Convert.ToBoolean(isFirstRow);
            Boolean convertedIsVillage = Convert.ToBoolean(isVillage);

            // Set properties
            field.CoordX = convertedCoordX;
            field.CoordY = convertedCoordY;
            field.IsFirstRow = convertedIsFirstRow;
            field.IsVillage = convertedIsVillage;

            return field;
        }
        #endregion
    }
}
