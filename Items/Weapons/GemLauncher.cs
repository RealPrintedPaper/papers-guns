using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class GemLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a random gem\n45% chance to not consume ammo\nHighly innacurate\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 32f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .45f;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			int rot = Main.rand.Next(-12, 12);
			player.itemRotation += MathHelper.ToRadians(rot);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = Main.rand.Next(new int[] {ProjectileID.RubyBolt, ProjectileID.AmethystBolt, ProjectileID.SapphireBolt, ProjectileID.EmeraldBolt, ProjectileID.TopazBolt, ProjectileID.AmberBolt, ProjectileID.DiamondBolt });
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GemLauncher>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 7);
			recipe.AddIngredient(ModContent.ItemType<RubyPistol>(), 1);
			recipe.AddIngredient(ModContent.ItemType<AmethystPistol>(), 1);
			recipe.AddIngredient(ModContent.ItemType<SapphirePistol>(), 1);
			recipe.AddIngredient(ModContent.ItemType<EmeraldPistol>(), 1);
			recipe.AddIngredient(ModContent.ItemType<TopazPistol>(), 1);
			recipe.AddIngredient(ModContent.ItemType<AmberPistol>(), 1);
			recipe.AddIngredient(ModContent.ItemType<DiamondPistol>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

		}
	}
}