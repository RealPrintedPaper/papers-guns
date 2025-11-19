using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Projectiles
{
	public class FriendlyShark : ModProjectile
	{
        private IEntitySource source;

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.light = 0;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;

		}

        public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
			// Adding Pi to rotation if facing left corrects the drawing
			Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
			if (Projectile.spriteDirection == 1) // facing right
			{
				DrawOffsetX = -106; // These values match the values in SetDefaults
				DrawOriginOffsetY = -24;
				DrawOriginOffsetX = 44;
			}
			else
			{
				// Facing left.
				// You can figure these values out if you flip the sprite in your drawing program.
				DrawOffsetX = 0; // 0 since now the top left corner of the hitbox is on the far left pixel.
				DrawOriginOffsetY = -24; // doesn't change
				DrawOriginOffsetX = -44; // Math works out that this is negative of the other value.
			}
		}

        public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);

			for (int i = 0; i < 4; i++)
			{
				Gore.NewGore(source, new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-2, 2)) + Projectile.velocity, 89 + i, 1f);
			}
		}
	}
}