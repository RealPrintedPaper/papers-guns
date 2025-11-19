using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class ChlorectreBullet : ModItem
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Haunted Bullet");
			// Tooltip.SetDefault("Goes through tiles and chases your enemies\n'The cursed hunt begins.'\n");
		}

        public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = 0;
			Item.rare = ItemRarityID.Lime;
			Item.shoot = ModContent.ProjectileType<Projectiles.ChlorectreBullet>();
			Item.shootSpeed = 8f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ChlorectreBullet>(), 60);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 60);
			recipe.AddIngredient(ItemID.SpectreBar, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<ChlorectreBullet>(), 60);
			recipe2.AddIngredient(ModContent.ItemType<SpectreBullet>(), 60);
			recipe2.AddIngredient(ItemID.ChlorophyteBar, 1);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.Register();
		}
	}
}