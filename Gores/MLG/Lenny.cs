using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Gores.MLG
{
    internal class Lenny : ModGore
    {
        public override void OnSpawn(Terraria.Gore gore, IEntitySource source)
        {
            gore.numFrames = 1;
            gore.frame = 1;
            gore.rotation = Main.rand.NextFloat(360);
            gore.behindTiles = true;
            gore.timeLeft = 1;
            UpdateType = 11;
        }
    }
}
