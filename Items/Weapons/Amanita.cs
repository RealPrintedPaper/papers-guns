using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Amanita : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a powerful, high velocity bullet\nRight Click to zoom out\n'Also known as the Death Cap.'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage -= 40;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = ItemRarityID.Yellow;
			Item.useTime /= 2;
			Item.useAnimation /= 2;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 2);
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

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Amanita>());
			recipe.AddIngredient(ItemID.ShroomiteBar, 15);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}