using MediatR;

namespace VerticalSliceArchitecture.SharedKernel;
public interface IQuery<out TResponse> : IRequest<TResponse>;
