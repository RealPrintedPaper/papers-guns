using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class AmericasBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("America's Blessing");
            // Description.SetDefault("10% increased rocket damage\n");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.specialistDamage += 0.10f;
        }
    }
}