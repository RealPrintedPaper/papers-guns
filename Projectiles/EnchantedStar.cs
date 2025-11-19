using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class EnchantedStar : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 5;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 300;
			Projectile.light = 0.7f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			AIType = ProjectileID.FallingStar;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (Main.rand.Next(4) == 0)
            {
				float random = Main.rand.NextFloat(-400, 400);
				Projectile.NewProjectile(source, Projectile.position + new Vector2(random, -1000), new Vector2(-random / 35, 30), ProjectileID.HallowStar, Projectile.damage / 2, Projectile.knockBack, Projectile.owner, 0, 1);
			}
        }

        public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 2; i++)
			{
				float random = Main.rand.NextFloat(-400, 400);
				Projectile.NewProjectile(source, Projectile.position + new Vector2(random, -1000), new Vector2(-random / 35, 30), ProjectileID.HallowStar, Projectile.damage / 2, Projectile.knockBack, Projectile.owner, 0, 1);
			}
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}