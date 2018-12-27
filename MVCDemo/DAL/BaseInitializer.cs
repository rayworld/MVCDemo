using System.Data.Entity;

namespace MVCDemo.DAL
{
    public class BaseInitializer : DropCreateDatabaseIfModelChanges<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
        }
    }    
}