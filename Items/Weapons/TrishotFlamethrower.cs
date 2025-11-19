using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class TrishotFlamethrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tri-Shot Flamethrower");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Flamethrower);
			Item.width = 40;
			Item.height = 20;
		}

        //Spread
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			float rotation = MathHelper.ToRadians(22.5f);
			position += Vector2.Normalize(velocity) * 22.5f;
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (2 - 1))) * .8f;
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TrishotFlamethrower>());
			recipe.AddRecipeGroup("IronBar", 20);
			recipe.AddIngredient(ItemID.Flamethrower, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}