using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class PumpkinSeedler : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into pumpkin seeds\nPumpkin seeds pierce and have a chance to poison enemies\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			if (type == ProjectileID.Bullet)
            {
				type = ModContent.ProjectileType<Projectiles.PumpkinSeed>();
            }
        }

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<PumpkinSeedler>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddIngredient(ItemID.Pumpkin, 25);
			recipe.AddIngredient(ItemID.PumpkinSeed, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}