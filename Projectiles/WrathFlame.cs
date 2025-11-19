using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;

namespace PapersGuns.Projectiles
{
	public class WrathFlame : ModProjectile
	{
		private bool postplant = false;
        private IEntitySource source;

        public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = 9;
			Projectile.alpha = 255;
			if (Main.LocalPlayer.HeldItem.type == ModContent.ItemType<Items.Weapons.TrueWrathofTerraria>())
			{
				postplant = true;
			}
		}

        public override void AI()
		{
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] % 10 == 0)
            {
				Projectile.damage += 1;
            }
			if (Projectile.timeLeft < 593)
			{
				Projectile.velocity.X *= 0.97f;
				Projectile.velocity.Y *= 0.97f;
				int dust = Dust.NewDust(Projectile.position, Projectile.width + 5, Projectile.height + 5, DustID.Shadowflame, 0, 0, 100);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].velocity *= 5;
				Main.dust[dust].velocity /= (Projectile.timeLeft / 75);
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.ShadowFlame, 60);
			if (postplant)
			{
				Projectile.damage += 6;
			}
			else
            {
				Projectile.damage += 3;
			}

			Projectile.timeLeft -= 10;
		}

        public override void OnKill(int timeLeft)
        {
			if(postplant)
            {
				for (int i = 0; i < Main.rand.NextFloat(2, 4); i++)
				{
					Vector2 vel = new Vector2(Main.rand.NextFloat(-15, 15), Main.rand.NextFloat(-15, 15));
					Projectile.NewProjectile(source, Projectile.Center, vel, Main.rand.Next(new int[] {ProjectileID.CursedFlameFriendly, ProjectileID.GoldenShowerFriendly}), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
				}
				for (int i = 0;i < 15; i++)
                {
					Dust.NewDust(Projectile.position, Projectile.width + 10, Projectile.height + 10, DustID.Shadowflame, 0, 0, 100, default, 3f);
				}
			}
        }
    }
}