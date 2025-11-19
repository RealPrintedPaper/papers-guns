using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class LaserSight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Laser Scope");
			// Tooltip.SetDefault("Increases view range for guns (Right Click to zoom out)\n10% increased ranged damage, critical strike chance, and attack speed\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = 250000;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserSight>());
			recipe.AddIngredient(ItemID.SniperScope, 1);
			recipe.AddIngredient(ModContent.ItemType<LaserAttachment>(), 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.HeldItem.useAmmo == AmmoID.Bullet)
			{
				player.scope = true;
			}

			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetDamage(DamageClass.Ranged) *= 1.10f;
			player.GetAttackSpeed(DamageClass.Ranged) *= 1.10f;
		}
	}
}