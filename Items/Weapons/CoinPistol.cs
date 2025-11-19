using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class CoinPistol : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Uses coins for ammo\nHigher valued coins do more damage\n");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.CoinGun);
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Green;
			Item.useTime = 15;
			Item.useAnimation = 15;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			damage /= 2;
        }

        //Crafting Recipe
        public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<CoinPistol>());
			recipe.AddIngredient(ItemID.PlatinumBar, 35);
			recipe.AddIngredient(ItemID.GoldBar, 32);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<CoinPistol>());
			recipe2.AddIngredient(ItemID.PlatinumBar, 35);
			recipe2.AddIngredient(ItemID.GoldBar, 32);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe2.AddIngredient(ItemID.IllegalGunParts);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}