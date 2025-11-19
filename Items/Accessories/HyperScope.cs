using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class HyperScope : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hyper Scope");
			// Tooltip.SetDefault("Increases view range for guns (Right Click to zoom out)\n10% increased ranged damage and critical strike chance\nMost ranged weapons become automatic\n'Now with 100x zoom!'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(gold:7);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HyperScope>());
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ModContent.ItemType<PossessedArmBand>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetDamage(DamageClass.Ranged) *= 1.1f;
			if (player.HeldItem.DamageType == DamageClass.Ranged & player.HeldItem.channel == false)
			{
				if (player.HeldItem.autoReuse == false & player.HeldItem.useAnimation >= 5)
                {
					player.releaseUseItem = true;
				}
			}
			if (player.HeldItem.useAmmo == AmmoID.Bullet)
			{
				player.scope = true;
			}
		}
    }
}