using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class ShadowRailgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Right Click to zoom out\n'Shoots shadows... at the speed of light?'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ShadowbeamStaff);
			Item.damage += 20;
			Item.crit = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.mana = 0;
			Item.autoReuse = false;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		//Zoom
		public override void HoldItem(Player player)
		{
			player.scope = true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.ShadowBeamFriendly;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ShadowRailgun>());
			recipe.AddIngredient(ItemID.ShadowbeamStaff);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}