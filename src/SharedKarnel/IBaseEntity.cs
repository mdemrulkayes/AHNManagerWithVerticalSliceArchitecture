namespace VerticalSliceArchitecture.SharedKernel;

public interface IBaseEntity
{
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    void ClearDomainEvents();
}
