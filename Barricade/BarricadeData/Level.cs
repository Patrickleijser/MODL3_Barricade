using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BarricadeData
{
    public class Level
    {
        #region Variables
        private String _name;
        #endregion

        #region Constructor
        public Level(String name = "Default")
        {
            _name = name;
        }

        public XmlDocument GetLevelXml() {
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load(@"..\..\..\BarricadeData\Levels\" + _name + ".xml");
            return xmlFile;
        }
        #endregion
    }
}
