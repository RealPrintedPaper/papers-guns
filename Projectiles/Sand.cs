using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class Sand : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 40;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 4;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			for (int i = 0; i < 3; i++)
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, 0, 0, 100);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1f;
				int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, 0, 0);
				Main.dust[dust2].scale = 1f;
				Main.dust[dust2].fadeIn = 1;
				Main.dust[dust2].velocity.X *= 0.4f;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Confused, 150);
		}
	}
}