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
        public StartField StartFieldOne { get; set; }
        public StartField StartFieldTwo { get; set; }
        public StartField StartFieldThree { get; set; }
        public StartField StartFieldFour { get; set; }
        private List<IField> AllFields { get; set; }
        #endregion

        #region Variables
        XmlDocument _xmlFile;
        #endregion

        #region Constructor
        public LevelParser(XmlDocument xmlFile)
        {
            _xmlFile = xmlFile;
            AllFields = new List<IField>();
            ParseXML();
        }
        #endregion

        #region Methods
        private void ParseXML()
        {
            XmlElement root = _xmlFile.DocumentElement;
            XmlNodeList rows = root.SelectNodes("row");
            foreach (XmlNode row in rows)
            {
                XmlNodeList fields = row.SelectNodes("IField");
                foreach (XmlNode field in fields)
                {
                    int x = Convert.ToInt32(field.SelectSingleNode("CoordX").InnerText);
                    int y = Convert.ToInt32(field.SelectSingleNode("CoordY").InnerText);

                    AllFields.Add(new Field { CoordX=x, CoordY=y, IsFirstRow=false, IsVillage=false, Pawn=null, ConnectedFields=null });
                }
            }
        }
        private void ConnectFields() {

        }
        #endregion
    }
}
