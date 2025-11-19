using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class ShroomiteBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Goes in random directions\nLeaves a trail of mushrooms and has a chance to split\n");
		}
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 3;
			Item.value = 0;
			Item.rare = ItemRarityID.Lime;
			Item.shoot = ModContent.ProjectileType<Projectiles.ShroomiteBullet>();
			Item.shootSpeed = 0.5f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ShroomiteBullet>(), 100);
			recipe.AddIngredient(ItemID.ShroomiteBar);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}