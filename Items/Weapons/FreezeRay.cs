using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class FreezeRay : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a frigid ray of freeze\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.HeatRay);
            Item.DamageType = DamageClass.Ranged;
			Item.damage += 5;
            Item.mana = 0;
			Item.useAmmo = AmmoID.None;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.FreezingRay>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 5);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FreezeRay>());
			recipe.AddIngredient(ItemID.HeatRay);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddIngredient(ItemID.IceRod);
			recipe.AddIngredient(ItemID.IceBlock, 99);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}