using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class Terraflame : ModProjectile
	{
        private IEntitySource source;

        public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 50;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = 10;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			if (Projectile.timeLeft < 45)
			{
				for (int i = 0; i < 3; i++)
				{
					int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RuneWizard, 0, 0, 100);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 2.5f;
					int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RuneWizard, 0, 0);
					Main.dust[dust2].scale = 1f;
					Main.dust[dust2].fadeIn = 1;
					Main.dust[dust2].velocity.X *= 0.4f;
				}
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.damage += 4;
			target.AddBuff(ModContent.BuffType<Buffs.Terraflamed>(), 240);
			if (Main.rand.NextBool(3))
			{
				float random = Main.rand.NextFloat(-400, 400);
				Projectile.NewProjectile(source, target.position + new Vector2(random, -1000), new Vector2(-random / 34, 30), ModContent.ProjectileType<Terraflame>(), 90, Projectile.knockBack, Projectile.owner, 0, 1);
				SoundEngine.PlaySound(SoundID.Item60, target.position + new Vector2(random, -1000));
			}
		}
	}
}