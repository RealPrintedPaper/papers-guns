using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class DeathRocket : ModProjectile
	{
		private bool postplant = false;
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
			Projectile.aiStyle = 34;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 30;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.RocketI;
			Projectile.extraUpdates = 0;
			if (Main.LocalPlayer.HeldItem.type == ModContent.ItemType<Items.Weapons.TrueDeathValley>())
			{
				postplant = true;
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.ShadowFlame, 300);

			if (postplant)
            {
				target.AddBuff(BuffID.Ichor, 300);
				target.AddBuff(BuffID.CursedInferno, 300);
			}
        }

        public override void OnKill(int timeLeft)
		{
			int numbullet = Main.rand.Next(3, 5);
			if (postplant)
            {
				numbullet = Main.rand.Next(5, 8);
            }
			for (int i = 0; i < numbullet; i++)
            {
				Projectile.NewProjectile(source, Projectile.Center, Projectile.oldVelocity + new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-10, 10)), ModContent.ProjectileType<DeathBomb>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner, 0f, 0f);
			}

			for (int i = 0; i < 30; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.Shadowflame, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1,3));
				Main.dust[dustIndex].velocity *= 2.5f;
				int dustIndex2 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Shadowflame, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex2].velocity *= 3f;
				Main.dust[dustIndex2].velocity += Projectile.oldVelocity;
				int dustIndex4 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Demonite, 0f, 0f, 100, Color.Black, 1f);
				Main.dust[dustIndex4].velocity *= 2f;
				int dustIndex5 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Demonite, 0f, 0f, 100, Color.Black, 2f);
				Main.dust[dustIndex5].velocity *= 2.2f;
				Main.dust[dustIndex5].noGravity = false;
			}
			SoundEngine.PlaySound(SoundID.Item60, Projectile.position);
		}
	}
}