using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class CrimsonRocket : ModProjectile
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
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 240;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Ichor, 300);
        }

        public override void OnKill(int timeLeft)
		{
			Projectile.NewProjectile(source, Projectile.position, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage, 0, Main.myPlayer);
			for (int i = 0; i < 25; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.Blood, 0f, 0f, 100, default(Color), 4f);
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].velocity *= 3f;
			}
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);

			for (int g = 0; g < 8; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);

			}
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}
	}
}