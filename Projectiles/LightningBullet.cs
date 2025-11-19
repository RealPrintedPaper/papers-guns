using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace PapersGuns.Projectiles
{
	public class LightningBullet : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.MaxUpdates = 50;
        }

        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                Projectile.alpha = 255;

                for (int i = 0; i < 5; i++)
                {
                    int num563 = Dust.NewDust(Projectile.position + new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3)), 0, 0, DustID.Ichor, 0f, 0f, 0, default(Color), 0.5f);
                    Main.dust[num563].velocity = new Vector2(Main.rand.NextFloat(-.1f, .1f), Main.rand.NextFloat(-.1f, .1f));
                    Main.dust[num563].noGravity = true;
                }
            }
        }
    }
}