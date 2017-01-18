using System.Data.Entity;

namespace PangeaProject.DAL
{
    public interface IPangeaRepoDBEntities
    {
        DbSet<RepoCopy> RepoCopies { get; set; }
    }
}