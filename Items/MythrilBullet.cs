using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class MythrilBullet : ModItem
	{

        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Splits into 3 bullets after a short time");
        }
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MusketBall);
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper:10);
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<Projectiles.MythrilBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MythrilBullet>(), 90);
			recipe.AddIngredient(ItemID.MythrilBar, 1);
			recipe.AddIngredient(ItemID.MusketBall, 90);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}