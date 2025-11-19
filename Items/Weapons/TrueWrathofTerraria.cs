using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class TrueWrathofTerraria : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Wrath of Terraria");
			// Tooltip.SetDefault("Uses gel for ammo\nShoots a wrathflame that slows down and deals more damage over time\nOn death, wrathflames will explode into cursed flames and golden showers\nShoots 2 flames and 2 frostburns\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 11);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = ItemID.Gel;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.WrathFlame>();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float rotation = MathHelper.ToRadians(12f);
			position += Vector2.Normalize(velocity) * 12f;
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (2 - 1)));
				Projectile.NewProjectile(source, position, perturbedSpeed, ProjectileID.Flames, damage, knockback, player.whoAmI);
			}

			float rotation2 = MathHelper.ToRadians(6f);
			position += Vector2.Normalize(velocity) * 6f;
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation2, rotation2, i / (2 - 1)));
				Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<Projectiles.Frostburn>(), damage, knockback, player.whoAmI);
			}
			return true;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TrueWrathofTerraria>());
			recipe.AddIngredient(ModContent.ItemType<WrathofTerraria>());
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}