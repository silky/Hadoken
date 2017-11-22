#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PotassiumElement : Element
    {
		public PotassiumElement()
			: base(Potassium, K, 19)
		{
		}

		public const string K = "K";
		public const string Potassium = "Potassium";
	}
}
