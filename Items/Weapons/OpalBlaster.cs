using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class OpalBlaster : ModItem
	{

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.OnyxBlaster);
			Item.damage -= 8;
			Item.crit += 4;
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.OpalBlast>(), damage, knockback, player.whoAmI);
			for (int i = 0; i < 4; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<OpalBlaster>());
			recipe.AddIngredient(ItemID.Shotgun);
			recipe.AddIngredient(ItemID.LightShard, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}