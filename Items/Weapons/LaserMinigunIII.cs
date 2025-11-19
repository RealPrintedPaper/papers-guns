using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class LaserMinigunIII : ModItem
	{
        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Laser Minigun III");
			// Tooltip.SetDefault("55% chance to not consume ammo.");
		}
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.buyPrice(gold: 40);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item12;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 80f;
			position += muzzleOffset;
			int numberProjectiles = 1 + Main.rand.Next(4);
			for (int i = 0; i < numberProjectiles; i++)
			{
				int rot = Main.rand.Next(-6, 6);
				player.itemRotation += MathHelper.ToRadians(rot);
				velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.YellowLaser>(), damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, -6);
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .55f;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserMinigunIII>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ModContent.ItemType<LaserMinigunII>(), 1);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}