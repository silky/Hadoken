#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class PromethiumElement : Element
    {
		public PromethiumElement()
			: base(Promethium, Pm, 61)
		{
		}

		public const string Pm = "Pm";
		public const string Promethium = "Promethium";
	}
}
