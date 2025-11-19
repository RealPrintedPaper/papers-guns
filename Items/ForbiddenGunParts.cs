using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class ForbiddenGunParts : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("'Not even the Arms Dealer would want to sell this!'\n");
        }
        public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 99;
			Item.value = 4500;
			Item.rare = ItemRarityID.Orange;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.DemonBanner);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<ForbiddenGunParts>(), 2);
			recipe2.AddIngredient(ItemID.RedDevilBanner);
			recipe2.AddTile(TileID.Solidifier);
			recipe2.Register();
		}
	}
}