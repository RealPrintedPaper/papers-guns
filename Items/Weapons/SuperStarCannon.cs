using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class SuperStarCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Super Star Cluster Cannon");
			// Tooltip.SetDefault("96% chance to not consume ammo");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 1.2f;
			Item.damage = 300;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(platinum: 3);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item73;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ItemID.FallenStar;
			Item.crit = 46;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .96f;
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 100f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			if (type == ProjectileID.PurificationPowder)
			{
				int numberProjectiles = 2 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					float scale = 1f - (Main.rand.NextFloat() * .1f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, Main.rand.Next(new int[] { ProjectileID.FallingStar, ProjectileID.Starfury, ProjectileID.StarWrath, ProjectileID.HallowStar }), damage, knockback, player.whoAmI);
				}
			}
			else
            {
				int numberProjectiles = 2 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					float scale = 1f - (Main.rand.NextFloat() * .1f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, -5);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<SuperStarCannon>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 3);
			recipe.AddIngredient(ModContent.ItemType<TrishotStarCannon>(), 2);
			recipe.AddIngredient(ModContent.ItemType<MeowCannon>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 2);
			recipe.AddIngredient(ItemID.IllegalGunParts, 3);
			recipe.AddIngredient(ItemID.StarCloak, 1);
			recipe.AddIngredient(ItemID.Starfury, 1);
			recipe.AddIngredient(ItemID.StarWrath, 2);
			recipe.AddIngredient(ItemID.HolyArrow, 999);
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.AddIngredient(ItemID.StarCannon, 5);
			recipe.AddIngredient(ItemID.LunarBar, 35);
			recipe.AddIngredient(ItemID.FragmentVortex, 75);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}