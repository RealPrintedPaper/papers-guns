using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class GoldenGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("50% chance to not consume ammo\n'Luxury weapon.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.CoinGun);
			Item.useTime = 4;
			Item.useAnimation = 4;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GoldenGun>());
			recipe.AddIngredient(ItemID.CoinGun, 2);
			recipe.AddIngredient(ItemID.PlatinumCoin, 1);
			recipe.AddIngredient(ItemID.GoldCoin, 99);
			recipe.AddIngredient(ItemID.SilverCoin, 99);
			recipe.AddIngredient(ItemID.CopperCoin, 99);
			recipe.AddIngredient(ItemID.LuckyCoin, 1);
			recipe.Register();
		}
	}
}