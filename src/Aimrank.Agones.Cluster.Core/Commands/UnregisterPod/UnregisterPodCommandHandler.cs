using Aimrank.Agones.Cluster.Core.Repositories;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Core.Commands.UnregisterPod
{
    internal class UnregisterPodCommandHandler : IRequestHandler<UnregisterPodCommand>
    {
        private readonly ISteamTokenRepository _steamTokenRepository;

        public UnregisterPodCommandHandler(ISteamTokenRepository steamTokenRepository)
        {
            _steamTokenRepository = steamTokenRepository;
        }

        public async Task<Unit> Handle(UnregisterPodCommand request, CancellationToken cancellationToken)
        {
            var steamToken = await _steamTokenRepository.GetByServerAsync(request.Address);
            if (steamToken is null)
            {
                return Unit.Value;
            }

            steamToken.Server = null;
            
            return Unit.Value;
        }
    }
}