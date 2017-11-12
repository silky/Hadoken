#region Using References

using System;

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
                MigrationRunner.ExecuteResource(name);
            }
        }

        public virtual void Rollback()
        {
        }
    }
}
