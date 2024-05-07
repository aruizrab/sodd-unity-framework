using UnityEngine.AI;

namespace SODD.Core
{
    /// <summary>
    ///     Extends <see cref="NavMeshAgent" /> type providing utility methods.
    /// </summary>
    public static class NavMeshAgentExtensions
    {
        /// <summary>
        ///     Checks if the NavMeshAgent has reached its destination.
        /// </summary>
        /// <param name="agent">The NavMeshAgent instance to check.</param>
        /// <returns>
        ///     True if the agent has reached its destination or is very close to it;
        ///     otherwise, false if the agent is still moving towards the destination.
        /// </returns>
        /// <remarks>
        ///     This method checks if the NavMeshAgent has reached its destination or is very close to it.
        ///     It takes into account any pending path calculations, stopping distance, and current velocity.
        /// </remarks>
        public static bool HasReachedDestination(this NavMeshAgent agent)
        {
            if (agent.pathPending) return false;
            if (!(agent.remainingDistance <= agent.stoppingDistance)) return false;
            return !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
        }

        /// <summary>
        ///     Checks if the NavMeshAgent can reach its destination.
        /// </summary>
        /// <param name="agent">The NavMeshAgent instance to check.</param>
        /// <returns>
        ///     True if the agent can reach its destination without any obstacles or path errors;
        ///     otherwise, false if the agent's path is incomplete or blocked.
        /// </returns>
        /// <remarks>
        ///     This method checks the path status of the NavMeshAgent to determine if it can reach its destination.
        ///     If the path is complete and there are no obstacles or path errors, the agent can reach its destination.
        /// </remarks>
        public static bool CanReachDestination(this NavMeshAgent agent)
        {
            return agent.pathStatus == NavMeshPathStatus.PathComplete;
        }
    }
}