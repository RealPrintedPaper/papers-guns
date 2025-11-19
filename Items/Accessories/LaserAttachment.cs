using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class LaserAttachment : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("15% increased ranged attack speed\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(silver: 40);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserAttachment>());
			recipe.AddIngredient(ModContent.ItemType<IronSight>(), 1);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetAttackSpeed(DamageClass.Ranged) *= 1.15f;
		}
	}
}