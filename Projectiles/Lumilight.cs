using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PapersGuns.Projectiles
{
	public class Lumilight : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 70;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			if (Projectile.timeLeft < 63)
			{
				for (int i = 0; i < 3; i++)
				{
					int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.RainbowTorch, 0, 0, 100);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].color = new Color(0,255,150);
				}
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.damage = (int)Math.Floor(Projectile.damage / 1.04f);
			target.AddBuff(ModContent.BuffType<Buffs.Illuminated>(), 120);
			for (int i = 0; i < 15; i++)
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RainbowTorch);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity += (Projectile.velocity / 1.5f);
				Main.dust[dust].velocity *= 3;
				Main.dust[dust].scale = 2f;
				Main.dust[dust].color = new Color(210, 150, 150);
			}

		}
	}
}