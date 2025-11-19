using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class LaserAssaultRifle : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("15% chance to not consume ammo.");
		}
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item12;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.RedLaser>();
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 3);
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .15f;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserAssaultRifle>());
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.AddIngredient(ItemID.Ruby, 4);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<LaserAssaultRifle>());
			recipe2.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe2.AddIngredient(ItemID.GoldBar, 15);
			recipe2.AddIngredient(ItemID.Ruby, 4);
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe2.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}