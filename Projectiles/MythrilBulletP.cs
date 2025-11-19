using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class MythrilBulletP : ModProjectile
	{
        private IEntitySource source;

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
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
			Projectile.alpha = 255;
		}

        public override void AI()
        {
			if (Projectile.alpha >= 0 && Projectile.alpha <= 255)
            {
				Projectile.alpha -= 15;
            }

			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] == 20f & Projectile.ai[0] == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					Projectile.NewProjectile(source, Projectile.position, Projectile.velocity + new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5)), ModContent.ProjectileType<MythrilBulletP>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner, 1, 1);
				}
			}
		}

		public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}