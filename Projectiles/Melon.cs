using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PapersGuns.Projectiles
{
	public class Melon : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 46;
			Projectile.height = 48;
			Projectile.aiStyle = 16;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 240;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Grenade;

		}

        public override void AI()
		{
			Projectile.localAI[0] += 1f;

			if (Projectile.localAI[0] <= 10f)
            {
				Projectile.scale = Projectile.localAI[0] / 10;
            }
			else
            {
				Projectile.scale = 1;
            }
			if (Projectile.localAI[0] == 60f)
			{
				SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
				Vector2 targ = Main.MouseWorld;
				Vector2 pos = Projectile.Center;

				float shootToX = targ.X - pos.X;
				float shootToY = targ.Y - pos.Y;
				float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
				distance = 3f / distance;
				shootToX *= distance * 20;
				shootToY *= distance * 20;
				Projectile.velocity.X = shootToX;
				Projectile.velocity.Y = shootToY;
				//Main.NewText(MathHelper.ToDegrees(ang));
			}
		}

        public override void OnKill(int timeLeft)
		{
			Projectile.NewProjectile(source, Projectile.Center, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage, 0, Main.myPlayer);
			for (int i = 0; i < 12; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.Plantera_Green, 0f, 0f, 100, default(Color), 4f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 3f;
				int dustIndex2 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Plantera_Pink, 0f, 0f, 100, default(Color), 4f);
				Main.dust[dustIndex2].noGravity = true;
				Main.dust[dustIndex2].velocity *= 3f;
			}
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);

			for (int g = 0; g < 8; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);
			}
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}
	}
}