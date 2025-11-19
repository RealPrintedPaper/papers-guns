using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class TerraRocket : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        private int numbounce = 10;
        private int vel = 20;
        private IEntitySource source;

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
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                for (int num562 = 0; num562 < 5; num562++)
                {
                    Projectile.alpha = 255;
                    int num563 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y - Projectile.height / 4), Projectile.width, Projectile.height, DustID.RuneWizard, 0f, 0f, 0, default(Color), 4f);
                    Main.dust[num563].scale = (float)Main.rand.Next(110, 140) * 0.013f;
                    Main.dust[num563].velocity *= 0.5f;
                    Main.dust[num563].noGravity = true;

                }
            }
        }

        public void Explode()
        {
            Projectile.damage = (int)Math.Floor(Projectile.damage / 1.5f);
            vel -= 2;

            if (vel <= 1)
            {
                vel = 1;
            }
            Projectile.NewProjectile(source, Projectile.Center, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage, 0, Main.myPlayer);
            for (int i = 0; i < 40; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RuneWizard, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust].velocity *= 3f;
                Main.dust[dust].noGravity = Main.rand.NextBool();
                int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 0, default(Color), 2f);
                Main.dust[dust2].velocity *= 8f;
                Main.dust[dust2].noGravity = true;
            }

            for (int j = 0; j < 360; j++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RuneWizard, 0f, 0f, 0, default(Color), 0.7f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity = new Vector2((float)Math.Cos(j), (float)Math.Sin(j));
                Main.dust[dust].velocity *= vel;
            }

            SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.damage = (int)Math.Floor(Projectile.damage * 1.2f);
            numbounce = numbounce - 1;
            if (numbounce <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }

            Explode();

            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Explode();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Terraflamed>(), 300);
            if (Projectile.damage <= 5)
            {
                Projectile.Kill();
            }
            Explode();
        }
    }
}