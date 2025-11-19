using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items
{
	public class PhotonCell : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Ammunition for laser weapons\n");
		}
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.ammo = Item.type;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper: 2);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<PhotonCell>(), 75);
			recipe.AddIngredient(ItemID.MusketBall, 75);
			recipe.AddIngredient(ModContent.ItemType<Diode>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}