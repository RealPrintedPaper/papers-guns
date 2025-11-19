using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class PistolShrimp : ModItem
	{

        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Shoots a powerful, high velocity bullet");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.VenusMagnum);
			Item.damage = 13;
			Item.width = 56;
			Item.height = 36;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
        }

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
	}
}