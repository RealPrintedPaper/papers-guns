using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class TitaniumBulletP : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
		}

		public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

			for (int i = 0; i < 3; i++)
			{
				Vector2 vel = new Vector2(Main.rand.NextFloat(-35, 35), Main.rand.NextFloat(-35, 35));
				int p = Projectile.NewProjectile(source, Projectile.Center + new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5)), vel/3, ModContent.ProjectileType<Projectiles.TitaniumShard>(), Projectile.damage / 3, Projectile.knockBack, Projectile.owner, 0f, 0f);
				Main.projectile[p].CritChance = Projectile.CritChance;
			}
		}
	}
}