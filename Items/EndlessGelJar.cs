using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class EndlessGelJar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Overflowing Gel Jar");
		}
		public override void SetDefaults()
		{
			Item.ammo = AmmoID.Gel;
			Item.consumable = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<EndlessGelJar>());
			recipe.AddIngredient(ItemID.Gel, 3996);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}