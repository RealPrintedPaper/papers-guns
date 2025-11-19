using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class FireCracklerBomb : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.aiStyle = 68;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			//drawOriginOffsetY = -9;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 300);
		}

		public override void AI()
        {
			int dustIndex = Dust.NewDust(Projectile.position, Projectile.width * 2, Projectile.height * 2, DustID.Torch, 0f, 0f, 100, default(Color), 1f);
			Main.dust[dustIndex].noGravity = true;
			Main.dust[dustIndex].velocity += Projectile.velocity / 3;
		}

        public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < Main.rand.Next(8, 10); i++)
			{
				Projectile.NewProjectile(source, Projectile.Center, new Vector2(5,5).RotatedByRandom(MathHelper.ToRadians(360)), Main.rand.Next(400, 402), Projectile.damage, 0, Main.myPlayer);
			}

			for (int i = 0; i < 20; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.Torch, 0f, 0f, 100, default(Color), 5f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
			}

			for (int g = 0; g < 8; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);
			}
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
		}
	}
}