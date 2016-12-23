using BotBits;

namespace BotBitsExt.Physics
{
    public sealed class PhysicsExtension : Extension<PhysicsExtension>
    {
        public static void LoadInto(BotBitsClient client)
        {
            LoadInto(client, null);
        }
    }
}