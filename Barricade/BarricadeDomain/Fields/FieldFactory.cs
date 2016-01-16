using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeDomain.Fields
{
    class FieldFactory
    {
        #region Methods
        public IField GetField(String type)
        {
            IField field;
            switch (type)
            {
                case "startfield":
                    field = new StartField();
                    break;
                case "field":
                    field = new Field();
                    break;
                case "forestfield":
                    field = new ForestField();
                    break;
                case "restfield":
                    field = new RestField();
                    break;
                case "finishfield":
                    field = new FinishField();
                    break;
                default:
                    field = new Field();
                    break;
            }
            return field;
        }
        #endregion
    }
}
