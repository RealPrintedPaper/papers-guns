using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class PetalGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into petals\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item39;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 18f;
			Item.useAmmo = AmmoID.Bullet;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 5 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(13));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				velocity = velocity * scale; 
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ProjectileID.FlowerPetal, damage, knockback, player.whoAmI);
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<PetalGun>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.PinkGel, 25);
			recipe.AddIngredient(ItemID.PinkPricklyPear, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}