#region Using References

using System;
using System.Data.Common;

#endregion

namespace Hadoken.Data.Migrations
{
    public class Migration
    {
        public virtual void Apply()
        {
        }

        public void ExecuteResource(string name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                //  using (StreamReader streamReader = new StreamReader(_assembly.GetManifestResourceStream(name)))
                //  {
                //      string resource = streamReader.ReadToEnd();
                //  
                //      if (String.IsNullOrEmpty(resource) == false)
                //      {
                //  
                //      }
                //  }
            }
        }

        public virtual void Rollback()
        {
        }
    }
}
