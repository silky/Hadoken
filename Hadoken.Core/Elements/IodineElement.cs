#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class IodineElement : Element
    {
		public IodineElement()
			: base(Iodine, I, 53)
		{
		}

		public const string I = "I";
		public const string Iodine = "Iodine";
	}
}
