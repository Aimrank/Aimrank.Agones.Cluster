using Aimrank.Agones.Cluster.Core.Validation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aimrank.Agones.Cluster.Core.Commands.CreateSteamToken
{
    public class CreateSteamTokenCommand : IRequest
    {
        [NotEmpty]
        [RegularExpression("[0-9A-Z]{32}", ErrorMessage = "Invalid token format.")]
        public string Token { get; }

        public CreateSteamTokenCommand(string token)
        {
            Token = token;
        }
    }
}