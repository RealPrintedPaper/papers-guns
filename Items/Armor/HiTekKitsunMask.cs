using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace PapersGuns.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HiTekKitsunMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hi-Tek Kitsun Mask");
			// Tooltip.SetDefault("40% increased ranged damage\n20% increased range critical strike chance\nImproves vision\n");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(platinum:5);
			Item.rare = ItemRarityID.Cyan;
			Item.defense = 50;
			Item.expert = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 20;
			player.GetDamage(DamageClass.Ranged) += 0.4f;
			player.nightVision = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HiTekCloak>() && legs.type == ModContent.ItemType<HiTekLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Vortex", Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN"));

			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] < 15)
            {
				player.setVortex = true;
            }
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HiTekKitsunMask>());
			recipe.AddIngredient(ItemID.ShroomiteHeadgear);
			recipe.AddIngredient(ItemID.ShroomiteHelmet);
			recipe.AddIngredient(ItemID.ShroomiteMask);
			recipe.AddIngredient(ItemID.VortexHelmet);
			recipe.AddIngredient(ItemID.LunarBar, 35);
			recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 50);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}