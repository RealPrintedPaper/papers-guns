using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class LaserShotgun : ModItem
	{

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item33;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 4 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ModContent.ProjectileType<Projectiles.GreenLaser>(), damage, knockback, player.whoAmI);
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserShotgun>());
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddIngredient(ItemID.PlatinumBar, 20);
			recipe.AddIngredient(ItemID.Emerald, 4);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<LaserShotgun>());
			recipe2.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe2.AddIngredient(ItemID.GoldBar, 20);
			recipe2.AddIngredient(ItemID.Emerald, 4);
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe2.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}