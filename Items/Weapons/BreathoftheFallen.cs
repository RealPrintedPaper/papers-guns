using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class BreathoftheFallen : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Breath of the Fallen");
			// Tooltip.SetDefault("Uses gel for ammo\n20% chance to not consume ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 1.3f;
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.buyPrice(gold: 40);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = ItemID.Gel;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .2f;
		}

		//Shooty Effects
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(12));
			type = ProjectileID.Flames;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(12));
			Projectile.NewProjectile(source, position, velocity, Main.rand.Next(new int[] { type, ProjectileID.BallofFire, ProjectileID.ImpFireball, ProjectileID.MolotovFire }), damage, knockback, player.whoAmI);
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<BreathoftheFallen>());
			recipe.AddIngredient(ItemID.HellstoneBar, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}