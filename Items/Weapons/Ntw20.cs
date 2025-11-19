using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Ntw20 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("NTW-20");
			// Tooltip.SetDefault("Shoots a powerful, high velocity bullet\nRight Click to zoom out\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage += 3000;
			Item.value = Item.buyPrice(platinum: 65);
			Item.rare = ItemRarityID.Purple;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.expert = true;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-40, 3);
		}

		//Zoom
		public override void HoldItem(Player player)
		{
			player.scope = true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
		}
	}
}