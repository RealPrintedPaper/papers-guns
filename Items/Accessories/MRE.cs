using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	public class MRE : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("M.R.E");
			// Tooltip.SetDefault("Heals 20 health at random chance\nThe lower your health, the greater the chance of healing\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 30);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MRE>());
			recipe.AddIngredient(ItemID.PumpkinPie, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife != player.statLifeMax)
			{
				System.Random rnd = new System.Random();
				int chance = rnd.Next(1, 300 + (player.statLife * 2));
				if (chance == 1)
				{
					SoundEngine.PlaySound(SoundID.Item2, player.position);
					player.statLife += 20;
					if (Main.myPlayer == player.whoAmI)
					{
						player.HealEffect(20, true);
					}
				}
			}
		}
    }
}