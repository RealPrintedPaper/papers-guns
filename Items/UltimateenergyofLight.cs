using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PapersGuns.Items
{
	public class UltimateenergyofLight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Energy of Light");
			// Tooltip.SetDefault("This pulsating orb of energy fuels all that emmits light.");
		}
		public override void SetDefaults()
		{
			Item.expert = true;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(platinum: 20);
			Item.rare = ItemRarityID.Yellow;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<UltimateenergyofLight>());
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Diode>(), 100);
			recipe.AddIngredient(ItemID.LargeAmber, 5);
			recipe.AddIngredient(ItemID.LargeAmethyst, 5);
			recipe.AddIngredient(ItemID.LargeDiamond, 5);
			recipe.AddIngredient(ItemID.LargeEmerald, 5);
			recipe.AddIngredient(ItemID.LargeRuby, 5);
			recipe.AddIngredient(ItemID.LargeSapphire, 5);
			recipe.AddIngredient(ItemID.LargeTopaz, 5);
			recipe.AddIngredient(ModContent.ItemType<Weapons.LaserAssaultRifleIII>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.LaserPistolIII>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.LaserShotgunIII>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.LaserSniperRifleIII>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.LaserMinigunIII >());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		/*public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = Mod.GetTexture("Items/UltimateenergyofLight");
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