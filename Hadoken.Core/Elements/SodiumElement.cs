#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class SodiumElement : Element
    {
		public SodiumElement()
			: base(Sodium, Na, 11)
		{
		}

		public const string Na = "Na";
		public const string Sodium = "Sodium";
	}
}
