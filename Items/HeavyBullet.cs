using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class HeavyBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 10;
			Item.value = Item.sellPrice(copper: 5);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<Projectiles.HeavyBullet>();
			Item.shootSpeed = 6f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe2 = Recipe.Create(ModContent.ItemType<HeavyBullet>(), 50);
			recipe2.AddRecipeGroup("IronBar", 4);
			recipe2.AddIngredient(ItemID.MusketBall, 50);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}