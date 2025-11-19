using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class RediculousRinser : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n25% chance to not consume ammo\n'It doesn't have the orange tip! RUN FOR YOUR LIVES!!!'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 80;
			Item.height = 54;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item95;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Gel;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 70f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
			type = ModContent.ProjectileType<Projectiles.Slimey>();
        }

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .25f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<RediculousRinser>());
			recipe.AddIngredient(ModContent.ItemType<SlimerGun>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.SlimeGun);
			recipe.AddIngredient(ItemID.WaterGun);
			recipe.AddIngredient(ItemID.WaterBucket);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}