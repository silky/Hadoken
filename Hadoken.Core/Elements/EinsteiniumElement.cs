#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class EinsteiniumElement : Element
    {
		public EinsteiniumElement()
			: base(Einsteinium, Es, 99)
		{
		}

		public const string Es = "Es";
		public const string Einsteinium = "Einsteinium";
	}
}
