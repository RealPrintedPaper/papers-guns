using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles.Arsenal.Throwables
{
	public class Usas12Throwable : ModProjectile
	{
		public override string Texture => "PapersGuns/Projectiles/Arsenal/Textures/GoldenUsas12";
        private IEntitySource source;
		Vector2 velocity;

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
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Bullet;
			DrawOffsetX = -40;
			DrawOriginOffsetY = -10;
			DrawOriginOffsetX = 0;
		}
        public override void AI()
        {
			if (Projectile.alpha <= 0)
            {
				Projectile.alpha = 0;
            }
			else
            {
				Projectile.alpha = Projectile.alpha - 25;
            }

			Projectile.velocity.Y = Projectile.velocity.Y + 0.3f;

			Projectile.rotation = Projectile.position.X / 50;

			if (Projectile.timeLeft < 560)
			{
				if (Math.Floor(Projectile.timeLeft + 0.5f) % 24 == 0)
				{
					SoundEngine.PlaySound(SoundID.Item38, Projectile.position); 
					for (int i = 0; i < 5; i++)
					{
						velocity = new Vector2(15, 0).RotatedBy(Projectile.rotation);
						Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
						float scale = 1f - (Main.rand.NextFloat() * .5f);
						velocity = velocity * scale;
						int v = Projectile.NewProjectile(source, Projectile.position, velocity + perturbedSpeed, ModContent.ProjectileType<HallowPointBulletShot>(), Projectile.damage, Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
						Main.projectile[v].CritChance = Projectile.CritChance;
					}
					Projectile.velocity += new Vector2(-10, 0).RotatedBy(Projectile.rotation);
				}
			}
		}

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}