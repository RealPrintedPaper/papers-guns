using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class FirstAidKit : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("4 defense\nReduces the cooldown of healing potions by 25%\nGreatly increases life regen\nHeals 50 health at random chance\nThe lower your health, the greater the chance of healing\n'Here, patch yourself up.'\n'Take this medkit.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.sellPrice(gold: 30);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FirstAidKit>());
			recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(ModContent.ItemType<MRE>(), 2);
			recipe.AddIngredient(ModContent.ItemType<Bandage>(), 5);
			recipe.AddIngredient(ItemID.SuperHealingPotion, 30);
			recipe.AddIngredient(ItemID.CelestialStone, 1);
			recipe.AddIngredient(ItemID.CharmofMyths, 1);
			recipe.AddIngredient(ItemID.BandofRegeneration, 4);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 4;
			player.lifeRegen += 15;
			player.pStone = true;
			if (player.statLife < player.statLifeMax)
			{
				System.Random rnd = new System.Random();
				int chance = rnd.Next(1, 350 + (player.statLife * 2));
				if (chance == 2)
				{
					SoundEngine.PlaySound(SoundID.Item4, player.position);
					player.statLife += 50;
					if (Main.myPlayer == player.whoAmI)
					{
						player.HealEffect(50, true);
					}
				}
			}
		}
	}
}