using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class Infernous : ModItem
	{

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.InfernoFork);
			Item.DamageType = DamageClass.Ranged;
			Item.mana = 0;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.InfernoFriendlyBolt;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 6);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Infernous>());
			recipe.AddIngredient(ItemID.InfernoFork);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}