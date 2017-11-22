#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class IronElement : Element
    {
		public IronElement()
			: base(Iron, Fe, 26)
		{
		}

		public const string Fe = "Fe";
		public const string Iron = "Iron";
	}
}
