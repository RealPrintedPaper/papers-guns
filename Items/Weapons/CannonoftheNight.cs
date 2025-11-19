using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class CannonoftheNight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cannon of the Night");
			// Tooltip.SetDefault("Alternate fire unleashes two Onyx rockets");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.reuseDelay = 15;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item125;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
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
				type = ProjectileID.BlackBolt;
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse < 2)
			{
				int numberProjectiles = 4 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
					float scale = 1f - (Main.rand.NextFloat() * .3f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
			}
			return true;
		}

		//Secondary Use
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 6;
				Item.reuseDelay = 16;
				Item.useAnimation = 12;
				Item.shootSpeed = 20f;
				Item.UseSound = SoundID.Item125;
				Item.consumeAmmoOnLastShotOnly = true;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 30;
				Item.useAnimation = 30;
				Item.shootSpeed = 16f;
				Item.UseSound = SoundID.Item36;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 6);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<CannonoftheNight>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 5);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.PhoenixBlaster);
			recipe.AddIngredient(ItemID.Handgun);
			recipe.AddIngredient(ItemID.Musket);
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<CannonoftheNight>());
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 5);
			recipe2.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe2.AddIngredient(ItemID.PhoenixBlaster);
			recipe2.AddIngredient(ItemID.Handgun);
			recipe2.AddIngredient(ItemID.TheUndertaker);
			recipe2.AddIngredient(ItemID.Boomstick);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.Register();
		}
	}
}