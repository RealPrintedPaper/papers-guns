using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class SpectreBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Goes through tiles\n");
		}

		public override void SetDefaults()
		{
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = 0;
			Item.rare = ItemRarityID.Lime;
			Item.shoot = ModContent.ProjectileType<Projectiles.SpectreBullet>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<SpectreBullet>(), 60);
			recipe.AddIngredient(ItemID.MusketBall, 60);
			recipe.AddIngredient(ItemID.SpectreBar, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}