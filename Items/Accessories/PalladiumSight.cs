using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class PalladiumSight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("3% increased ranged critical strike chance\n7% increased ranged damage\n");
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<PalladiumSight>());
			recipe.AddIngredient(ModContent.ItemType<IronSight>(), 1);
			recipe.AddIngredient(ItemID.PalladiumBar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 5;
			player.GetDamage(DamageClass.Ranged) *= 1.07f;
		}
	}
}