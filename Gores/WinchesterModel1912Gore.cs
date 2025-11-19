using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Gores
{
    internal class WinchesterModel1912Gore : ModGore
    {
		public override string Texture => "PapersGuns/Projectiles/Arsenal/Textures/GoldenWinchesterModel1912";
        public override void OnSpawn(Terraria.Gore gore, IEntitySource source)
        {
            gore.numFrames = 1;
            gore.frame = 1;
            gore.rotation = Main.rand.NextFloat(360);
            gore.behindTiles = true;
            gore.timeLeft = 1;
        }
    }
}
