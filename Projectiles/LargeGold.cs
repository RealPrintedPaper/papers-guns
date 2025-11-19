using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class LargeGold : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Large Gold Coin");
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
			AIType = ProjectileID.Bullet;
			Projectile.extraUpdates = 1;
		}

        public override void AI()
        {
			Projectile.NewProjectile(source, Projectile.Center, new Vector2(5, 5).RotatedByRandom(MathHelper.ToRadians(360)), ProjectileID.GoldCoin, Projectile.damage / 20, 0, Main.myPlayer);
		}
        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}