namespace VerticalSliceArchitecture.SharedKernel;
public interface ITimeProvider
{
    DateTimeOffset TimeNow { get; }
}
