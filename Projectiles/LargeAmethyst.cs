using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Projectiles
{
	public class LargeAmethyst : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Large Amethyst");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 300;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.penetrate = 5;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(ModContent.BuffType<Buffs.AmethystWrath>(), 300);
		}

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 86, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 2f;
			}
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}
}