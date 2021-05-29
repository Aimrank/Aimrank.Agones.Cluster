using Aimrank.Agones.Cluster.Core.Commands.RemoveExpiredReservations;
using MediatR;
using Quartz;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Infrastructure.Quartz.Jobs
{
    [DisallowConcurrentExecution]
    internal class RemoveExpiredReservationsJob : IJob
    {
        private readonly IMediator _mediator;

        public RemoveExpiredReservationsJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
            => await _mediator.Send(new RemoveExpiredReservationsCommand());
    }
}