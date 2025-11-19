using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class LargeAmber : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Large Amber");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 300;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 0;
		}

        public override void OnKill(int timeLeft)
		{
			Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<Explosion>(), Projectile.damage, 0, Main.myPlayer);
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 138, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 2f;
			}
			for (int g = 0; g < 8; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);
			}
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}
	}
}