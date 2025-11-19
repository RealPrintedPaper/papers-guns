using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class MidasBullet : ModProjectile
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
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Bullet;
			DrawOriginOffsetY = -5;
			DrawOffsetX = -4;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.position, 0, 0, DustID.GoldCoin, 0f, 0f, 70, default(Color), 0.7f);
			Main.dust[dust].velocity *= 0.3f;
			Main.dust[dust].position.Y += Main.rand.NextFloat(-1,1)*10;
			Main.dust[dust].position.X += Main.rand.NextFloat(-1,1)*10;
			Main.dust[dust].fadeIn = 0.1f;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (target.type == NPCID.TargetDummy || target.boss)
			{
				return;
			}
            else
            {
				Item.NewItem(source, (int)target.position.X, (int)target.position.Y, target.width, target.height, ItemID.GoldBar, target.lifeMax / 20);
				target.life = 0;
			}
        }

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}