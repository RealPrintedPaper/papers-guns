using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class LaserSniperRifle : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 55;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item91;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.PinkLaser>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}

		//Zoom
		public override void HoldItem(Player player)
		{
			player.scope = true;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserSniperRifle>());
			recipe.AddIngredient(ItemID.MeteoriteBar, 7);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.AddIngredient(ItemID.PinkGel, 25);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<LaserSniperRifle>());
			recipe2.AddIngredient(ItemID.MeteoriteBar, 7);
			recipe2.AddIngredient(ItemID.GoldBar, 15);
			recipe2.AddIngredient(ItemID.PinkGel, 25);
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe2.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}