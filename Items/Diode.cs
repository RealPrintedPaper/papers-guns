using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items
{
	public class Diode : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.value = 4500;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Diode>());
			recipe.AddIngredient(ItemID.Glass, 1);
			recipe.AddRecipeGroup("IronBar", 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}