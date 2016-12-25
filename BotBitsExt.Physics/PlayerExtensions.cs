using JetBrains.Annotations;
using EEPhysics;
using BotBits;

namespace BotBitsExt.Physics
{
    public static class PlayerExtensions
    {
        /// <summary>
        ///     Gets the physics player.
        /// </summary>
        /// <returns>The physics player.</returns>
        /// <param name="player">Player.</param>
        [UsedImplicitly]
        public static PhysicsPlayer GetPhysicsPlayer(this Player player)
        {
            return player.Get<PhysicsPlayer>("PhysicsPlayer");
        }

        /// <summary>
        ///     Sets the physics player.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="physicsPlayer">Physics player.</param>
        internal static void SetPhysicsPlayer(this Player player, PhysicsPlayer physicsPlayer)
        {
            player.Set("PhysicsPlayer", physicsPlayer);
        }

        /// <summary>
        ///     Gets the exact position (in blocks) of the player calculated
        ///     using EEPhysics.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>The exact position of the player (in blocks).</returns>
        [UsedImplicitly]
        public static Point GetExactPosition(this Player player)
        {
            var p = player.GetPhysicsPlayer();

            return new Point(p.BlockX, p.BlockY);
        }

        /// <summary>
        ///     Gets the exact position (in pixels) of the player calculated
        ///     using EEPhysics.
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>The exact position of the player (in pixels).</returns>
        [UsedImplicitly]
        public static Point GetExactPositionInPixels(this Player player)
        {
            var p = player.GetPhysicsPlayer();

            return new Point((int) p.X, (int) p.Y);
        }
    }
}