using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PapersGuns.Projectiles
{
	public class ChlorectreBullet : ModProjectile
	{
		public override string Texture => "PapersGuns/Projectiles/SpectreBullet";
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.ChlorophyteBullet;
			Projectile.alpha = 255;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

        public override void AI()
		{
			int dustIndex = Dust.NewDust(Projectile.position + new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1)) - new Vector2(Projectile.width, Projectile.height), 3, 3, DustID.UltraBrightTorch, 0f, 0f, 100, default(Color), 0.7f);
			if (Main.rand.NextBool())
			{
				Main.dust[dustIndex].noGravity = true;
			}
            else
            {
				Main.dust[dustIndex].noGravity = false;
			}
		}

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}