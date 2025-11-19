using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class TheMoneyMakersMinigun : ModItem
	{
        public override void SetStaticDefaults()
		{
			/* Tooltip.SetDefault("Shoots different coins, and on occasion, large coins\n" +
				"The higher tier coin, the more it pierces\n" +
				"Large copper coins explode into copper coins\n" +
				"Large silver coins pierce infinitely\n" +
				"Large gold coins shoot gold coins rapidly in random directions\n" +
				"Large platinum coins have all of the previous effects, allows enemies to drop more money\n" +
				"Consumes no ammo\n" +
				"'Peasants are no match for your power.'"); */
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 225;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 184;
			Item.height = 58;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(platinum: 25);
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.None;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 100f;
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
				int rot = Main.rand.Next(-5, 5);
				player.itemRotation += MathHelper.ToRadians(rot);
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(rot));
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, Main.rand.Next(new int[] { ProjectileID.CopperCoin, ProjectileID.SilverCoin, ProjectileID.GoldCoin, ProjectileID.PlatinumCoin }), damage, knockback, player.whoAmI); // theres probably a better way to do this but lol idk
			}
			if (Main.rand.Next(7) == 0)
			{
				Projectile.NewProjectile(source, position, velocity, Main.rand.Next(new int[] { ModContent.ProjectileType<Projectiles.LargeCopper>(), ModContent.ProjectileType<Projectiles.LargeSilver>(), ModContent.ProjectileType<Projectiles.LargeGold>(), ModContent.ProjectileType<Projectiles.LargePlatinum>() }), damage * 10, knockback, player.whoAmI);
			}

			if (Main.rand.Next(999) == 0)
			{
				Projectile.NewProjectile(source, position, velocity * 5, ProjectileID.CoinPortal, 0, 0, player.whoAmI);
			}
			return false;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 15);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheMoneyMakersMinigun>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 20);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 150);
			recipe.AddIngredient(ItemID.PlatinumCoin, 25);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.GoldBar, 200);
			recipe.AddIngredient(ItemID.PlatinumBar, 50);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofGreed>());
			recipe.AddIngredient(ModContent.ItemType<GoldenGun>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

		}
	}
}