#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CalciumElement : Element
    {
		public CalciumElement()
			: base(Calcium, Ca, 20)
		{
		}

		public const string Ca = "Ca";
		public const string Calcium = "Calcium";
	}
}
