using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class Suppressor : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("15% decreased ranged damage, 6% increased critical strike chance\n'Silent, but deadly.'\n");
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<Suppressor>());
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 6;
			player.GetDamage(DamageClass.Ranged) *= 0.85f;
		}
	}
}