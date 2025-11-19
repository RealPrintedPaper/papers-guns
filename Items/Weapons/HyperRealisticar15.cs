using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class HyperRealisticar15 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hyper Realistic AR-15");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.06f;
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 1, silver: 50);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HyperRealisticar15>());
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.AddIngredient(ModContent.ItemType<Accessories.BackupMagazine>(), 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}