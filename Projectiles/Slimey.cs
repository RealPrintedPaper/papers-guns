using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class Slimey : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 45;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = 3;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position + new Vector2(Main.rand.NextFloat(-1,1), Main.rand.NextFloat(-1, 1)), 3, 3, 33, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity = new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1));
				Main.dust[dustIndex].velocity += Projectile.velocity / 10;
			}
		}
    }
}