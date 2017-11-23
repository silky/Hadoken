#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class RadiumElement : Element
    {
		public RadiumElement()
			: base(Radium, Ra, 88)
		{
		}

		public const string Ra = "Ra";
		public const string Radium = "Radium";
	}
}
