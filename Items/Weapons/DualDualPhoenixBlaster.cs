using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class DualDualPhoenixBlaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'I think you should reconsider...'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.9f;
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 2;
			Item.useAnimation = 2;
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<DualDualPhoenixBlaster>());
			recipe.AddIngredient(ItemID.PhoenixBlaster, 4);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<DualDualPhoenixBlaster>());
			recipe2.AddIngredient(ItemID.Handgun, 4);
			recipe2.AddIngredient(ItemID.HellstoneBar, 40);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();

			Recipe recipe3 = Recipe.Create(ModContent.ItemType<DualDualPhoenixBlaster>());
			recipe3.AddIngredient(ModContent.ItemType<DualHandgun>(), 2);
			recipe3.AddIngredient(ItemID.HellstoneBar, 40);
			recipe3.AddTile(TileID.Anvils);
			recipe3.Register();

			Recipe recipe4 = Recipe.Create(ModContent.ItemType<DualDualPhoenixBlaster>());
			recipe4.AddIngredient(ModContent.ItemType<DualPhoenixBlaster>(), 2);
			recipe4.Register();

		}

	}
}