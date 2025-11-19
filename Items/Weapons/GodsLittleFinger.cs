using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class GodsLittleFinger : ModItem
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("God's Little Finger");
			// Tooltip.SetDefault("Shoots hallow point bullets\nSummons bullets around the player that shoot toward the cursor after building up\nRight click to rain bullets on your cursor\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0;
			Item.damage = 2100;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(platinum: 10);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item39;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.None;
			Item.expert = true;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse < 2)
			{
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.HallowPointBullet>(), damage, knockback, player.whoAmI);
			}
			else
            {
				Projectile.NewProjectile(source, Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<Projectiles.Point>(), damage, knockback, player.whoAmI);
			}
			return false;
		}
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.useTime = 8;
				Item.useAnimation = 8;
				Item.autoReuse = true;
			}
			else
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
				Item.autoReuse = false;
			}
			return base.CanUseItem(player);
		}
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GodsLittleFinger>());
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 15);
			recipe.AddIngredient(ModContent.ItemType<FingerGun>());
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}