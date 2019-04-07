using System;
using System.Threading;
using Project.Bll.Core.Interfaces;

namespace Project.Dal.Ef
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ProjectDbContext _context;
        private static AsyncLocal<ProjectDbContext> _asyncLocalContext = new AsyncLocal<ProjectDbContext>();

        public static void ThrowIfNoContext()
        {
            if (Context == null)
                throw new InvalidOperationException("Operation has to be perform with UoW Ef Context");
        }

        public static ProjectDbContext Context 
            => _asyncLocalContext.Value;

        public EfUnitOfWork(ProjectDbContext context)
        {
            _context = context;
        }

        internal ProjectDbContext InitializeContext()
        {
            if (_asyncLocalContext.Value != null)
                throw new InvalidOperationException("Context already initialized");
            _asyncLocalContext.Value = _context;
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
            _asyncLocalContext.Value = null;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}