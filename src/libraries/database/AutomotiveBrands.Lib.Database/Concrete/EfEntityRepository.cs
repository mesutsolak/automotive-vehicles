namespace AutomotiveBrands.Lib.Database.Concrete
{
    public class EfEntityRepository<TEntity> : IEfEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _entities;

        public EfEntityRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, bool disableTracking = true)
        {
            IQueryable<TEntity> entityTable = TableTracking(disableTracking);

            if (filter is not null)
                entityTable = entityTable.Where(filter);

            return await entityTable.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params string[] includeProperties)
        {
            IQueryable<TEntity> entityTable = Table;

            if (filter is not null)
                entityTable = entityTable.Where(filter);

            if (orderBy is not null)
                entityTable = orderBy(entityTable);

            if (includeProperties is not null)
                entityTable.Includes(includeProperties);

            return await entityTable.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool disableTracking = true)
        {
            return await TableTracking(disableTracking).FirstOrDefaultAsync(filter);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            return await Table.Includes(includes).FirstOrDefaultAsync(filter);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, bool disableTracking = true)
        {
            IQueryable<TEntity> entityTable = TableTracking(disableTracking);

            if (orderBy is not null)
                entityTable = orderBy(entityTable);

            return await entityTable.FirstOrDefaultAsync(filter);
        }

        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool disableTracking = true)
        {
            return await TableTracking(disableTracking).AnyAsync(filter);
        }

        public virtual async ValueTask<bool> AllAsync(Expression<Func<TEntity, bool>> filter, bool disableTracking = true)
        {
            return await TableTracking(disableTracking).AllAsync(filter);
        }

        public virtual async ValueTask InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ValidateEntity(entity);
            await Entities.AddAsync(entity, cancellationToken);
        }

        public virtual async ValueTask InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            ValidateEntities(entities);
            await Entities.AddRangeAsync(entities, cancellationToken);
        }

        public virtual void UpdateByPropertyName(TEntity entity, string propertyName)
        {
            ValidateEntity(entity);

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName), ExceptionMessage.PropertyNameRequired);

            if (entity.GetType().GetProperty(propertyName) is null)
                throw new ArgumentException(ExceptionMessage.PropertyValueRequired, nameof(propertyName));

            TEntity _entity = entity;
            _entity.GetType().GetProperty(propertyName).SetValue(_entity, DateTime.Now);

            Entities.Update(_entity);
        }

        public virtual void Update(TEntity entity)
        {
            ValidateEntity(entity);
            Entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            ValidateEntities(entities);
            Entities.UpdateRange(entities);
        }

        public void DeleteByPropertyName(TEntity entity, string propertyName)
        {
            ValidateEntity(entity);

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName), ExceptionMessage.PropertyNameRequired);

            if (entity.GetType().GetProperty(propertyName) is null)
                throw new ArgumentException(ExceptionMessage.PropertyValueRequired, nameof(propertyName));

            TEntity _entity = entity;
            _entity.GetType().GetProperty(propertyName).SetValue(_entity, true);

            Entities.Update(_entity);
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void Delete(TEntity entity)
        {
            ValidateEntity(entity);

            if (_context.Entry(entity).State.Equals(EntityState.Detached))
                Entities.Attach(entity);

            Entities.Remove(entity);
        }

        public virtual void DeleteRange()
        {
            Entities.RemoveRange(Entities.AsQueryable());
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            ValidateEntities(entities);
            Entities.RemoveRange(entities);
        }

        public virtual void DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            Entities.RemoveRange(Entities.Where(predicate));
        }

        /// <summary>
        /// Gets a table by tracking selection
        /// </summary>
        private IQueryable<TEntity> TableTracking(bool disableTracking) => disableTracking ? TableNoTracking : Table;

        /// <summary>
        /// Gets a table
        /// </summary>
        public IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities is null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        private static void ValidateEntities(IEnumerable<TEntity> entities)
        {
            if (!(entities?.Any() ?? false))
                throw new ArgumentNullException(nameof(entities), ExceptionMessage.EntityRequired);
        }

        private static void ValidateEntity(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), ExceptionMessage.EntityRequired);
        }
    }
}
