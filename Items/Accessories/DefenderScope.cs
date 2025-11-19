using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using System;

namespace PapersGuns.Items.Accessories
{
	public class DefenderScope : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Increases view range for guns (Right Click to zoom out)\n10% increased ranged damage and critical strike chance\nCritical hits grants health\n");
		}


		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(gold: 7);
		}

        //Effect
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetDamage(DamageClass.Ranged) *= 1.10f; 
			
			if (player.HeldItem.useAmmo == AmmoID.Bullet)
			{
				player.scope = true;
			}

			player.GetModPlayer<PGPlayer>().vampirepointkiton = true;
		}
		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DefenderScope>());
			recipe.AddIngredient(ItemID.SniperScope, 1);
			recipe.AddIngredient(ModContent.ItemType<VampirePointKit>(), 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}