using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class FireBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(copper:10);
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ModContent.ProjectileType<Projectiles.FireBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FireBullet>(), 100);
			recipe.AddIngredient(ItemID.HellstoneBar);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}