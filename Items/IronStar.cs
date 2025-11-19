using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class IronStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Shimmering with... No wait that's just a light reflection.'\n");
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.value = 500;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<Projectiles.IronStar>();
			Item.ammo = AmmoID.FallenStar;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<IronStar>());
			recipe.AddRecipeGroup("IronBar", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}