using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class Harmonica : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n'Harm many.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ItemID.Gel;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 2 + Main.rand.Next(2); i++)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(source, position, velocity, Main.rand.Next(new int[] { ModContent.ProjectileType<Projectiles.Frostburn>(), ProjectileID.Flames }), damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Harmonica>());
			recipe.AddIngredient(ModContent.ItemType<Frostthrower>());
			recipe.AddIngredient(ModContent.ItemType<BreathoftheFallen>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}