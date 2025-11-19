using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class HitmansSuitcase : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tactical Suitcase");
			// Tooltip.SetDefault("Increases view range for guns (Right Click to zoom out)\n25% increased ranged damage, critical strike chance, and attack speed\n25% chance to not consume ammo\nEnemies are less likely to target you\nAll ranged weapons become automatic\nCritical hits grant health\n'Take it.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Red;
			Item.value = 750000;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HitmansSuitcase>());
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.FragmentVortex, 45);
			recipe.AddIngredient(ModContent.ItemType<HallowedSuppressor>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BackupMagazine>(), 1);
			recipe.AddIngredient(ItemID.ReconScope, 1);
			recipe.AddIngredient(ModContent.ItemType<HyperScope>(), 1);
			recipe.AddIngredient(ModContent.ItemType<LaserSight>(), 1);
			recipe.AddIngredient(ModContent.ItemType<DefenderScope>(), 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetAttackSpeed(DamageClass.Ranged) *= 1.25f;
			player.GetDamage(DamageClass.Ranged) *= 1.25f;
			player.GetCritChance(DamageClass.Ranged) += 25;
			player.GetModPlayer<PGPlayer>().suitcaseon = true;

			player.aggro -= 400;

			if(player.HeldItem.useAmmo == AmmoID.Bullet)
            {
				player.scope = true;
			}

			if (player.HeldItem.DamageType == DamageClass.Ranged & player.HeldItem.channel == false)
			{
				player.releaseUseItem = true;
			}

			player.GetModPlayer<PGPlayer>().vampirepointkiton = true;
		}
    }
}