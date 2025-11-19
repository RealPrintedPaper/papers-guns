using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class HellsHabit : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hell's Habit");
			// Tooltip.SetDefault("20% chance to not consume ammo\nShoots fire bullets\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .2f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 6);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
            {
				type = ModContent.ProjectileType<Projectiles.FireBulletP>();
            }
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HellsHabit>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 2);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.HellstoneBar, 25);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}