using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class DustBubble : ModProjectile
	{
        private IEntitySource source;
        public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = Main.rand.Next(400,500);
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 0;
			Projectile.penetrate = 15;
			Projectile.localNPCHitCooldown = 3;
		}

        public override void AI()
		{

			Projectile.rotation = Projectile.position.X / 50;
			if (Projectile.timeLeft % 10 == 0)
            {
				Projectile.damage += 1;
            }
			if (Projectile.timeLeft < 593)
			{
				Projectile.velocity.X *= 0.97f;
				Projectile.velocity.Y *= 0.97f;
				int dust = Dust.NewDust(Projectile.position, Projectile.width + 5, Projectile.height + 5, DustID.TintableDust, Main.rand.NextFloat(-2,2), Main.rand.NextFloat(-2, 2), newColor:Color.Yellow);
				Main.dust[dust].noGravity = true;
			}
		}

        public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
			Projectile.NewProjectile(source, Projectile.Center, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
			for (int g = 0; g < 8; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);
			}
		}
    }
}