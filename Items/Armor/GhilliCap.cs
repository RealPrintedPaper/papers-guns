using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GhilliCap : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ghillie Cap");
			// Tooltip.SetDefault("2% increased ranged damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.White;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 2;
			player.GetDamage(DamageClass.Ranged) += 0.02f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<GhilliCoat>() && legs.type == ModContent.ItemType<GhilliLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Not moving puts you in stealth,\nincreasing ranged ability and reducing chance for enemies to target you";
			player.shroomiteStealth = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GhilliCap>());
			recipe.AddIngredient(ItemID.Hay, 25);
			recipe.AddIngredient(ItemID.GrassWall, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}