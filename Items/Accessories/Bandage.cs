using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class Bandage : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Greatly increased life regen\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = 25000;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Bandage>());
			recipe.AddIngredient(ItemID.Silk, 25);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 5;
		}
	}
}