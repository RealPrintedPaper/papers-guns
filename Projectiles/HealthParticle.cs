using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class HealthParticle : ModProjectile
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
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			int dust = Dust.NewDust(Projectile.position + new Vector2(1, 1), 2, 2, DustID.TerraBlade, 0f, 0f, 100, default(Color), 0.7f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 2f;
		}
	}
}