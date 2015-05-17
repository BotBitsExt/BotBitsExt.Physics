using System;

using BotBits;
using BotBits.Events;

using EEPhysics;

namespace BotBitsExt.Physics
{
    public sealed class PhysicsService : EventListenerPackage<PhysicsService>, IDisposable
    {
        /// <summary>
        /// Gets the physics world.
        /// </summary>
        /// <value>The physics world.</value>
        public PhysicsWorld PhysicsWorld { get; private set; }

        public PhysicsService()
        {
            PhysicsWorld = new PhysicsWorld();
        }

        /// <summary>
        /// Sets the physics player when someone joins world.
        /// </summary>
        /// <param name="e">Join event.</param>
        [EventListener]
        private void OnJoin(JoinEvent e)
        {
            e.Player.SetPhysicsPlayer(PhysicsWorld.Players[e.Player.UserId]);
        }

        /// <summary>
        /// Sets the physics player when bot joins world.
        /// </summary>
        /// <param name="e">Init event.</param>
        [EventListener]
        private void OnInit(InitEvent e)
        {
            e.Player.SetPhysicsPlayer(PhysicsWorld.Players[e.Player.UserId]);
        }

        /// <summary>
        /// Handles the PlayerIOMessage in physics world.
        /// </summary>
        /// <param name="e">PlayerIOMessage event.</param>
        [EventListener(EventPriority.Highest)]
        private void OnMessage(PlayerIOMessageEvent e)
        {
            PhysicsWorld.HandleMessage(e.Message);
        }

        void IDisposable.Dispose()
        {
            PhysicsWorld.StopSimulation();
        }
    }
}

