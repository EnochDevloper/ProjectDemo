using System.Data.Entity;

namespace Pro.Model
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("PlatformConnection")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Company> Company { get; set; }

        public IDbSet<Constellation> Constellation { get; set; }

        public IDbSet<Grade> Grade { get; set; }

        public IDbSet<Student> Student { get; set; }

        //public System.Data.Entity.DbSet<Pro.Model.Student> Students { get; set; }
    }
}
