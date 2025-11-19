using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class HolyFlame : ModProjectile
	{
		private bool postplant = false;
        private IEntitySource source;

        public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.alpha = 255;
			if (Main.LocalPlayer.HeldItem.type == ModContent.ItemType<Items.Weapons.TrueHolyFlame>())
			{
				postplant = true;
			}
		}

        public override void AI()
		{
			if (Projectile.damage < 1)
            {
				Projectile.Kill();
            }
			Projectile.velocity.X *= 1.015f;
			Projectile.velocity.Y *= 1.015f;
			if (Projectile.timeLeft < 170)
			{
				int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.RainbowTorch, 0, 0, 100, Color.Yellow, 2f);
				Main.dust[dust].noGravity = true;
				int dust2 = Dust.NewDust(Projectile.position, 1, 1, DustID.RainbowTorch, 0, 0, 100, Color.HotPink, 2f);
				Main.dust[dust2].noGravity = true;
				int dust3 = Dust.NewDust(Projectile.position, 1, 1, DustID.RainbowTorch, 0, 0, 100, Color.Cyan, 2f);
				Main.dust[dust3].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.damage = (int)Math.Floor(Projectile.damage / 1.5f);
			target.AddBuff(BuffID.OnFire, 120);
			if (postplant)
            {
				if (Main.rand.NextBool())
				{
					float random = Main.rand.NextFloat(-400, 400);
					Projectile.NewProjectile(source, target.position + new Vector2(random, -1000), new Vector2(-random / 35, 30), ProjectileID.HallowStar, 50, Projectile.knockBack, Projectile.owner, 0, 1);
				}
			}
		}
	}
}