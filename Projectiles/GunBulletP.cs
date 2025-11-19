using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class GunBulletP : ModProjectile
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
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Bullet;
		}
        public override void AI()
        {
			if (Projectile.alpha <= 0)
            {
				Projectile.alpha = 0;
            }
			else
            {
				Projectile.alpha = Projectile.alpha - 25;
            }

			Projectile.velocity.Y = Projectile.velocity.Y + 0.3f;
			Projectile.rotation = Main.rand.Next(360);
			if (Math.Floor(Projectile.timeLeft + 0.5f) % 10 == 0)
            {
				int randX = Main.rand.Next(360);
				int randY = Main.rand.Next(360);
				Projectile.NewProjectile(source, Projectile.Center, new Vector2(randX, randY).RotatedByRandom(MathHelper.ToRadians(360)), ProjectileID.Bullet, 8, 0, Main.myPlayer);
			}
		}

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}