using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PapersGuns.Items
{
	public class UltimateenergyoftheUniverse : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Energy of the Universe");
			// Tooltip.SetDefault("This pulsating orb of energy fuels the universe.\n'The universe is in your hands. Use it wisely.'");
		}
		public override void SetDefaults()
		{
			Item.expert = true;
			Item.width = 166;
			Item.height = 166;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(platinum: 100);
			Item.rare = ItemRarityID.White;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<UltimateenergyoftheUniverse>());
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 20);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofChaos>());
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofGreed>());
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofHell>());
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofLight>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		/*public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = Mod.GetTexture("Items/UltimateenergyoftheUniverse");
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