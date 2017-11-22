#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NeonElement : Element
    {
		public NeonElement()
			: base(Neon, Ne, 10)
		{
		}

		public const string Ne = "Ne";
		public const string Neon = "Neon";
	}
}
