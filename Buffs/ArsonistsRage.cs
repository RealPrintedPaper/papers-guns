using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class ArsonistsRage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arsonist's Rage");
            // Description.SetDefault("10% increased flamethrower damage\n");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HeldItem.useAmmo == AmmoID.Gel)
            {
                player.GetDamage(DamageClass.Ranged) += 0.10f; //wasn't sure how i could make a new damage type just for flamethrowers.
            }
        }
    }
}