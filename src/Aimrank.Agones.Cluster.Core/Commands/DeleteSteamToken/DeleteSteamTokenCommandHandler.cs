using Aimrank.Agones.Cluster.Core.Exceptions;
using Aimrank.Agones.Cluster.Core.Repositories;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Core.Commands.DeleteSteamToken
{
    internal class DeleteSteamTokenCommandHandler : IRequestHandler<DeleteSteamTokenCommand>
    {
        private readonly ISteamTokenRepository _steamTokenRepository;

        public DeleteSteamTokenCommandHandler(ISteamTokenRepository steamTokenRepository)
        {
            _steamTokenRepository = steamTokenRepository;
        }

        public async Task<Unit> Handle(DeleteSteamTokenCommand request, CancellationToken cancellationToken)
        {
            var steamToken = await _steamTokenRepository.GetByTokenAsync(request.Token);
            if (steamToken is null)
            {
                throw new ClusterException($"Steam token '{request.Token} does not exist.");
            }

            if (steamToken.Server is not null)
            {
                throw new ClusterException($"Steam token '{request.Token} is used by running server.");
            }
            
            _steamTokenRepository.Delete(steamToken);
            
            return Unit.Value;
        }
    }
}