using MediatR;

namespace VerticalSliceArchitecture.SharedKernel;

public interface ICommand<out TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;
