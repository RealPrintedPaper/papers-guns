using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
namespace PapersGuns.Projectiles
{

	public class AwpShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 1500;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 10;
			AIType = ProjectileID.BulletHighVelocity;
			Projectile.alpha = 255;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Buffs.rekt>(), 600);
			for (int i = 0; i < 2; i++)
			{
				SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/MLG/MLG" + Main.rand.Next(1, 16)) with { Volume = 0.6f }, target.position);
			}
			SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/MLG/MLGMUSIC"), target.position);
		}
    }
}