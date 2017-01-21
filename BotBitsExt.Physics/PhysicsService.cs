using BotBits.Events;
using EEPhysics;
using BotBits;
using System;

namespace BotBitsExt.Physics
{
    public sealed class PhysicsService : EventListenerPackage<PhysicsService>, IDisposable
    {
        /// <summary>
        ///     Gets the physics world.
        /// </summary>
        /// <value>The physics world.</value>
        public PhysicsWorld PhysicsWorld { get; private set; }

        public PhysicsService()
        {
            PhysicsWorld = new PhysicsWorld();
        }

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
            e.Player.GetPhysicsPlayer().OnBlockPositionChange += blockEvent =>
            {
                new BlockChangeEvent(e.Player, blockEvent.Player, blockEvent.BlockX,
                    blockEvent.BlockY, blockEvent.BlockId).RaiseIn(BotBits);
            };
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

    public sealed class BlockChangeEvent : Event<BlockChangeEvent>
    {
        /// <summary>
        ///     Gets the Physics Player.
        /// </summary>
        /// <value>
        ///     The player.
        /// </value>
        public PhysicsPlayer PhysicsPlayer { get; private set; }

        /// <summary>
        ///     Gets the Botbits Player.
        /// </summary>
        /// <value>
        ///     The player.
        /// </value>
        public Player Player { get; private set; }

        /// <summary>
        /// Gets the Block X
        /// </summary>
        public int BlockX { get; private set; }

        /// <summary>
        /// Gets the Block Y
        /// </summary>
        public int BlockY { get; private set; }

        /// <summary>
        /// Gets the Block ID
        /// </summary>
        public int BlockId { get; private set; }

        internal BlockChangeEvent(Player player, PhysicsPlayer physicsPlayer, int blockX, int blockY, int blockId)
        {
            PhysicsPlayer = physicsPlayer;
            BlockId = blockId;
            Player = player;
            BlockX = blockX;
            BlockY = blockY;
        }
    }
}