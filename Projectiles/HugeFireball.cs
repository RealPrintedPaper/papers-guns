using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class HugeFireball : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Huge Fireball");
		}

		public override void SetDefaults()
		{
			Projectile.width = 300;
			Projectile.height = 300;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 2400;
			Projectile.light = 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			if (Projectile.timeLeft > 255)
            {
				if (Projectile.alpha > 0)
				{
					Projectile.alpha -= 5;
				}
            }
			else
            {
				if (Projectile.alpha < 255)
				{
					Projectile.alpha += 1;
				}
            }
			Projectile.rotation = Main.rand.Next(360);
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width - 20, Projectile.height - 20, DustID.Firework_Yellow);
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
		}

        public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 2400);
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
		}
	}
}