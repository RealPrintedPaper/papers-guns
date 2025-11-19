using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class HallowedSuppressor : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("5% decreased ranged damage, 7% increased critical strike chance\n'Silent, but deadly.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = 100000;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HallowedSuppressor>());
			recipe.AddIngredient(ModContent.ItemType<Suppressor>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 7;
			player.GetDamage(DamageClass.Ranged) *= 0.95f;
		}
	}
}