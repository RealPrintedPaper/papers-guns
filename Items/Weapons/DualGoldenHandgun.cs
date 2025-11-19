using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class DualGoldenHandgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Decaffinated.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 6;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DualGoldenHandgun>());
			recipe.AddIngredient(ModContent.ItemType<DualHandgun>(), 1);
			recipe.AddIngredient(ItemID.GoldBar, 33);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<DualGoldenHandgun>());
			recipe2.AddIngredient(ItemID.Handgun, 2);
			recipe2.AddIngredient(ItemID.GoldBar, 33);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}