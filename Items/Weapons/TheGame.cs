using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class TheGame : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Shoots a Terraria Beam\nConsumes no ammo\n'This cost you $10 to make. Use it right.'");
		}
		//Stats
		public override void SetDefaults()
		{
			Item.damage = 350;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 304;
			Item.height = 88;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(platinum: 10);
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.UseSound = SoundID.Item92;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.None;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			/*Vector2 muzzleOffset = Vector2.Normalize(velocity) * 150f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}*/
			type = ModContent.ProjectileType<Projectiles.TerrariaBeam>();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 10; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ProjectileID.TerrarianBeam, damage, knockback, player.whoAmI);
			}
			return true;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-40, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheGame>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>(), 10);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofChaos>());
			recipe.AddIngredient(ModContent.ItemType<TerraRifle>());
			recipe.AddIngredient(ModContent.ItemType<Terraflagration>());
			recipe.AddIngredient(ModContent.ItemType<Terrarupture>());
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.Terrarian);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}