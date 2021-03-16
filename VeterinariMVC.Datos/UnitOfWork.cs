using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly VeterinariaDbContext _dbContext;

        public UnitOfWork(VeterinariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
