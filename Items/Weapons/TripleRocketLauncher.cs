using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class TripleRocketLauncher : ModItem
	{

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 43;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 11);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
		}
		//Able to use right click
		public override bool AltFunctionUse(Terraria.Player player)
		{
			return true;
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 75f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			if (player.altFunctionUse == 2)
			{
				Item.shoot = ProjectileID.GrenadeI;
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					float scale = 1f - (Main.rand.NextFloat() * .1f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
				return false;
			}
			else
			{
				Item.shoot = ProjectileID.RocketI;
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					float scale = 1f - (Main.rand.NextFloat() * .3f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
				return false;
			}
		}

		//Secondary Use
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.UseSound = SoundID.Item61;
				Item.shoot = ProjectileID.GrenadeI;
			}
			else
			{
				Item.UseSound = SoundID.Item38;
				Item.shoot = ProjectileID.RocketI;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, -2);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TripleRocketLauncher>());
			recipe.AddIngredient(ItemID.RocketLauncher, 1);
			recipe.AddIngredient(ItemID.GrenadeLauncher, 2);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ItemID.Ectoplasm, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}