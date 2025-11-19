using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class ShroomiteStealth : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shroomite Stealth");
            // Description.SetDefault("Not moving puts you in stealth,\nincreasing ranged ability and reducing chance for enemies to target you\n");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.shroomiteStealth = true;
        }
    }
}