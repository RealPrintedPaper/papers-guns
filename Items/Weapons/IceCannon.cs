using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class IceCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses snowballs for ammo\nShoots multiple high speed icicles\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = ItemID.Snowball;
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 3 + Main.rand.Next(5);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity + perturbedSpeed, ProjectileID.Blizzard, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<IceCannon>());
			recipe.AddIngredient(ModContent.ItemType<FrostGun>(), 2);
			recipe.AddIngredient(ItemID.Snowball, 50);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.IceBlock, 100);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();
		}
	}
}