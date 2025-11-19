using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class Fireball : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 16;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			if (Projectile.timeLeft > 51)
            {
				if (Projectile.alpha > 0)
				{
					Projectile.alpha -= 10;
				}
            }
			else
            {
				if (Projectile.alpha < 255)
				{
					Projectile.alpha += 5;
				}
            }
			Projectile.rotation = Main.rand.Next(360);
			for (int i = 0; i < 3; i++)
            {
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Main.rand.Next(new int[] { DustID.Firework_Yellow, DustID.SolarFlare, DustID.Torch}));
				Main.dust[dust].noGravity = true;
			}
		}

        public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 180);
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
		}
	}
}