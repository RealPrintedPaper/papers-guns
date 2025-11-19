using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class TitaniumBullet : ModItem
	{

        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Creates titanium shards on impact");
        }
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.CrystalBullet);
			Item.damage += 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.sellPrice(copper:15);
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<Projectiles.TitaniumBulletP>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TitaniumBullet>(), 80);
			recipe.AddIngredient(ItemID.TitaniumBar, 1);
			recipe.AddIngredient(ItemID.CrystalBullet, 80);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}