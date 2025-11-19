using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class CheapMusketBall : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 2;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ModContent.ProjectileType<Projectiles.CheapMusketBall>();
			Item.shootSpeed = 1f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<CheapMusketBall>(), 75);
			recipe.AddIngredient(ItemID.TinBar, 1);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<CheapMusketBall>(), 75);
			recipe2.AddIngredient(ItemID.CopperBar, 1);
			recipe2.Register();
		}
	}
}