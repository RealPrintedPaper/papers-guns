using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PapersGuns.Items
{
	public class UltimateenergyofHell : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Energy of Hell");
			// Tooltip.SetDefault("This pulsating orb of energy fuels the underworld.");
		}
		public override void SetDefaults()
		{
			Item.expert = true;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(platinum: 20);
			Item.rare = ItemRarityID.Red;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<UltimateenergyofHell>());
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Weapons.BreathoftheFallen>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.MakeshiftFlamethrower>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.GhastThrower>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.ShadowflameThrower>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.PhoenixsWrath>());
			recipe.AddIngredient(ItemID.Flamethrower);
			recipe.AddIngredient(ModContent.ItemType<Weapons.DualDualPhoenixBlaster>());
			recipe.AddIngredient(ItemID.MagmaStone, 5);
			recipe.AddIngredient(ItemID.ObsidianRose, 2);
			recipe.AddIngredient(ItemID.Sunfury);
			recipe.AddIngredient(ItemID.HellstoneBar, 150);
			recipe.AddIngredient(ItemID.DemonScythe, 2);
			recipe.AddIngredient(ItemID.UnholyTrident);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		/*public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = Mod.GetTexture("Items/UltimateenergyofHell");
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