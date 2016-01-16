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
        #endregion

        #region Variables
        XmlDocument _xmlFile;
        #endregion

        #region Constructor
        public LevelParser(XmlDocument xmlFile)
        {
            _xmlFile = xmlFile;
            StartFieldsPlayerOne = new List<StartField>();
            StartFieldsPlayerTwo = new List<StartField>();
            StartFieldsPlayerThree = new List<StartField>();
            StartFieldsPlayerFour = new List<StartField>();

            // Parse XML and connect the fields
            ParseXML();
        }
        #endregion

        #region Methods
        private void ParseXML()
        {
            FieldFactory fieldFactory = new FieldFactory();

            XmlElement root = _xmlFile.DocumentElement;
            XmlNodeList rows = root.SelectNodes("row");

            foreach (XmlNode row in rows)
            {
                XmlNodeList fields = row.SelectNodes("IField");
                foreach (XmlNode field in fields)
                {
                    int x = Convert.ToInt32(field.SelectSingleNode("CoordX").InnerText);
                    int y = Convert.ToInt32(field.SelectSingleNode("CoordY").InnerText);
                    Boolean isFirstRow = Convert.ToBoolean(field.SelectSingleNode("IsFirstRow").InnerText);
                    Boolean isVillage = Convert.ToBoolean(field.SelectSingleNode("IsVillage").InnerText);

                    IField newField = fieldFactory.GetField(field.Attributes["type"].Value);
                    newField.CoordX = x;
                    newField.CoordY = y;
                    newField.IsFirstRow = isFirstRow;
                    newField.IsVillage = isVillage;

                    ConnectFields(newField, null);
                    
                }
            }
        }
        private void ConnectFields(IField fieldOne, IField fieldTwo) {
            
        }
        #endregion
    }
}
