using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class TerraRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Replaces musket balls with cursed or ichor shots\nHas a chance to shoot either Terra beam or Onyx blast\n45% chance to not consume ammo\n'Yeah yeah, very original.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .45f;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.CursedBullet;
				type = Main.rand.Next(new int[] { type, ProjectileID.IchorBullet });
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (Main.rand.NextBool(5))
			{
				Projectile.NewProjectile(source, position, velocity, Main.rand.Next(new int[] { ProjectileID.TerraBeam, ProjectileID.BlackBolt }), damage, knockback, player.whoAmI);
			}
			return true;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TerraRifle>());
			recipe.AddIngredient(ModContent.ItemType<TrueCannonoftheNight>());
			recipe.AddIngredient(ModContent.ItemType<TrueSwordGun>());
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}