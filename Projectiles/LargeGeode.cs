using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class LargeGeode : ModProjectile
	{
		private float rot = 0f;
		private float ang = Main.rand.NextFloat(-0.5f,0.5f);
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Large Geode");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 50;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.Bullet;
			DrawOriginOffsetY = -16;
			Projectile.extraUpdates = 0;
		}

        public override void AI()
        {
			rot += ang;
			Projectile.rotation = rot;
        }

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 87, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 2f;
				int dustIndex2 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 86, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex2].noGravity = true;
				Main.dust[dustIndex2].velocity *= 2f;
				int dustIndex3 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 88, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex3].noGravity = true;
				Main.dust[dustIndex3].velocity *= 2f;
				int dustIndex4 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 89, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex4].noGravity = true;
				Main.dust[dustIndex4].velocity *= 2f;
				int dustIndex5 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 90, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex5].noGravity = true;
				Main.dust[dustIndex5].velocity *= 2f;
				int dustIndex6 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 91, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex6].noGravity = true;
				Main.dust[dustIndex6].velocity *= 2f;
				int dustIndex7 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 138, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex7].noGravity = true;
				Main.dust[dustIndex7].velocity *= 2f;
			}
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

			for (int i = 0; i < Main.rand.NextFloat(8, 12); i++)
			{
				int randX = Main.rand.Next(360);
				int randY = Main.rand.Next(360);
				Projectile.NewProjectile(source, Projectile.Center, new Vector2(randX, randY).RotatedByRandom(MathHelper.ToRadians(360)), Main.rand.Next(new int[] { ModContent.ProjectileType<Projectiles.LargeAmethyst>(), ModContent.ProjectileType<Projectiles.LargeAmber>(), ModContent.ProjectileType<Projectiles.LargeDiamond>(), ModContent.ProjectileType<Projectiles.LargeEmerald>(), ModContent.ProjectileType<Projectiles.LargeRuby>(), ModContent.ProjectileType<Projectiles.LargeSapphire>(), ModContent.ProjectileType<Projectiles.LargeTopaz>() }), Projectile.damage, Projectile.knockBack, Main.myPlayer);
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}
}