using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class GiantHandGun : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Handgun);
			Item.scale = 3;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileID.RocketI;
			Item.shootSpeed = 18f;
			Item.useAmmo = AmmoID.Rocket;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 4);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GiantHandGun>());
			recipe.AddIngredient(ItemID.Handgun, 2);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}