using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class FingerGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Ayyy.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0;
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 4f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FingerGun>());
			recipe.Register();
		}
	}
}