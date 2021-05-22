using Aimrank.Agones.Cluster.Core.Entities;
using Aimrank.Agones.Cluster.Core.Exceptions;
using Aimrank.Agones.Cluster.Core.Repositories;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Core.Commands.CreateSteamToken
{
    internal class CreateSteamTokenCommandHandler : IRequestHandler<CreateSteamTokenCommand>
    {
        private readonly ISteamTokenRepository _steamTokenRepository;

        public CreateSteamTokenCommandHandler(ISteamTokenRepository steamTokenRepository)
        {
            _steamTokenRepository = steamTokenRepository;
        }

        public async Task<Unit> Handle(CreateSteamTokenCommand request, CancellationToken cancellationToken)
        {
            var steamToken = await _steamTokenRepository.GetByTokenAsync(request.Token);
            if (steamToken is not null)
            {
                throw new ClusterException($"Steam token '{request.Token}' already exists.");
            }
            
            steamToken = new SteamToken {Token = request.Token};
            
            _steamTokenRepository.Add(steamToken);
            
            return Unit.Value;
        }
    }
}