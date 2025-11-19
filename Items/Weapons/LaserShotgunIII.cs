using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class LaserShotgunIII : ModItem
	{
        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Laser Shotgun III");
        }
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 33;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 9;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item33;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.GreenLaser>();
			int numberProjectiles = 6 + Main.rand.Next(2);
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserShotgunIII>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ModContent.ItemType<LaserShotgunII>(), 1);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}