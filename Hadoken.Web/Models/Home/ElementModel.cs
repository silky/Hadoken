#region Using References

using System;

using Hadoken.Core;

#endregion

namespace Hadoken.Web.Models.Home
{
    public class ElementModel
    {
        public ElementModel(int atomicNumber, double atomicWeight, string className, double density, int? groupID, int id, string name, int period, string symbol)
        {
            _atomicNumber = atomicNumber;
            _atomicWeight = atomicWeight;
            _className = className;
            _density = density;
            _groupID = groupID;
            _id = id;
            _name = name;
            _period = period;
            _symbol = symbol;
        }

        private readonly int _atomicNumber;
        private readonly double _atomicWeight;
        private readonly string _className;
        private readonly double _density;
        private readonly int? _groupID;
        private readonly int _id;
        private readonly string _name;
        private readonly int _period;
        private readonly string _symbol;

        public int AtomicNumber
        {
            get
            {
                return _atomicNumber;
            }
        }

        public double AtomicWeight
        {
            get
            {
                return _atomicWeight;
            }
        }

        public string ClassName
        {
            get
            {
                return _className;
            }
        }

        public double Density
        {
            get
            {
                return _density;
            }
        }

        public int? GroupID
        {
            get
            {
                return _groupID;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Period
        {
            get
            {
                return _period;
            }
        }

        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static ElementModel ToElementModel(Element element)
        {
            string className = "";

            switch (element.AtomicNumber)
            {
                case 1:
                    className = "Hydrogen";
                    break;

                case 2:
                case 10:
                case 18:
                case 36:
                case 54:
                case 86:
                case 118:
                    className = "NobleGas";
                    break;

                case 3:
                case 11:
                case 19:
                case 37:
                case 55:
                case 87:
                    className = "AlkaliMetal";
                    break;

                case 4:
                case 12:
                case 20:
                case 38:
                case 56:
                case 88:
                    className = "AlkaliEarthMetal";
                    break;

                case 5:
                case 14:
                case 32:
                case 33:
                case 51:
                case 52:
                case 85:
                case 117:
                    className = "Metalloid";
                    break;

                case 6:
                case 15:
                case 16:
                case 34:
                    className = "PolyatomicNonMetal";
                    break;

                case 7:
                case 8:
                case 9:
                case 17:
                case 35:
                case 53:
                    className = "DiatomicNonMetal";
                    break;

                case 13:
                case 31:
                case 49:
                case 50:
                case 81:
                case 82:
                case 83:
                case 84:
                case 113:
                case 114:
                case 115:
                case 116:
                    className = "PostTransitionMetal";
                    break;
            }

            if (
                ((element.AtomicNumber >= 21) && (element.AtomicNumber <= 30)) ||
                ((element.AtomicNumber >= 39) && (element.AtomicNumber <= 48)) || 
                ((element.AtomicNumber >= 72) && (element.AtomicNumber <= 80)) ||
                ((element.AtomicNumber >= 104) && (element.AtomicNumber <= 112))
                )
            {
                className = "TransitionMetal";
            }

            if ((element.AtomicNumber >= 57) && (element.AtomicNumber <= 71))
            {
                className = "LanthanideSeries";
            }

            if ((element.AtomicNumber >= 89) && (element.AtomicNumber <= 103))
            {
                className = "ActinideSeries";
            }

            return new ElementModel
            (
                element.AtomicNumber,
                element.AtomicWeight,
                $"Group{className}",
                element.Density,
                element.GroupID,
                element.ID,
                element.Name,
                element.Period,
                element.Symbol
            );
        }
    }
}
