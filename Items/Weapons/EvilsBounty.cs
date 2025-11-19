using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class EvilsBounty : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'The power of both evils are in your hands.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 30);
			Item.rare = 8;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 1;
		}

		//Able to use right click
		public override bool AltFunctionUse(Terraria.Player player)
		{
			return true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				type = ProjectileID.VampireKnife;
			}
			else
			{
				type = ProjectileID.EatersBite;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2)
			{
				type = ProjectileID.VampireKnife;
				int numberProjectiles = 7 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					float scale = 1f - (Main.rand.NextFloat() * .1f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
			}
			else
			{
				type = ProjectileID.EatersBite;
				int numberProjectiles = 2 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					float scale = 1f - (Main.rand.NextFloat() * .1f);
					velocity = velocity * scale;
					Projectile.NewProjectile(source, position, velocity + perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
		}

        //Secondary Use
        public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 35;
				Item.useAnimation = 35;
				Item.damage = 18;
				Item.shootSpeed = 20f;
				Item.UseSound = SoundID.Item38;
                Item.shoot = ProjectileID.VampireKnife;
				Item.autoReuse = true;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.useTime = 40;
				Item.useAnimation = 40;
				Item.damage = 120;
				Item.shootSpeed = 16f;
				Item.UseSound = SoundID.Item36;
				Item.shoot = ProjectileID.EatersBite;
				Item.autoReuse = false;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<EvilsBounty>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 2);
			recipe.AddIngredient(ItemID.ScourgeoftheCorruptor, 1);
			recipe.AddIngredient(ItemID.VampireKnives, 1);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}