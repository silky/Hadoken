#region Using References

using System;
using System.Collections.Generic;
using System.Linq;

using Hadoken.Core.Elements;

#endregion

namespace Hadoken.Core
{
    public class CalculationVariable
    {
		public CalculationVariable(Element element, double value)
		{
			_element = element;
			_value = value;
		}

		private readonly Element _element;
		private readonly double _value;

		public Element Element
		{
			get
			{
				return _element;
			}
		}

		public double Value
		{
			get
			{
				return _value;
			}
		}

        public static List<CalculationVariable> FromPrototypeString(string value)
        {
            //	"Ag1F6Sb1_ICSD_28676"
            //	Ag2Al2O4

            List<CalculationVariable> calculationVariables = new List<CalculationVariable>();
            List<string> elementList = Element.ToElementList(value);

            foreach (string sElement in elementList)
            {
                //	Ag1
                //	F6
                //	Sb1

                string key = "";
                int coefficient = 0;

                for (int i = 0; i < sElement.Length; i++)
                {
                    if (Int32.TryParse(sElement.Substring(i, 1), out coefficient) == true)
                    {
                        key = sElement.Substring(0, i);
                        coefficient = Int32.Parse(sElement.Substring(i));
                        calculationVariables.Add(new CalculationVariable(Element.FromString(key), coefficient));
                        break;
                    }
                }
            }

            return calculationVariables.OrderBy(m => (m.Element.Symbol)).ToList();
        }

        public override string ToString()
        {
            return $"{_element} ({_value})";
        }
    }
}
