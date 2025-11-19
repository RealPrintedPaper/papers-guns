using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class SmallTerrariaBeam : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 300;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
			DrawOriginOffsetY = -11;
			DrawOffsetX = -4;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

        public override void AI()
        {
			Dust.NewDust(Projectile.Center, 5, 5, DustID.TerraBlade, 0f, 0f, 100, default(Color), 1f);

			//the code below was borrowed from Sin Costan
			//https://forums.terraria.org/index.php?threads/tutorial-projectile-guide-and-implementation-tmodloader-edition.40062/

			for (int i = 0; i < 200; i++)
			{
				//Enemy NPC variable being set
				NPC target = Main.npc[i];

				//Getting the shooting trajectory
				float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
				float shootToY = target.position.Y - Projectile.Center.Y + target.height/2;
				float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

				//If the distance between the projectile and the live target is active
				if (distance < 480f && !target.friendly && target.active)
				{
					if (Projectile.ai[1] > 4f) //Assuming you are already incrementing this in AI outside of for loop
					{
						//Dividing the factor of 3f which is the desired velocity by distance
						distance = 3f / distance;

						//Multiplying the shoot trajectory with distance times a multiplier if you so choose to
						shootToX *= distance * 5;
						shootToY *= distance * 5;

						//Shoot projectile and set ai back to 0
						Projectile.NewProjectile(source, Projectile.Center, new Vector2(shootToX, shootToY), ModContent.ProjectileType<TerrariaRocket>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
						Projectile.ai[1] = 0f;
					}
				}
			}
			Projectile.ai[1] += 1f;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(ModContent.BuffType<Buffs.Terraflamed>(), 60);
        }

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 35; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.TerraBlade, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1,3));
				Main.dust[dustIndex].velocity *= 2.5f;
			}
			SoundEngine.PlaySound(SoundID.Item60, Projectile.position);
		}
	}
}