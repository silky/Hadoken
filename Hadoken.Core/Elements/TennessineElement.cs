#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TennessineElement : Element
    {
		public TennessineElement()
			: base(Tennessine, Ts, 117)
		{
		}

		public const string Ts = "Ts";
		public const string Tennessine = "Tennessine";
	}
}
