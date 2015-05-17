using BotBits;

using EEPhysics;

namespace BotBitsExt.Physics
{
    public static class PlayerExtensions
    {
        /// <summary>
        /// Gets the physics player.
        /// </summary>
        /// <returns>The physics player.</returns>
        /// <param name="player">Player.</param>
        public static PhysicsPlayer GetPhysicsPlayer(this Player player)
        {
            return player.Get<PhysicsPlayer>("PhysicsPlayer");
        }

        /// <summary>
        /// Sets the physics player.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="physicsPlayer">Physics player.</param>
        public static void SetPhysicsPlayer(this Player player, PhysicsPlayer physicsPlayer)
        {
            player.Set("PhysicsPlayer", physicsPlayer);
        }

        /// <summary>
        /// Gets the exact position of the player calculated using EEPhysics.
        /// </summary>
        /// <returns>The exact position of the player.</returns>
        /// <param name="player">Player.</param>
        public static Point GetExactPosition(this Player player)
        {
            var p = player.GetPhysicsPlayer();
            var x = WorldUtils.PosToBlock((int) p.X);
            var y = WorldUtils.PosToBlock((int) p.Y);
            return new Point(x, y);
        }
    }
}

