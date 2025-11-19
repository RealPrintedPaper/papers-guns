using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class Bloodshot : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 50;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = 4;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			if (Projectile.timeLeft < 43)
			{
				for (int i = 0; i < 3; i++)
				{
					int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, 0, 0, 100);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 2.5f;
					int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, 0, 0);
					Main.dust[dust2].scale = 1f;
					Main.dust[dust2].fadeIn = 1;
					Main.dust[dust2].velocity.X *= 0.4f;
				}
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Confused, 60);
			target.AddBuff(BuffID.OnFire, 60);
		}
	}
}