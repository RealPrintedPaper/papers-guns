using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class PossessedArmBand : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Possessed Tactical Glove");
			// Tooltip.SetDefault("5% increased ranged damage and critical strike chance\nMost ranged weapons become automatic\n");
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<PossessedArmBand>());
			recipe.AddIngredient(ModContent.ItemType<ArmBand>(), 1);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 5;
			player.GetDamage(DamageClass.Ranged) *= 1.05f;
			if (player.HeldItem.DamageType == DamageClass.Ranged & player.HeldItem.channel == false)
			{
				if (player.HeldItem.autoReuse == false & player.HeldItem.useAnimation >= 5)
                {
					player.releaseUseItem = true;
				}
			}
		}
    }
}