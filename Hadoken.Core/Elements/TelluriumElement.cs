#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TelluriumElement : Element
    {
		public TelluriumElement()
			: base(Tellurium, Te, 52)
		{
		}

		public const string Te = "Te";
		public const string Tellurium = "Tellurium";
	}
}
