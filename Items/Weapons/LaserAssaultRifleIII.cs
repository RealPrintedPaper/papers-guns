using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class LaserAssaultRifleIII : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Laser Assault Rifle III");
			// Tooltip.SetDefault("25% chance to not consume ammo.");
		}
		//Stats
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(gold: 25);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item12;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .25f;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.RedLaserIII>();
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserAssaultRifleIII>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ModContent.ItemType<LaserAssaultRifleII>(), 1);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}