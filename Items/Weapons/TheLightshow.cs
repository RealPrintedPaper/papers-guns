/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class TheLightshow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Lightshow");
			Tooltip.SetDefault("Shoots a Last Prism beam along with other laser/light based projectiles\nConsumes no ammo\n'A luminating experience.'");
		}

		public override void SetDefaults()
		{
			// Start by using CloneDefaults to clone all the basic item properties from the vanilla Last Prism.
			// For example, this copies sprite size, use style, sell price, and the item being a magic weapon.
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 354;
			Item.height = 124;
			Item.value = Item.sellPrice(platinum: 15);
			Item.DamageType = DamageClass.Ranged;
			Item.channel = true;
			Item.mana = 0;
			Item.damage = 100;
			Item.UseSound = SoundID.Item68;
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.scale = 0f;
			Item.shoot = ModContent.ProjectileType<Projectiles.LightshowPrismHoldout>();
			//item.shoot = ProjectileID.LastPrism;
			Item.shootSpeed = 30f;
		}

        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 700f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Projectile.NewProjectile(position.X, position.Y, speedX * 5, speedY * 5, ProjectileID.LastPrism, 0, 0, player.whoAmI);
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-40, 10);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheLightshow>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 20);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 200);
			recipe.AddIngredient(ItemID.CrystalShard, 500);
			recipe.AddIngredient(ItemID.LunarBar, 95);
			recipe.AddIngredient(ItemID.SpectreBar, 150);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofLight>());
			recipe.AddIngredient(ItemID.LastPrism, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

		}

		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.LightshowPrismHoldout>()] <= 0;
		//public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ProjectileID.LastPrism] <= 0;
	}
}*/