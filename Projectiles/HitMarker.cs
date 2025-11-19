using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace PapersGuns.Projectiles
{
	public class HitMarker : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.scale = 0.5f;
			Projectile.width = 27;
			Projectile.height = 27;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 3;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 0;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 0;
		}
    }
}