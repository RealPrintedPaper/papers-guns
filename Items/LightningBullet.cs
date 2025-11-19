using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class LightningBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(copper: 15);
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<Projectiles.LightningBullet>();
			Item.shootSpeed = 1f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe2 = Recipe.Create(ModContent.ItemType<LightningBullet>(), 200);
			recipe2.AddIngredient(ItemID.PixieDust, 2);
			recipe2.AddIngredient(ItemID.SoulofLight, 1);
			recipe2.AddIngredient(ItemID.MusketBall, 200);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}