using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class TitaniumShard : ModProjectile
	{
		public override string Texture => "PapersGuns/Projectiles/Point";

		public override void SetDefaults()
		{
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = Main.rand.Next(45,60);
			Projectile.light = 0.2f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
			Projectile.alpha = 255;
		}

        public override void AI()
        {
			Projectile.velocity.X *= 0.95f;
			Projectile.velocity.Y *= 0.95f;

			int dustIndex1 = Dust.NewDust(Projectile.position, 1, 1, DustID.GemDiamond, 0f, 0f, 100, default(Color), 0.5f);
			Main.dust[dustIndex1].noGravity = true;
			Main.dust[dustIndex1].velocity *= 0.5f;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position, 2, 2, DustID.GemDiamond, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].noGravity = true;
			}
		}
	}
}