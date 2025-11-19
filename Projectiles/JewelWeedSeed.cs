using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class JewelWeedSeed : ModProjectile
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
			Projectile.aiStyle = 16;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 26;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			DrawOriginOffsetY = -4;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Poisoned, 300);
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < Main.rand.Next(1, 4); i++)
			{
				Projectile.NewProjectile(source, Projectile.Center, new Vector2(Projectile.oldVelocity.X + Main.rand.Next(-3,3), Projectile.oldVelocity.Y + Main.rand.Next(-3, 3)), ProjectileID.SeedlerNut, Projectile.damage, 0, Main.myPlayer);
			}
			for (int i = 0; i < 6; i++)
			{
				Dust.NewDust(Projectile.Center, 2, 2, DustID.JungleSpore, 0f, 0f, 100, default(Color), 1f);
				Dust.NewDust(Projectile.Center, 2, 2, DustID.Poisoned, 0f, 0f, 100, default(Color), 1f);
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.JungleGrass, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 3f;
			}

			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
		}
	}
}