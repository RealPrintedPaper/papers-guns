using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace PapersGuns.Projectiles
{
	public class MLGAWP : ModProjectile
	{
		public override string Texture => "PapersGuns/Items/Weapons/MLGAWP";
		private IEntitySource source;
		bool spawnin = true;
		Vector2 velocity;
		int angle = 12;

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
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 45;
			Projectile.light = 0f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 0;
			Projectile.aiStyle = 0;
			DrawOffsetX = -51;
			DrawOriginOffsetY = -4;
			DrawOriginOffsetX = 0;
			DrawHeldProjInFrontOfHeldItemAndArms = true;
		}
		public override void AI()
		{
			Projectile.ai[0] += 1f;

			if (Projectile.ai[0] <= 30f)
            {
				Projectile.velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(angle));
            }
			else if (Projectile.ai[0] == 31f)
			{
				Vector2 targ = Main.MouseWorld;
				Vector2 pos = Projectile.Center;

				float shootToX = targ.X - pos.X;
				float shootToY = targ.Y - pos.Y;
				float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
				distance = 3f / distance;
				shootToX *= distance;
				shootToY *= distance;
				Projectile.velocity.X = shootToX;
				Projectile.velocity.Y = shootToY;
			}
            else if (Projectile.ai[0] == 32f)
            {
				SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/MLGAWPshot"), Main.player[Projectile.owner].position);

				if (Projectile.spriteDirection == 1)
				{
					velocity = new Vector2(15, 0).RotatedBy(Projectile.rotation);
				}
				else
				{
					velocity = new Vector2(-15, 0).RotatedBy(Projectile.rotation);
				}

				int v = Projectile.NewProjectile(source, Projectile.position, velocity, ModContent.ProjectileType<AwpShot>(), Projectile.damage * 10, Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
				Main.projectile[v].CritChance = Projectile.CritChance;
			}

			if (spawnin == true)
			{
				spawnin = false;
			}
			Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
			Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);

			Projectile.Center = Main.player[Projectile.owner].position + new Vector2(Main.player[Projectile.owner].width / 2, 10);
		}

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
			overPlayers.Add(index);
        }
    }
}