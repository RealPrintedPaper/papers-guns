using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class PoisonShardshooter : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Shoots poison fangs");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PoisonStaff);
			Item.DamageType = DamageClass.Ranged;
			Item.mana = 0;
			Item.width = 40;
			Item.height = 20;
			Item.UseSound = SoundID.Item36;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
            {
				type = ProjectileID.PoisonFang;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 3 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10));
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<PoisonShardshooter>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddIngredient(ItemID.PoisonStaff);
			recipe.AddIngredient(ItemID.Shotgun);
			recipe.AddIngredient(ItemID.SpiderFang, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}