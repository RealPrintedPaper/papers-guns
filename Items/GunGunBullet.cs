using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class GunGunBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("This might go badly...");
        }
        public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(copper: 5) ;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ModContent.ProjectileType<Projectiles.GunGunBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GunGunBullet>(), 75);
			recipe.AddIngredient(ItemID.HallowedBar, 2);
			recipe.AddIngredient(ModContent.ItemType<GunBullet>(), 75);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}