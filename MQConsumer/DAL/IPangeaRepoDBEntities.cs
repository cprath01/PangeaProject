using System.Data.Entity;

namespace DAL
{
    public interface IPangeaRepoDBEntities
    {
        DbSet<RepoCopy> RepoCopies { get; set; }
        int SaveChanges();
    }
}