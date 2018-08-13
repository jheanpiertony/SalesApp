using SalesApp.Domain.Models;

namespace SalesApp.Backend.Models
{
    public class LocalDataContext: DataContext
    {
        public new System.Data.Entity.DbSet<SalesApp.Common.Models.Product> Products { get; set; }
    }
}