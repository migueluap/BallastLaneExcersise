using BallastLane.Domain.Interfaces;
using BallastLane.Infra.Data.Context;

namespace BallastLane.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BallastLaneContext _context;

        public UnitOfWork(BallastLaneContext context)
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
