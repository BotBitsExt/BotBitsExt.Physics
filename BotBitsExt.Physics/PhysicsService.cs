using System;
using BotBits;
using BotBits.Events;
using EEPhysics;
using JetBrains.Annotations;

namespace BotBitsExt.Physics
{
    public sealed class PhysicsService : EventListenerPackage<PhysicsService>, IDisposable
    {
        public PhysicsService()
        {
            PhysicsWorld = new PhysicsWorld();
        }

        /// <summary>
        ///     Gets the physics world.
        /// </summary>
        /// <value>The physics world.</value>
        [UsedImplicitly]
        public PhysicsWorld PhysicsWorld { get; private set; }

        void IDisposable.Dispose()
        {
            PhysicsWorld.StopSimulation();
        }

        /// <summary>
        ///     Sets the physics player when someone joins world.
        /// </summary>
        /// <param name="e">Join event.</param>
        [EventListener]
        private void On(JoinEvent e)
        {
            e.Player.SetPhysicsPlayer(PhysicsWorld.Players[e.Player.UserId]);
        }

        /// <summary>
        ///     Sets the physics player when bot joins world.
        /// </summary>
        /// <param name="e">Init event.</param>
        [EventListener]
        private void On(InitEvent e)
        {
            e.Player.SetPhysicsPlayer(PhysicsWorld.Players[e.Player.UserId]);
        }

        /// <summary>
        ///     Handles the PlayerIOMessage in physics world.
        /// </summary>
        /// <param name="e">PlayerIOMessage event.</param>
        [EventListener(GlobalPriority.BeforeMost)]
        private void On(PlayerIOMessageEvent e)
        {
            PhysicsWorld.HandleMessage(e.Message);
        }
    }
}