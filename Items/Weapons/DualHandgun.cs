using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class DualHandgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Two is better than one.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DualHandgun>());
			recipe.AddIngredient(ItemID.Handgun, 2);
			recipe.Register();
		}
	}
}