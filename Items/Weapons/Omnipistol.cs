using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class Omnipistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a random pre-hardmode bullet");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 111111;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = Main.rand.Next(new int[] { type, ProjectileID.Bullet, ProjectileID.MeteorShot, ModContent.ProjectileType<Projectiles.CheapMusketBall>() });
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 10);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Omnipistol>());
			recipe.AddIngredient(ModContent.ItemType<CheapMusketBall>(), 5);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.MusketBall, 5);
			recipe.AddIngredient(ItemID.MeteorShot, 5);
			recipe.AddIngredient(ItemID.SilverBullet, 5);
			recipe.AddRecipeGroup("IronBar", 14);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}