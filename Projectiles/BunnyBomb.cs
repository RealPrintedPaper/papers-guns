using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PapersGuns.Projectiles
{
	public class BunnyBomb : ModProjectile
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
			Projectile.aiStyle = 68;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			DrawOriginOffsetY = -18;
		}

		public override void OnKill(int timeLeft)
		{
			if (Main.rand.NextBool(3))
			{
				for (int i = 0; i < 2; i++)
				{
					Projectile.NewProjectile(source, Projectile.Center + new Vector2(0,-10), new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-10,-5)), ModContent.ProjectileType<BunnyBomb>(), Projectile.damage, 0, Main.myPlayer);
				}
			}

			Projectile.NewProjectile(source, Projectile.Center, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage, 0, Main.myPlayer);
			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.Blood, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 2f;
			}
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);

			for (int g = 0; g < 8; g++)
			{
				//int goreIndex = Gore.NewGore(new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);
			}
			Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-2, 2)), 76, 1f);
			Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-2, 2)), 77, 1f);
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}
	}
}