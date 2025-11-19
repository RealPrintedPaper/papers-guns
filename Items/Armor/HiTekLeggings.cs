using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class HiTekLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hi-Tek Pants");
			// Tooltip.SetDefault("25% increased attack damage and critical strike chance\n45% increased movement speed\nImmune to fall damage\nIncreased jumping abilities");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(platinum: 2);
			Item.rare = ItemRarityID.Cyan;
			Item.defense = 50;
			Item.expert = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.45f;
			player.GetDamage(DamageClass.Ranged) += 0.25f;
			player.GetCritChance(DamageClass.Ranged) += 25;
			player.noFallDmg = true;
			player.jumpBoost = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HiTekLeggings>());
			recipe.AddIngredient(ItemID.ShroomiteLeggings);
			recipe.AddIngredient(ItemID.VortexLeggings);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 45);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}