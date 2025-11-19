using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class PalladiumBullet : ModItem
	{

        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Gives the player increased life regen on hit");
        }
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MusketBall);
			Item.damage += 2;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper:5);
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<Projectiles.PalladiumBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<PalladiumBullet>(), 100);
			recipe.AddIngredient(ItemID.PalladiumBar, 1);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}