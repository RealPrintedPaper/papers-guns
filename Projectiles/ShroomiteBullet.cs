using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class ShroomiteBullet : ModProjectile
	{
        private IEntitySource source;
        private float rando;

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
			Projectile.timeLeft = 300;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Bullet;
			Projectile.penetrate = 2;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			AIType = ProjectileID.Bullet;
		}

        public override void AI()
		{
			Projectile.localAI[0] += 1f;

			if (Projectile.localAI[0] % 10 == 0)
            {
				rando = Main.rand.NextFloat(-3,3);
            }

			if (Projectile.localAI[0] >= 10)
            {
				Projectile.velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(rando));
            }

			if (Main.rand.NextBool(10))
			{
				Projectile.NewProjectile(source, Projectile.position + new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), new Vector2(0, 0), ProjectileID.Mushroom, Projectile.damage, Projectile.knockBack, Main.myPlayer);
			}
			if (Main.rand.NextBool(300))
			{
				int newproj = Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, ModContent.ProjectileType<ShroomiteBullet>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
				Main.projectile[newproj].timeLeft = 150;
			}
			int num563 = Dust.NewDust(Projectile.position, 0, 0, DustID.BlueTorch, 0f, 0f, 0, default(Color), 1f);
			Main.dust[num563].velocity = new Vector2(0, 0);
			Main.dust[num563].noGravity = true;
		}

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}