using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class SuperRocketGrenadeLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("45% chance to not consume ammo");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.RocketLauncher);
			Item.damage = 200;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 86;
			Item.height = 54;
			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(gold: 50);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;
			Item.crit = 46;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .45f;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 80f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 1 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Item.shoot = Main.rand.Next(new int[] { ProjectileID.RocketI, ProjectileID.GrenadeI });
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<SuperRocketGrenadeLauncher>());
			recipe.AddIngredient(ModContent.ItemType<GrenadeMachinegun>(), 1);
			recipe.AddIngredient(ModContent.ItemType<RocketMachinegun>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 2);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ItemID.ChainGun, 1);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}