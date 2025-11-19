using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class Lumilighter : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(gold: 20);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ItemID.Gel;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.Lumilight>();
        }

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Lumilighter>());
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}