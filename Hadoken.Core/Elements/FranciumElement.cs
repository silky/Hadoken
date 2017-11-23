#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class FranciumElement : Element
    {
		public FranciumElement()
			: base(Francium, Fr, 87)
		{
		}

		public const string Fr = "Fr";
		public const string Francium = "Francium";
	}
}
