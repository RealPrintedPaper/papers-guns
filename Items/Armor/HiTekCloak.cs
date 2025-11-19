using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace PapersGuns.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class HiTekCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hi-Tek Cloak");
			// Tooltip.SetDefault("25% increased ranged attack speed\n55% increased ranged attack damage\n25% increased ranged critical strike chance\nImmune to knockback\nChance to dodge attacks\nAbility to dash\n");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(platinum: 7);
			Item.rare = ItemRarityID.Cyan;
			Item.defense = 75;
			Item.expert = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 25;
			player.GetDamage(DamageClass.Ranged) += .55f;
			player.GetAttackSpeed(DamageClass.Ranged) *= 1.25f;
			player.noKnockback = true;
			player.blackBelt = true;
			player.dashType = 1;
		}



		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HiTekCloak>());
			recipe.AddIngredient(ItemID.ShroomiteBreastplate);
			recipe.AddIngredient(ItemID.VortexBreastplate);
			recipe.AddIngredient(ItemID.LunarBar, 45);
			recipe.AddIngredient(ItemID.FragmentVortex, 30);
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 15);
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 75);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}