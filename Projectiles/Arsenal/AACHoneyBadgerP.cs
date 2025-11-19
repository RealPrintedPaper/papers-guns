using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles.Arsenal
{
	public class AACHoneyBadgerP : ModProjectile
	{
		public override string Texture => "PapersGuns/Projectiles/Arsenal/Textures/GoldenAACHoneyBadger";
		private IEntitySource source;
		bool spawnin = true;
		Vector2 velocity;

		Vector2 randomposition = new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));

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
			Projectile.timeLeft = 60;
			Projectile.light = 0f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 0;
			Projectile.aiStyle = 0;
			DrawOffsetX = -44;
			DrawOriginOffsetY = -8;
			DrawOriginOffsetX = 0;
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

			if (spawnin == true)
			{
				CombatText.NewText(Main.player[Projectile.owner].getRect(), Color.Red, "AAC HONEY BADGER!", false, false);
				spawnin = false;
			}
			Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
			Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);

			Projectile.Center = Main.player[Projectile.owner].position + randomposition + new Vector2(Main.player[Projectile.owner].width / 2, Main.player[Projectile.owner].height / 2);

			Projectile.ai[0] += 1f;

			if (Projectile.ai[0] % 5f == 1f)
			{
				SoundEngine.PlaySound(SoundID.Item40, Main.player[Projectile.owner].position);

				if (Projectile.spriteDirection == 1)
				{
					velocity = new Vector2(15, 0).RotatedBy(Projectile.rotation);
				}
				else
				{
					velocity = new Vector2(-15, 0).RotatedBy(Projectile.rotation);
				}

				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(3));
				int v = Projectile.NewProjectile(source, Projectile.position, velocity + perturbedSpeed, ModContent.ProjectileType<HallowPointBulletShot>(), Projectile.damage, Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
				Main.projectile[v].CritChance = Projectile.CritChance;
			}

			if (Main.player[Projectile.owner].releaseUseItem)
			{
				Projectile.Kill();
			}
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
			Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-5, -2)), ModContent.GoreType<Gores.AACHoneyBadgerGore>(), 1f);
		}
	}
}