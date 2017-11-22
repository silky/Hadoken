#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class CadmiumElement : Element
    {
		public CadmiumElement()
			: base(Cadmium, Cd, 48)
		{
		}

		public const string Cd = "Cd";
		public const string Cadmium = "Cadmium";
	}
}
