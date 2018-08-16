using System.Data.Entity;

namespace SalesApp.Domain.Models
{
    public class DataContext: DbContext
    {

        public DataContext(): base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<SalesApp.Common.Models.Product> Products { get; set; }
    }
}
