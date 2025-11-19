using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PapersGuns.Items
{
	public class UltimateenergyofChaos : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Energy of Chaos");
			// Tooltip.SetDefault("This pulsating orb of energy fuels all that is uncontrollable.");
		}
		public override void SetDefaults()
		{
			Item.expert = true;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(platinum: 20);
			Item.rare = ItemRarityID.Purple;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<UltimateenergyofChaos>());
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Weapons.SuperRocketGrenadeLauncher>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.SandMinigun>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.HyperRealisticar15>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.ScytheCannon>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.ShadowflameThrower>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.SnowballCannonMkII>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.SnowballMachinecannon>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.SpeakerGun>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.BigFungus>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.TripleRocketLauncher>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.SuperStarCannon>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.WorldsSmallestGun>());
			recipe.AddIngredient(ModContent.ItemType<Weapons.MeteorCannon>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

		/*public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = Mod.GetTexture("Items/UltimateenergyofChaos");
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