using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class CobaltBullet : ModItem
	{

        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Accelerates and does more damage over time");
        }
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MusketBall);
			Item.damage += 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper:5);
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<Projectiles.CobaltBulletP>();
			Item.shootSpeed = 1f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<CobaltBullet>(), 100);
			recipe.AddIngredient(ItemID.CobaltBar, 1);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}