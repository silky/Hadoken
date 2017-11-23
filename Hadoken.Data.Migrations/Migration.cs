#region Using References

using System;

#endregion

namespace Hadoken.Data.Migrations
{
    public class Migration
    {
        public virtual void Apply(DataPlatformType dataPlatformType)
        {
        }

        public void ExecuteResource(DataPlatformType dataPlatformType, string name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                MigrationRunner.ExecuteResource($"{dataPlatformType.ToString()}.{name}");
            }
        }

        public virtual void Rollback(DataPlatformType dataPlatformType)
        {
        }
    }
}
