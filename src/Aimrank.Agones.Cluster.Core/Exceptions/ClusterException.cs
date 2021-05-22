using System;

namespace Aimrank.Agones.Cluster.Core.Exceptions
{
    public class ClusterException : Exception
    {
        public ClusterException(string message) : base(message)
        {
        }
    }
}