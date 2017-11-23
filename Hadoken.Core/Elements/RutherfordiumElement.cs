#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RutherfordiumElement : Element
    {
		public RutherfordiumElement()
			: base(Rutherfordium, Rf, 104)
		{
		}

		public const string Rf = "Rf";
		public const string Rutherfordium = "Rutherfordium";
	}
}
