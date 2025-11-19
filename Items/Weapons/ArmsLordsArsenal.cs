using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;

namespace PapersGuns.Items.Weapons
{
	public class ArmsLordsArsenal : ModItem
	{
		public override string Texture => "PapersGuns/Projectiles/Arsenal/Textures/GoldenAA12";
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Arms Lord's Arsenal");
			// Tooltip.SetDefault("Shoots hallow point bullets\nConsumes no ammo\nRight click to throw your weapons, which shoot by themselves after a brief time\n'Don't know what weapon to use against someone? Use ALL OF THEM!'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0;
			Item.damage = 1400;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item39;
			Item.noMelee = true;
			Item.knockBack = 50;
			Item.value = Item.sellPrice(platinum: 10);
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.None;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse < 2)
			{
				Projectile.NewProjectile(source, player.position, new Vector2(0, 0), Main.rand.Next(new int[] { ModContent.ProjectileType<Projectiles.Arsenal.Usas12P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Glock17P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.M60P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Type63P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.PancorJackhammerP>(),
				ModContent.ProjectileType<Projectiles.Arsenal.AK47P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.WinchesterModel1912P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.MP40P>(),
				ModContent.ProjectileType<Projectiles.Arsenal.AACHoneyBadgerP>(),
				ModContent.ProjectileType<Projectiles.Arsenal.AA12P>()
			}), damage, knockback, player.whoAmI);
				//Projectile.NewProjectile(source, player.position, new Vector2(0, 0), ModContent.ProjectileType<Projectiles.Arsenal.AA12P>(), damage, knockback, player.whoAmI);
				SoundEngine.PlaySound(new SoundStyle(Main.rand.Next(new string[] { "PapersGuns/Sounds/wepswitch1", "PapersGuns/Sounds/wepswitch2", "PapersGuns/Sounds/wepswitch3", "PapersGuns/Sounds/wepswitch4" })) with { Volume = 1f, Pitch = Main.rand.NextFloat(-0.08f, 0.08f) });
			}
			else
            {
				for (int i = 0; i < 2; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(35));
					float scale = 1f - (Main.rand.NextFloat() * .2f);
					velocity = velocity * scale;
					int v = Projectile.NewProjectile(source, position, velocity + perturbedSpeed, Main.rand.Next(new int[] { ModContent.ProjectileType<Projectiles.Arsenal.Throwables.Usas12Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.Glock17Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.M60Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.Type63Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.PancorJackhammerThrowable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.AK47Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.WinchesterModel1912Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.MP40Throwable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.AACHoneyBadgerThrowable>(),
				ModContent.ProjectileType<Projectiles.Arsenal.Throwables.AA12Throwable>()
			}), damage, knockback, player.whoAmI);
					Main.projectile[v].damage *= 5;
				}
			}
			return false;
        }
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse != 2)
			{
				//int randusetime = Main.rand.Next(10, 30);
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.useStyle = ItemUseStyleID.Shoot;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Swing;
				Item.useTime = 1;
				Item.useAnimation = 1;
				Item.autoReuse = true;
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ArmsLordsArsenal>());
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 15);
			recipe.AddIngredient(ModContent.ItemType<AACHoneyBadger>());
			recipe.AddIngredient(ModContent.ItemType<DualAA12>());
			recipe.AddIngredient(ModContent.ItemType<AK47>());
			recipe.AddIngredient(ModContent.ItemType<Glock17>());
			recipe.AddIngredient(ModContent.ItemType<M60>());
			recipe.AddIngredient(ModContent.ItemType<MP40>());
			recipe.AddIngredient(ModContent.ItemType<PancorJackhammer>());
			recipe.AddIngredient(ModContent.ItemType<Type63>());
			recipe.AddIngredient(ModContent.ItemType<Usas12>());
			recipe.AddIngredient(ModContent.ItemType<WinchesterModel1912>());
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}