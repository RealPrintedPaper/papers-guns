using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class TerrariaRocket : ModProjectile
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
			Projectile.light = 0.2f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
		}

        public override void AI()
		{
			Dust.NewDust(Projectile.Center, 5, 5, DustID.TerraBlade, 0f, 0f, 100, default(Color), 0.8f);

			for (int i = 0; i < 200; i++)
			{
				NPC target = Main.npc[i];
				//If the npc is hostile
				if (!target.friendly & target.HasBuff(ModContent.BuffType<Buffs.Terraflamed>()))
				{
					//Get the shoot trajectory from the projectile and target
					float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
					float shootToY = target.position.Y - Projectile.Center.Y;
					float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

					//If the distance between the live targeted npc and the projectile is less than 480 pixels
					if (distance < 480f && !target.friendly && target.active)
					{
						//Divide the factor, 3f, which is the desired velocity
						distance = 3f / distance;

						//Multiply the distance by a multiplier if you wish the projectile to have go faster
						shootToX *= distance * 5;
						shootToY *= distance * 5;

						//Set the velocities to the shoot values
						Projectile.velocity.X = shootToX;
						Projectile.velocity.Y = shootToY;
					}
				}
			}
		}

        public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Terraflamed>(), 60);
			if (Main.rand.NextBool())
			{
				float random = Main.rand.NextFloat(-400, 400);
				Projectile.NewProjectile(source, target.position + new Vector2(random, -1000), new Vector2(-random / 65, 30), ProjectileID.TerraBeam, Projectile.damage * 2, Projectile.knockBack, Projectile.owner, 0, 1);
				SoundEngine.PlaySound(SoundID.Item60, target.position + new Vector2(random, -1000));
			}
		}

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 30; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center - new Vector2(125, 125), 250, 250, DustID.TerraBlade, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 2;
			}
			SoundEngine.PlaySound(SoundID.Item88, Projectile.position);
		}
	}
}