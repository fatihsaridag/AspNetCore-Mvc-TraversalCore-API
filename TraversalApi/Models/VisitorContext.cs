using Microsoft.EntityFrameworkCore;

namespace TraversalApi.Models
{
    public class VisitorContext : DbContext
    {

        public VisitorContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Visitor> Visitors { get; set; }




    }
}
