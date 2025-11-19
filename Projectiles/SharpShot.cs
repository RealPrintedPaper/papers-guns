using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class SharpShot : ModProjectile
	{
		public override string Texture => "PapersGuns/Projectiles/DestroyerShot";
		private readonly IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 300;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 100;
			Projectile.penetrate = 10;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			AIType = ProjectileID.BulletHighVelocity;
			Projectile.alpha = 255;
		}

		void Explode()
        {
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(50, 50), 100, 100, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 10f;
			}

			for (int i = 0; i < 35; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(50, 50), 100, 100, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 10f;
				int dustIndex2 = Dust.NewDust(Projectile.position - new Vector2(50, 50), 100, 100, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex2].velocity *= 9f;
			}
			for (int g = 0; g < 15; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 2f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-8, 8);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-8, 8);
			}
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
			Projectile.NewProjectile(source, Projectile.Center, Vector2.Zero, ModContent.ProjectileType<LargeExplosion>(), Projectile.damage, Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
		}
		
        public override void AI()
		{
			Projectile.ai[1] += 1f;
			if (Projectile.alpha <= 0)
			{
				Projectile.alpha = 0;
			}
			else
			{
				Projectile.alpha = Projectile.alpha - 10;
			}

			if (Projectile.ai[1] > 25)
			{
				for (int i = 0; i < 2; i++)
				{
					Dust.NewDust(Projectile.position - new Vector2(5, 5), 10, 10, 31, 0f, 0f, 100, default(Color), 2f);
				}
			}

			if (Projectile.ai[1] > 20 && Projectile.ai[1] < 30)
			{
				for (int j = 0; j < 7; j++)
				{
					int dusty = Dust.NewDust(Projectile.position - new Vector2(5, 5), 10, 10, 31, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dusty].noGravity = true;
					Main.dust[dusty].velocity *= 10;
					Main.dust[dusty].velocity += Projectile.velocity * 2;
					int dusty2 = Dust.NewDust(Projectile.position - new Vector2(50, 50), 100, 100, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dusty2].velocity *= 10f;
					Main.dust[dusty2].velocity += Projectile.velocity * 2;
				}
			}
		}

        public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Explode();
			Projectile.damage = (int)Math.Floor(Projectile.damage / 1.15f);
			if (Projectile.damage <= 1)
            {
				Projectile.Kill();
            }
			for (int i = 0; i < 40; i++)
            {
				int dustIndex = Dust.NewDust(Projectile.position, 0, 0, 6, 0f, 0f, 100, default(Color), 3.5f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 20;
				Main.dust[dustIndex].velocity += Projectile.velocity * 5;
			}
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Explode();
			return true;
        }
    }
}