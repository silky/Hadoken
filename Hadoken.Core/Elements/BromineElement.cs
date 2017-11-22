#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class BromineElement : Element
    {
		public BromineElement()
			: base(Bromine, Br, 35)
		{
		}

		public const string Br = "Br";
		public const string Bromine = "Bromine";
	}
}
