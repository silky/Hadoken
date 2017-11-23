#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class MendeleviumElement : Element
    {
		public MendeleviumElement()
			: base(Mendelevium, Md, 101)
		{
		}

		public const string Md = "Md";
		public const string Mendelevium = "Mendelevium";
	}
}
