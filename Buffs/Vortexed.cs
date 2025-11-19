using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class Vortexed : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vortexed!");
            // Description.SetDefault("25% increased ranged critical strike chance\n100% increased ranged damage\nYou are out of control and gain various debuffs\n");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Ranged) += 25;
            player.GetDamage(DamageClass.Ranged) += 1;
            player.vortexDebuff = true;
            player.velocity.X *= 0.8f;
            player.electrified = true;
            player.poisoned = true;

        }
    }
}