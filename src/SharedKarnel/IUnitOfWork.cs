namespace VerticalSliceArchitecture.SharedKernel;
public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
