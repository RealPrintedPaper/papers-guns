using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class PoisonBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(copper:2);
			Item.rare = ItemRarityID.White;
			Item.shoot = ModContent.ProjectileType<Projectiles.PoisonBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<PoisonBullet>(), 50);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}