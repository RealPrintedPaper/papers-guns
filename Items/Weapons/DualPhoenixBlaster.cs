using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class DualPhoenixBlaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Now we're talkin'.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 13f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Crafting Recipe

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DualPhoenixBlaster>());
			recipe.AddIngredient(ItemID.PhoenixBlaster, 2);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<DualPhoenixBlaster>());
			recipe2.AddIngredient(ItemID.Handgun, 2);
			recipe2.AddIngredient(ItemID.HellstoneBar, 20);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();

			Recipe recipe3 = Recipe.Create(ModContent.ItemType<DualPhoenixBlaster>());
			recipe3.AddIngredient(ModContent.ItemType<DualHandgun>(), 1);
			recipe3.AddIngredient(ItemID.HellstoneBar, 20);
			recipe3.AddTile(TileID.Anvils);
			recipe3.Register();

		}

	}
}