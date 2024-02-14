using MediatR;

namespace VerticalSliceArchitecture.SharedKernel;
public interface IQueryHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> 
    where TCommand : IQuery<TResponse>;
