using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Exceptions;
using Aimrank.Agones.Cluster.Core.Repositories;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Core.Commands.RegisterPod
{
    internal class RegisterPodCommandHandler : IRequestHandler<RegisterPodCommand, PodRegistrationDto>
    {
        private readonly ISteamTokenRepository _steamTokenRepository;

        public RegisterPodCommandHandler(ISteamTokenRepository steamTokenRepository)
        {
            _steamTokenRepository = steamTokenRepository;
        }

        public async Task<PodRegistrationDto> Handle(RegisterPodCommand request, CancellationToken cancellationToken)
        {
            var steamToken = await _steamTokenRepository.GetUnusedAsync();
            if (steamToken is null)
            {
                throw new ClusterException("No steam server token available.");
            }

            steamToken.Server = request.Address;

            return new PodRegistrationDto
            {
                SteamToken = steamToken.Token
            };
        }
    }
}