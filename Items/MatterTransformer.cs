using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items
{
	public class MatterTransformer : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Projectile Transformer");
		}
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.value = 5000;
			Item.rare = ItemRarityID.White;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MatterTransformer>());
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddIngredient(ItemID.Emerald);
			recipe.AddIngredient(ItemID.StoneBlock, 2);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.Register();
		}
	}
}