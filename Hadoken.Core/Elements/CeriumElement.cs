#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CeriumElement : Element
    {
		public CeriumElement()
			: base(Cerium, Ce, 58)
		{
		}

		public const string Ce = "Ce";
		public const string Cerium = "Cerium";
	}
}
