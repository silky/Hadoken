#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class NeodymiumElement : Element
    {
		public NeodymiumElement()
			: base(Neodymium, Nd, 60)
		{
		}

		public const string Nd = "Nd";
		public const string Neodymium = "Neodymium";
	}
}
