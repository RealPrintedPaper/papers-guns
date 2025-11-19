using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class TopazShard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Topaz Shard");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 150;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.WoodenArrowFriendly;
			Projectile.extraUpdates = 0;
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.position - new Vector2(16, 16), 2, 2, 87, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
			}
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}
}