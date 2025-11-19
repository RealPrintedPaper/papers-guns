using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class DeathBomb : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 6;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = Main.rand.Next(30,40);
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.WoodenArrowFriendly;
			Projectile.extraUpdates = 0;
			Projectile.alpha = 255;
		}

        public override void AI()
        {
			int dustIndex = Dust.NewDust(Projectile.Center, 0, 0, DustID.Shadowflame, 0f, 0f, 100, default(Color), 2.5f);
			Main.dust[dustIndex].velocity *= 0.2f;
			Main.dust[dustIndex].velocity += Projectile.velocity;
		}

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 3; i++)
            {
				Projectile.NewProjectile(source, Projectile.Center, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-10, 10)), ProjectileID.CrystalPulse2, Projectile.damage / 2, Projectile.knockBack, Projectile.owner, 0f, 0f);
			}

			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, DustID.Shadowflame, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].velocity *= 5f;
				Main.dust[dustIndex].velocity += Projectile.velocity;
				int dustIndex2 = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, DustID.Demonite, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex2].velocity *= 3f;
				Main.dust[dustIndex2].velocity += Projectile.velocity;
				Main.dust[dustIndex2].color = Color.Black;
			}
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
		}
	}
}