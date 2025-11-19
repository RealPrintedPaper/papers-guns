using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class NormalRay : ModProjectile
	{
        private IEntitySource source;

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
            Projectile.MaxUpdates = 5;
            Projectile.penetrate = 5;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 4f)
            {
                for (int num562 = 0; num562 < 5; num562++)
                {
                    Projectile.alpha = 255;
                    int num563 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y - Projectile.height / 4), Projectile.width, Projectile.height, DustID.JungleTorch, 0f, 0f, 0, default(Color), 2f);
                    Main.dust[num563].scale = (float)Main.rand.Next(110, 140) * 0.015f;
                    Main.dust[num563].velocity *= 1f;
                    Main.dust[num563].noGravity = true;

                }
            }

            if (Projectile.localAI[0] == 4)
            {
                for (int h = 0; h < 180; h++)
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleTorch, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity = new Vector2((float)Math.Cos(h * 2), (float)Math.Sin(h * 2));
                    Main.dust[dust].velocity *= 6f;
                }
            }

            if (Projectile.localAI[0] % 5 == 0)
            {
                for (int i = 0; i < 180; i++)
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleTorch, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity = new Vector2((float)Math.Cos(i * 2), (float)Math.Sin(i * 2));
                    Main.dust[dust].velocity *= 4f;
                }
            }

            if (Main.rand.NextBool(120))
            {
                SoundEngine.PlaySound(new SoundStyle(Main.rand.Next(new string[] { "PapersGuns/Sounds/raygunflyby1", "PapersGuns/Sounds/raygunflyby2" })), Projectile.position);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.RoomTemped>(), 120);
        }

        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<Explosion>(), Projectile.damage, 0, Main.myPlayer);
            for (int j = 0; j < 360; j++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleTorch, 0f, 0f, 0, default(Color), 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity = new Vector2((float)Math.Cos(j), (float)Math.Sin(j));
                Main.dust[dust].velocity *= 8f;
            }

            for (int k = 0; k < 15; k++)
            {
                int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleTorch, 0f, 0f, 0, default(Color), 6f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = new Vector2(Main.rand.NextFloat(-1,1), Main.rand.NextFloat(-1, 1));
                Main.dust[dust2].velocity *= 5f;
            }
        }
    }
}