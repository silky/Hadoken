#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TungstenElement : Element
    {
		public TungstenElement()
			: base(Tungsten, W, 74)
		{
		}

		public const string W = "W";
		public const string Tungsten = "Tungsten";
	}
}
