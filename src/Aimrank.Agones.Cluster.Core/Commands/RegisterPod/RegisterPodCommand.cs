using Aimrank.Agones.Cluster.Core.DTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aimrank.Agones.Cluster.Core.Commands.RegisterPod
{
    public class RegisterPodCommand : IRequest<PodRegistrationDto>
    {
        [Required]
        public string Address { get; }

        public RegisterPodCommand(string address)
        {
            Address = address;
        }
    }
}