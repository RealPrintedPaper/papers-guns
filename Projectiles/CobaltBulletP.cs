using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using Terraria.Audio;

namespace PapersGuns.Projectiles
{
	public class CobaltBulletP : ModProjectile
	{
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
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Bullet;
		}

        public override void AI()
		{
			Projectile.localAI[0] += 1f;
			/*if (Projectile.localAI[0] <= 60f)
			{
				Projectile.velocity *= 1.015f;
			}*/

			if (Projectile.localAI[0] % 10 == 0)
            {
				Projectile.extraUpdates++;
            }
			
			if (Projectile.localAI[0] % 5 == 0)
            {
				Projectile.damage++;
            }
		}

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}