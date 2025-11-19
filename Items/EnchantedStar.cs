using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class EnchantedStar : ModItem
	{
		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<Projectiles.EnchantedStar>();
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			Item.ammo = AmmoID.FallenStar;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<EnchantedStar>(), 5);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.UnicornHorn);
			recipe.AddIngredient(ItemID.PixieDust, 5);
			recipe.AddTile(TileID.Mythril);
			recipe.Register();
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.Pink.ToVector3() * 0.55f * Main.essScale);
		}
	}
}