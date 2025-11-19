using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class LaserSniperRifleIII : ModItem
	{
        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Laser Sniper Rifle III");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 110;
			Item.knockBack = 13;
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item91;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.PinkLaserIII>();
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserSniperRifleIII>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ModContent.ItemType<LaserSniperRifleII>(), 1);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}