using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class EmeraldBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Emerald Blessing");
            /* Description.SetDefault("5% increased damage\n" +
                "7% increased critical strike chance\n" +
                "15% increased movement speed\n" +
                "+8 defense\n" +
                "Increased life regen\n"); */
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 7;
            player.maxRunSpeed *= 1.15f;
            player.statDefense += 8;
            player.lifeRegen += 5;
        }
    }
}