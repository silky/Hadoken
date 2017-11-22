#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class TechnetiumElement : Element
    {
		public TechnetiumElement()
			: base(Technetium, Tc, 43)
		{
		}

		public const string Tc = "Tc";
		public const string Technetium = "Technetium";
	}
}
