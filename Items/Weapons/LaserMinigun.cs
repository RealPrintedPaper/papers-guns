using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class LaserMinigun : ModItem
	{
        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Laser Minigun");
			// Tooltip.SetDefault("35% chance to not consume ammo.");
		}
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 3;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
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
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 80f;
			position += muzzleOffset;
			type = ModContent.ProjectileType<Projectiles.YellowLaser>();
			int rot = Main.rand.Next(-6, 6);
			player.itemRotation += MathHelper.ToRadians(rot);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, -6);
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .35f;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserMinigun>());
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.AddIngredient(ItemID.Topaz, 4);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<LaserMinigun>());
			recipe2.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe2.AddIngredient(ItemID.GoldBar, 15);
			recipe2.AddIngredient(ItemID.Topaz, 4);
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe2.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}