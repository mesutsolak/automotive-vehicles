using IsolationLevel = System.Data.IsolationLevel;

namespace AutomotiveBrands.Lib.Database.Abstract
{
    /// <summary>
    /// Represents an base unit of work
    /// </summary>
    /// <typeparam name="TContext">db context type</typeparam>
    public partial interface IBaseUnitOfWork
    {
        /// <summary>
        /// Begin Transaction
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <param name="isolationLevel">isolation level</param>
        /// <returns>type of dbcontext transaction interface</returns>
        /// <exception cref="OperationCanceledException">when the transaction fails</exception>
        Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default);

        /// <summary>
        /// Save changes synchronous
        /// </summary>
        /// <remarks>method that can be overridden</remarks>
        /// <returns>type of integer</returns>
        /// <exception cref="Exception">when transferring data to database</exception>
        bool SaveChanges();

        /// <summary>
        /// Save changes asynchronous
        /// </summary>
        /// <remarks>method that can be overridden</remarks>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>type of integer</returns>
        /// <exception cref="Exception">when transferring data to database</exception>
        ValueTask<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
