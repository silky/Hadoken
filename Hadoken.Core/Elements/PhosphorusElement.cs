#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PhosphorusElement : Element
    {
		public PhosphorusElement()
			: base(Phosphorus, P, 15)
		{
		}

		public const string P = "P";
		public const string Phosphorus = "Phosphorus";
	}
}
