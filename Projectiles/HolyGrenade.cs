using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class HolyGrenade : ModProjectile
	{
		private bool postplant = false;
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.aiStyle = 16;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 180;
			Projectile.light = 0;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 0;
			AIType = ProjectileID.Grenade;
			DrawOriginOffsetY = -5;
			if (Main.LocalPlayer.HeldItem.type == ModContent.ItemType<Items.Weapons.TrueChinaLake>())
			{
				postplant = true;
			}
		}

		public override void OnKill(int timeLeft)
		{
			if (postplant)
			{
				for (int i = 0; i < 10; i++)
				{
					Projectile.NewProjectile(source, Projectile.Center, new Vector2(5, 5).RotatedByRandom(MathHelper.ToRadians(360)), ProjectileID.HallowStar, 15, 0, Main.myPlayer);
				}
			}

			Projectile.NewProjectile(source, Projectile.Center, new Vector2(0,0), ModContent.ProjectileType<Explosion>(), Projectile.damage * 2, 0, Main.myPlayer);
			for (int i = 0; i < 25; i++)
			{
				int dustIndex = Dust.NewDust(Projectile.Center, 2, 2, DustID.YellowStarDust, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].velocity *= 3f;
				Main.dust[dustIndex].color = Color.Yellow;
				int dustIndex2 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Gold, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex2].velocity *= 2f;
				int dustIndex3 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Enchanted_Gold, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex3].velocity *= 4f;
			}
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
			SoundEngine.PlaySound(SoundID.NPCDeath7, Projectile.position);

			for (int g = 0; g < 8; g++)
			{
				int goreIndex = Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + Main.rand.NextFloat(-2, 2);
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + Main.rand.NextFloat(-2, 2);
			}
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
		}
	}
}