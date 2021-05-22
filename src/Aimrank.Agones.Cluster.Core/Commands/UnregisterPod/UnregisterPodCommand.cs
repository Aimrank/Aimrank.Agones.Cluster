using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aimrank.Agones.Cluster.Core.Commands.UnregisterPod
{
    public class UnregisterPodCommand : IRequest
    {
        [Required]
        public string Address { get; }

        public UnregisterPodCommand(string address)
        {
            Address = address;
        }
    }
}