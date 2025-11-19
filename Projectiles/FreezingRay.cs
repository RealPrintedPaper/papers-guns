using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace PapersGuns.Projectiles
{
	public class FreezingRay : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.MaxUpdates = 100;
        }

        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                for (int num562 = 0; num562 < 5; num562++)
                {
                    Projectile.alpha = 255;
                    int num563 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y - Projectile.height / 4), Projectile.width, Projectile.height, DustID.Frost, 0f, 0f, 0, default(Color), 2f);
                    Main.dust[num563].scale = (float)Main.rand.Next(110, 140) * 0.008f;
                    Main.dust[num563].velocity *= 0.5f;
                    Main.dust[num563].noGravity = true;

                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 300);
        }
    }
}