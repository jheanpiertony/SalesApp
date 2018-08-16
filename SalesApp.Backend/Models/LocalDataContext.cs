using SalesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SalesApp.Backend.Models
{
    public class LocalDataContext: DataContext
    {
        public new DbSet<SalesApp.Common.Models.Product> Products { get; set; }
    }
}