using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class ArmBand : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tactical Glove");
			// Tooltip.SetDefault("4% increased ranged damage and critical strike chance\n'It makes you look tactically awesome.'\n");
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
			CreateRecipe()
			.AddIngredient(ItemID.Silk, 25)
			.AddTile(TileID.Loom)
			.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetCritChance(DamageClass.Ranged) += 4;
			player.GetDamage(DamageClass.Ranged) *= 1.04f;
        }
	}
}