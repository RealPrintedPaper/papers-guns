using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class CobaltSight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("5% increased ranged critical strike chance\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = 100000;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<CobaltSight>());
			recipe.AddIngredient(ModContent.ItemType<IronSight>(), 1);
			recipe.AddIngredient(ItemID.CobaltBar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 5;
		}
	}
}