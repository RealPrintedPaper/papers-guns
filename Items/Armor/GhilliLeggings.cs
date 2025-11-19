using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace PapersGuns.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GhilliLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ghillie Leggings");
			// Tooltip.SetDefault("8% increased ranged damage and movement speed\n");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.White;
			Item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
			player.GetDamage(DamageClass.Ranged) += 0.08f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GhilliLeggings>());
			recipe.AddIngredient(ItemID.Hay, 25);
			recipe.AddIngredient(ItemID.GrassWall, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}