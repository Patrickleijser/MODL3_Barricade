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
                    XmlNodeList xmlConnectedFields = xmlRow.SelectNodes("connectedfields");

                    foreach (XmlNode xmlConnectedField in xmlConnectedFields)
                    {
                        IField connectedField = CastToIField(xmlConnectedField.Attributes["type"].Value, xmlConnectedField.SelectSingleNode("CoordX").InnerText, xmlConnectedField.SelectSingleNode("CoordY").InnerText, xmlConnectedField.SelectSingleNode("IsFirstRow").InnerText, xmlConnectedField.SelectSingleNode("IsVillage").InnerText);
                        connectedFields.Add(connectedField);
                    }

                   /* foreach (IField loopField in AllFields)
                    {
                        foreach (IField loopConnectedField in loopField.ConnectedFields)
                        {
                            
                        }
                    }*/

                    field.ConnectedFields = connectedFields;

                    //AllFields.Select(f => f.ConnectedFields).First().Where(cf => cf.CoordX == field.CoordX && cf.CoordY == field.CoordY);

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
