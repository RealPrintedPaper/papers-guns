using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class GunslingersDelight : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gunslinger's Delight");
            // Description.SetDefault("Increased gun, rocket, and flamethrower abilities\n");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HeldItem.useAmmo == AmmoID.Bullet || player.HeldItem.useAmmo == AmmoID.Rocket || player.HeldItem.useAmmo == AmmoID.Gel)
            {
                player.GetCritChance(DamageClass.Ranged) += 10;
                player.GetDamage(DamageClass.Ranged) += 0.20f;
            }
            player.buffImmune[ModContent.BuffType<Buffs.ArsonistsRage>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.BulletSteroids>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.AmericasBlessing>()] = true;
        }
    }
}