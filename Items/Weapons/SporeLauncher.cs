using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class SporeLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Replaces bullets with mushrooms\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(silver: 9);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 20;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Spread
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, ProjectileID.Mushroom, damage, knockback, player.whoAmI);
			float rotation = MathHelper.ToRadians(22.5f);
			position += Vector2.Normalize(velocity) * 22.5f;
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (2 - 1))) * .8f;
				Projectile.NewProjectile(source, position, perturbedSpeed, ProjectileID.Mushroom, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<SporeLauncher>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.GlowingMushroom, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}