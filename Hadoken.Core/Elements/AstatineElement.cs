#region Using References

using System;

#endregion

namespace Hadoken.Core.Elements
{
    public class AstatineElement : Element
    {
		public AstatineElement()
			: base(Astatine, At, 85)
		{
		}

		public const string At = "At";
		public const string Astatine = "Astatine";
	}
}
