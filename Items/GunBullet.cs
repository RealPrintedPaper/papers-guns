using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items
{
	public class GunBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("That's 65% more gun per bullet.");
        }
        public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ModContent.ProjectileType<Projectiles.GunBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GunBullet>(), 75);
			recipe.AddRecipeGroup("IronBar", 2);
			recipe.AddIngredient(ItemID.MusketBall, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}