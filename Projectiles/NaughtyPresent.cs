using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
    public class NaughtyPresent : ModProjectile
    {
        private IEntitySource source;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 300;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            AIType = ProjectileID.Bullet;
            Projectile.extraUpdates = 1;
            DrawOriginOffsetY = -25;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(Projectile.position + new Vector2(25, 25), 2, 2, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 2f;
                int dustIndex2 = Dust.NewDust(Projectile.position + new Vector2(25, 25), 2, 2, DustID.Torch, 0f, 0f, 100, default(Color), 4f);
                Main.dust[dustIndex2].noGravity = true;
                Main.dust[dustIndex2].velocity *= 25f;
                Main.dust[dustIndex2].fadeIn = 2f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            for (int i = 0; i < Main.rand.NextFloat(15, 35); i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-15, 15), Main.rand.NextFloat(-15, 15));
                Projectile.NewProjectile(source, Projectile.Center, vel, Main.rand.Next(new int[] { ProjectileID.MolotovFire, ProjectileID.MolotovFire2, ProjectileID.MolotovFire3 }), Projectile.damage / 3, Projectile.knockBack, Projectile.owner, 0f, 0f);
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}