namespace SalesApp.Domain.Models
{
    using SalesApp.Common.Models;
    using System.Data.Entity;

    public class DataContext: DbContext
    {

        public DataContext(): base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
    }
}
