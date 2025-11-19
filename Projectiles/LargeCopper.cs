using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class LargeCopper : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Large Copper Coin");
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
			Projectile.timeLeft = 60;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < Main.rand.NextFloat(15, 25); i++)
			{
				Projectile.NewProjectile(source, Projectile.Center, new Vector2(5, 5).RotatedByRandom(MathHelper.ToRadians(360)), ProjectileID.CopperCoin, Projectile.damage / 20, Projectile.knockBack, Projectile.owner, 0f, 0f);
			}

			for (int num625 = 0; num625 < 3; num625++)
			{
				float scaleFactor10 = 0.33f;
				if (num625 == 1)
					scaleFactor10 = 0.66f;
				else if (num625 == 2)
					scaleFactor10 = 1f;

				int num626 = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore gore1 = Main.gore[num626];
				gore1.velocity.X = gore1.velocity.X + 1f;
				Gore gore2 = Main.gore[num626];
				gore2.velocity.Y = gore2.velocity.Y + 1f;
				num626 = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore gore3 = Main.gore[num626];
				gore3.velocity.X = gore3.velocity.X - 1f;
				Gore gore4 = Main.gore[num626];
				gore4.velocity.Y = gore4.velocity.Y + 1f;
				num626 = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore gore5 = Main.gore[num626];
				gore5.velocity.X = gore5.velocity.X + 1f;
				Gore gore6 = Main.gore[num626];
				gore6.velocity.Y = gore6.velocity.Y - 1f;
				num626 = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Gore gore7 = Main.gore[num626];
				gore7.velocity.X = gore7.velocity.X - 1f;
				Gore gore8 = Main.gore[num626];
				gore8.velocity.Y = gore8.velocity.Y - 1f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}
	}
}