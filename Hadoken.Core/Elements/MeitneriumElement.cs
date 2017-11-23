#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class MeitneriumElement : Element
    {
		public MeitneriumElement()
			: base(Meitnerium, Mt, 109)
		{
		}

		public const string Mt = "Mt";
		public const string Meitnerium = "Meitnerium";
	}
}
