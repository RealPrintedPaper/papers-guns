using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class NineBarreledMusket : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Use more gun.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 31;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 120;
			Item.useAnimation = 120;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 18);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 9f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 7;
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			for (int i = 0; i < 9; i++)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, -2);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<NineBarreledMusket>());
			recipe.AddIngredient(ItemID.Musket, 9);
			recipe.AddIngredient(ItemID.ShadowScale, 15);
			recipe.AddRecipeGroup("IronBar", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}