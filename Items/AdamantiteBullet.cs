using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class AdamantiteBullet : ModItem
	{

        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Has a chance to deal massive damage and knockback");
        }
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MusketBall);
			Item.damage += 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper:15);
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<Projectiles.AdamantiteBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<AdamantiteBullet>(), 80);
			recipe.AddIngredient(ItemID.AdamantiteBar, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.HeavyBullet>(), 80);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}