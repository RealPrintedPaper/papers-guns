using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class HallowPointBullet : ModProjectile
	{
		private IEntitySource source;

		Vector2 randomposition = new Vector2(Main.rand.NextFloat(-45, 45), Main.rand.NextFloat(-45, 45));
		Vector2 velocity;
		bool isreleased = false;
		int randomdeath;
		float randopi = Main.rand.NextFloat((float)Math.PI);

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = 1;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 99999999;
			Projectile.light = 0f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 0;
			Projectile.aiStyle = 0;

		}
		public override void AI()
		{
			Vector2 targ = Main.MouseWorld;
			Vector2 pos = Projectile.Center;

			float shootToX = targ.X - pos.X;
			float shootToY = targ.Y - pos.Y;
			float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
			distance = 3f / distance;
			shootToX *= distance;
			shootToY *= distance;
			Projectile.velocity.X = shootToX;
			Projectile.velocity.Y = shootToY;

			Projectile.ai[0] += 1f;
			randomdeath = Main.rand.Next(0, 30) + (int)Projectile.ai[0] / 6;


			Projectile.Center = Main.player[Projectile.owner].position + randomposition + new Vector2(Main.player[Projectile.owner].width / 2, Main.player[Projectile.owner].height / 2) + new Vector2(0, (float)Math.Sin(Projectile.ai[0]/60 + randopi)*8);
			Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
			Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
			if (Projectile.spriteDirection == 1)
			{
				DrawOffsetX = -6;
				DrawOriginOffsetX = 4;
				DrawOriginOffsetY = -4;
			}
			else
			{
				DrawOffsetX = 0;
				DrawOriginOffsetX = -4;
				DrawOriginOffsetY = -4;
			}

			if (Projectile.ai[0] < 5)
            {
				int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.TintableDustLighted, 0, 0, 100, Color.Yellow, 1f);
				Main.dust[dust].noGravity = true;
			}

			if (Main.player[Projectile.owner].releaseUseItem)
			{
				if (!isreleased)
                {
					Projectile.timeLeft = randomdeath;
					isreleased = true;
				}
			}
		}

		public override void OnKill(int timeLeft)
		{
			if (Projectile.spriteDirection == 1)
			{
				velocity = new Vector2(15, 0).RotatedBy(Projectile.rotation);
			}
			else
			{
				velocity = new Vector2(-15, 0).RotatedBy(Projectile.rotation);
			}
			int v = Projectile.NewProjectile(source, Projectile.position, velocity, ModContent.ProjectileType<HallowPointBulletShot>(), Projectile.damage, Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
			Main.projectile[v].CritChance = Projectile.CritChance;

			for (int i = 0; i < 5; i++)
            {
				int dust2 = Dust.NewDust(Projectile.position, 1, 1, DustID.TintableDustLighted, 0, 0, 100, Color.Yellow, 1f);
				Main.dust[dust2].noGravity = true;
				if (Projectile.spriteDirection == 1)
				{
					Main.dust[dust2].velocity = new Vector2(5, 0).RotatedBy(Projectile.rotation);
				}
				else
				{
					Main.dust[dust2].velocity = new Vector2(-5, 0).RotatedBy(Projectile.rotation);
				}
				Main.dust[dust2].velocity *= Main.rand.NextFloat(2);
			}

			//if (!Main.rand.NextBool(3))
			{
				SoundEngine.PlaySound(new SoundStyle(Main.rand.Next(new string[] { "PapersGuns/Sounds/flyby1", "PapersGuns/Sounds/flyby2", "PapersGuns/Sounds/flyby3", "PapersGuns/Sounds/flyby4", "PapersGuns/Sounds/flyby5", "PapersGuns/Sounds/flyby6", "PapersGuns/Sounds/flyby7" })) with { Volume = 1f, Pitch = Main.rand.NextFloat(-0.08f, 0.08f) });
			}
		}
	}
}