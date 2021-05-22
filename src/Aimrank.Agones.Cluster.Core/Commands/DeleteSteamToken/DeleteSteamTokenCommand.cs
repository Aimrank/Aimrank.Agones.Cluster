using MediatR;

namespace Aimrank.Agones.Cluster.Core.Commands.DeleteSteamToken
{
    public class DeleteSteamTokenCommand : IRequest
    {
        public string Token { get; }

        public DeleteSteamTokenCommand(string token)
        {
            Token = token;
        }
    }
}