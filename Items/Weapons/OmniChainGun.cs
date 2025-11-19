using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class OmniChainGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a random pre-hardmode or early hardmode bullet\n35% chance to not consume ammo\n'An aggressive gumball machine.'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 211111;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .35f;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			int rot = Main.rand.Next(-5, 5);
			player.itemRotation += MathHelper.ToRadians(rot);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
			type = Main.rand.Next(new int[] { type, ProjectileID.Bullet, ProjectileID.MeteorShot, ModContent.ProjectileType<Projectiles.CheapMusketBall>(), ProjectileID.CrystalBullet, ProjectileID.CursedBullet, ProjectileID.IchorBullet, ProjectileID.PartyBullet, ProjectileID.ExplosiveBullet, ProjectileID.GoldenBullet });
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<OmniChainGun>());
			recipe.AddIngredient(ModContent.ItemType<Omnipistol>(), 1);
			recipe.AddIngredient(ItemID.CrystalBullet, 5);
			recipe.AddIngredient(ItemID.CursedBullet, 5);
			recipe.AddIngredient(ItemID.PartyBullet, 5);
			recipe.AddIngredient(ItemID.ExplodingBullet, 5);
			recipe.AddIngredient(ItemID.GoldenBullet, 5);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<OmniChainGun>());
			recipe2.AddIngredient(ModContent.ItemType<Omnipistol>(), 1);
			recipe2.AddIngredient(ItemID.CrystalBullet, 5);
			recipe2.AddIngredient(ItemID.IchorBullet, 5);
			recipe2.AddIngredient(ItemID.PartyBullet, 5);
			recipe2.AddIngredient(ItemID.ExplodingBullet, 5);
			recipe2.AddIngredient(ItemID.GoldenBullet, 5);
			recipe2.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe2.AddIngredient(ItemID.IllegalGunParts);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.Register();
		}
	}
}