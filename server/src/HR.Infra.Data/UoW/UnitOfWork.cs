using HR.Domain.Interfaces;
using HR.Infra.Data.Context;

namespace HR.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _context;

        public UnitOfWork(HotelContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
