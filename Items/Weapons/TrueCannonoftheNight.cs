using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class TrueCannonoftheNight : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Cannon of the Night");
			// Tooltip.SetDefault("Replaces musket balls with cursed or ichor shots\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 52;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.reuseDelay = 15;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item125;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}
		//Able to use right click
		public override bool AltFunctionUse(Terraria.Player player)
		{
			return true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.CursedBullet;
				type = Main.rand.Next(new int[] { type, ProjectileID.IchorBullet });
			}
			if (player.altFunctionUse == 2)
			{
				type = ProjectileID.BlackBolt;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse < 2)
			{
				int numberProjectiles = 4 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));
					float scale = 1f - (Main.rand.NextFloat() * .1f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
				}
			}
			return true;
		}

        //Secondary Use
        public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 6;
				Item.reuseDelay = 16;
				Item.useAnimation = 12;
				Item.shootSpeed = 20f;
				Item.UseSound = SoundID.Item125;
				Item.shoot = ProjectileID.BlackBolt;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 30;
				Item.useAnimation = 30;
				Item.shootSpeed = 16f;
				Item.UseSound = SoundID.Item36;
				Item.shoot = AmmoID.Bullet;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, 4);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TrueCannonoftheNight>());
			recipe.AddIngredient(ModContent.ItemType<CannonoftheNight>());
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}