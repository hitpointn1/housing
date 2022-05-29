using Housing.Services.Pipes;
using MediatR;

namespace Housing.Services.Decorators
{
    public class EnsureRecordPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IEnsureRecordExists
    {
        private readonly IRequestHandler<TRequest, TResponse> _handler;

        public EnsureRecordPipeline(IRequestHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            return _handler.Handle(request, cancellationToken);
        }
    }
}
