using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GhilliCoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ghillie Coat");
			// Tooltip.SetDefault("5% increased ranged critical strike chance");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.White;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 5;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GhilliCoat>());
			recipe.AddIngredient(ItemID.Hay, 50);
			recipe.AddIngredient(ItemID.GrassWall, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}