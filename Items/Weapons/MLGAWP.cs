using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class MLGAWP : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("MLG AWP");
			// Tooltip.SetDefault("Shoots a powerful, high velocity bullet that does... interesting effects on enemies\nN0SC0P3z 0NLY!!1! or u r scrubz. ( ͡° ͜ʖ ͡°)\n'MUM GET THE CAMERA!!!'\n");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 1337;
			Item.scale = 0;
			Item.value = Item.sellPrice(platinum: 10);
			Item.rare = ItemRarityID.Purple;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.expert = true;
			Item.UseSound = SoundID.Item1;
			Item.shootSpeed = 1f;
			Item.useStyle = ItemUseStyleID.Swing;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.MLGAWP>(), damage, knockback, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MLGAWP>());
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Ntw20>());
			recipe.AddIngredient(ModContent.ItemType<SniperMachinegun>());
			recipe.AddIngredient(ModContent.ItemType<LaserSniperRifleIII>());
			recipe.AddIngredient(ModContent.ItemType<Dragunov>());
			recipe.AddIngredient(ModContent.ItemType<SpaceSniper>());
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}