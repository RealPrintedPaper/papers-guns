using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class BackupMagazine : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("10% chance to not consume ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = 20000;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<BackupMagazine>());
			recipe.AddRecipeGroup("IronBar", 3);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(ItemID.Silk, 2);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<PGPlayer>().backupmagon = true;
		}
	}
}