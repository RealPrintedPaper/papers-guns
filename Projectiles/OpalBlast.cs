using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class OpalBlast : ModProjectile
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
			Projectile.timeLeft = 50;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = -1;
			AIType = ProjectileID.Bullet;
		}

        public override void AI()
		{
			for (int i = 0; i < 3; i++)
			{
				int dust = Dust.NewDust(Projectile.position, 20, 20, Main.rand.Next(new int[] { DustID.BlueTorch, DustID.BoneTorch, DustID.PinkTorch}));
				Main.dust[dust].noGravity = true;
			}
		}

        public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(Projectile.position, 20, 20, Main.rand.Next(new int[] { DustID.BlueTorch, DustID.BoneTorch, DustID.PinkTorch }), Main.rand.Next(-10,10), Main.rand.Next(-10, 10), 0, default(Color), 2f);
				Main.dust[dust].noGravity = true;
			}
			for (int i = 0;i < 10;i++)
            {
				Vector2 vel = new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-10, 10));
				Projectile.NewProjectile(source, Projectile.Center, vel, ProjectileID.CrystalShard, Projectile.damage / 2, Projectile.knockBack, Projectile.owner, 0f, 0f);
			}
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
		}
	}
}