using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PapersGuns.Items
{
	public class EnergyFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("It pulsates and emits pure energy.");
		}
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(gold: 1);
			Item.expert = true;
			Item.rare = ItemRarityID.White;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.Pink.ToVector3() * 0.55f * Main.essScale);
		}

		/*public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = Mod.GetTexture("Items/EnergyFragment");
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