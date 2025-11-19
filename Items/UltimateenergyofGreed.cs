using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PapersGuns.Items
{
	public class UltimateenergyofGreed : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Energy of Greed");
			// Tooltip.SetDefault("This pulsating orb of energy fuels the urge of precious minerals.");
		}
		public override void SetDefaults()
		{
			Item.expert = true;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(platinum: 20);
			Item.rare = ItemRarityID.Quest;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<UltimateenergyofGreed>());
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 5);
			recipe.AddIngredient(ItemID.CoinGun, 7);
			recipe.AddIngredient(ItemID.CoinRing, 7);
			recipe.AddIngredient(ItemID.LuckyCoin, 7);
			recipe.AddIngredient(ItemID.GoldBar, 777);
			recipe.AddIngredient(ItemID.GoldBunny, 7);
			recipe.AddIngredient(ItemID.GoldenKey, 77);
			recipe.AddIngredient(ItemID.GoldCrown, 7);
			recipe.AddIngredient(ItemID.GoldenCrateHard, 77);
			recipe.AddIngredient(ItemID.PlatinumCoin, 77);
			recipe.AddIngredient(ItemID.GoldenShower, 7);
			recipe.AddIngredient(ItemID.GoldenToilet, 77);
			recipe.AddIngredient(ItemID.GoldenBugNet, 7);
			recipe.AddIngredient(ItemID.GoldenFishingRod, 7);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		/*public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = Mod.GetTexture("Items/UltimateenergyofGreed");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Microsoft.Xna.Framework.Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}*/
	}
}