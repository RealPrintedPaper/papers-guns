using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class HenryAR7 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Henry AR7");
			// Tooltip.SetDefault("Shoots a powerful, high velocity bullet\nRight Click to zoom out\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 55;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Blue;
		}
		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
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