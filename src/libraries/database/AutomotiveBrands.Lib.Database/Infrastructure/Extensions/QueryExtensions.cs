namespace AutomotiveBrands.Lib.Database.Infrastructure.Extensions
{
    public static class QueryExtensions
    {
        /// <summary>
        /// Query with dynamic include
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="context">dbContext</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns>constructed query with include properties</returns>
        /// <exception cref="ArgumentNullException">when query value is empty or not</exception>
        public static IQueryable<T> Includes<T>(this IQueryable<T> query, params string[] includeProperties) where T : class, IEntity, new()
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query), ExceptionMessage.QueryRequired);

            return includeProperties.Aggregate(query, EntityFrameworkQueryableExtensions.Include);
        }

        /// <summary>
        /// Bulk add to collection type
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="collection">type of collection interface</param>
        /// <param name="items">type of ienumerable interface</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items) where T : class, new()
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));

            foreach (var item in items)
                collection.Add(item);
        }

        /// <summary>
        /// Bulk add to list type
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="collection">type of collection interface</param>
        /// <param name="items">type of ilist interface</param>
        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(collection, nameof(collection));

            foreach (var item in items)
                collection.Add(item);
        }
    }
}
