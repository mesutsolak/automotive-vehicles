using IsolationLevel = System.Data.IsolationLevel;

namespace AutomotiveBrands.Lib.Database.Concrete
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Serilog.ILogger _logger;

        public BaseUnitOfWork(DbContext context)
        {
            _context = context;
            _logger = Log.ForContext(typeof(BaseUnitOfWork));
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default)
        {
            return await _context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        }

        public virtual bool SaveChanges()
        {
            try
            {
                var entries = _context.ChangeTracker.Entries().Where(p => p.Entity is BaseHistoricEntity && (p.State == EntityState.Added || p.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

                    if (entityEntry.State == EntityState.Added)
                        entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException exception)
            {
                _logger.Fatal(exception, "Veritabanı işlemleri kaydedilirken bir hata oluştu.");
                throw new DatabaseException(GetFullErrorTextAndRollbackEntityChangesAsync(exception).Result, exception);
            }
        }

        public virtual async ValueTask<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var entries = _context.ChangeTracker.Entries().Where(p => p.Entity is BaseHistoricEntity && (p.State == EntityState.Added || p.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

                    if (entityEntry.State == EntityState.Added)
                        entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (DbUpdateException dbUpdateException)
            {
                _logger.Fatal(dbUpdateException, "Veritabanı işlemleri kaydedilirken bir hata oluştu.");
                throw new DatabaseException(await GetFullErrorTextAndRollbackEntityChangesAsync(dbUpdateException), dbUpdateException);
            }
        }

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="dbUpdateException">db update exception</param>
        /// <returns>Error message</returns>
        private async Task<string> GetFullErrorTextAndRollbackEntityChangesAsync(DbUpdateException dbUpdateException)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException invalidOperationException)
                    {
                        _logger.Fatal(invalidOperationException, "Varlığa yapılan değişiklik geri alınırken bir hata oluştu.");
                    }
                });
            }

            try
            {
                await _context.SaveChangesAsync();
                return dbUpdateException.ToString();
            }
            catch (Exception exception)
            {
                _logger.Fatal(exception, "Varlığa yapılan değişiklik geri alınırken bir hata oluştu.");
                return exception.ToString();
            }
        }
    }
}
