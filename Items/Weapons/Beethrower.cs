using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class Beethrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n10% chance to not consume ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 92;
			Item.height = 22;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.buyPrice(gold: 40);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = ItemID.Gel;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .1f;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(12));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				velocity = velocity * scale;
				if (player.strongBees)
				{
					if (Main.rand.Next(4) == 0)
                    {
						Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ProjectileID.GiantBee, damage * 2, knockback, player.whoAmI);
					}
                    else
					{
						Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ProjectileID.Bee, damage, knockback, player.whoAmI);
					}
				}
				else
				{
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ProjectileID.Bee, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Beethrower>());
			recipe.AddIngredient(ItemID.HoneyBlock, 15);
			recipe.AddIngredient(ItemID.Hive, 10);
			recipe.AddIngredient(ItemID.BeeWax, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}