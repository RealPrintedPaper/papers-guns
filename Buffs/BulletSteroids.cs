using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class BulletSteroids : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bullet Steroids");
            // Description.SetDefault("10% increased bullet damage\n");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.bulletDamage += 0.10f;
        }
    }
}