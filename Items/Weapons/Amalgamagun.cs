using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class Amalgamagun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Right click to fire inferno bolt\n'Gone n' amalgamated 'em all on my gun, n' done molded my Amalgamagun.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 35);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item36;
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
			if (player.altFunctionUse == 2)
			{
				type = ProjectileID.InfernoFriendlyBolt;
			}
			else
			{
				type = ProjectileID.ShadowBeamFriendly;
			}
		}

		//Secondary Use
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
				Item.UseSound = SoundID.Item73;
			}
			else
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.UseSound = SoundID.Item72;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse < 2)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					Projectile.NewProjectile(source, position, (velocity + perturbedSpeed)/4, ProjectileID.LostSoulFriendly, damage, knockback, player.whoAmI);
				}
			}
			return true;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Amalgamagun>());
			recipe.AddIngredient(ModContent.ItemType<Infernous>());
			recipe.AddIngredient(ModContent.ItemType<SpectreChaingun>());
			recipe.AddIngredient(ModContent.ItemType<ShadowRailgun>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 3);
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>());
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}