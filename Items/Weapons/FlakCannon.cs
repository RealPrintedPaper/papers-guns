using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class FlakCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'A little shrapnel can dish out a hell of a lot of damage.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = 8;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Rocket;
			Item.crit = 1;
		}

		//Able to use right click
		public override bool AltFunctionUse(Terraria.Player player)
		{
			return true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				Item.shoot = ProjectileID.GrenadeI;
			}
			else
            {
				type = ProjectileID.MeteorShot;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse < 2)
			{
				int numberProjectiles = 6 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
					float scale = 1f - (Main.rand.NextFloat() * .25f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage - 65, knockback, player.whoAmI);
				}
				return false;
			}
			else
            {
				return true;
            }
        }

        //Secondary Use
        public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 45;
				Item.useAnimation = 45;
				Item.damage = 125;
				Item.shootSpeed = 10f;
				Item.UseSound = SoundID.Item61;
				Item.shoot = ProjectileID.GrenadeI;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 40;
				Item.useAnimation = 40;
				Item.damage = 55;
				Item.shootSpeed = 16f;
				Item.UseSound = SoundID.Item36;
				Item.shoot = ProjectileID.MeteorShot;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FlakCannon>());
			recipe.AddIngredient(ItemID.GrenadeLauncher, 1);
			recipe.AddIngredient(ItemID.Boomstick, 1);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}