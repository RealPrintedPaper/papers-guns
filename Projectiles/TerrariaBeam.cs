using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class TerrariaBeam : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
			DrawOriginOffsetY = -14;
			DrawOffsetX = -9;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

        public override void AI()
        {
			Dust.NewDust(Projectile.Center, 10, 10, DustID.TerraBlade, 0f, 0f, 100, default(Color), 1f);
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(ModContent.BuffType<Buffs.Terraflamed>(), 60);
        }

        public override void OnKill(int timeLeft)
		{
			Projectile.NewProjectile(source, Projectile.Center, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
			for (int i = 0; i < 2; i++)
			{
				int num = Main.rand.Next(360);
				Projectile.NewProjectile(source, Projectile.Center, new Vector2((float)Math.Cos(num) * 15, (float)Math.Sin(num) * 15), ModContent.ProjectileType<SmallTerrariaBeam>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
			}

			for (int i = 0; i < 30; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.TerraBlade, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1,3));
				Main.dust[dustIndex].velocity *= 2.5f;
				int dustIndex2 = Dust.NewDust(Projectile.Center, 2, 2, DustID.TerraBlade, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex2].velocity *= 3f;
				Main.dust[dustIndex2].velocity += Projectile.oldVelocity;
				int dustIndex4 = Dust.NewDust(Projectile.Center, 2, 2, DustID.RuneWizard, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex4].velocity *= 2f;
				int dustIndex5 = Dust.NewDust(Projectile.Center, 2, 2, DustID.RuneWizard, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex5].velocity *= 2.2f;
				Main.dust[dustIndex5].noGravity = false;
			}
			SoundEngine.PlaySound(SoundID.Item60, Projectile.position);
		}
	}
}