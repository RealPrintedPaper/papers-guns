using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using System.Collections.Generic;
using PapersGuns.Items.Weapons;

namespace PapersGuns.Projectiles
{
	public class VulcanMinigunP : ModProjectile
	{
		public override string Texture => "PapersGuns/Items/Weapons/VulcanMinigun";
		private IEntitySource source;
		Vector2 velocity;

		bool isreleased = false;
		bool triggerrelease = false;
		int timeleft = 0;
		float randomangle;

		Vector2 randompos = new Vector2(0, 0);

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
			Projectile.timeLeft = 9999999;
			Projectile.light = 0f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 0;
			Projectile.aiStyle = 0;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);
			UpdatePlayerVisuals(player, rrp);

			VulcanMinigun vulcanMinigun = new VulcanMinigun();

			Projectile.ai[0] += 1f;

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
			Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
			Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi) + randomangle/80;

			Projectile.Center = player.position + new Vector2(player.width / 2, player.height / 2);

			if (player.dead || !player.active)
            {
				Projectile.Kill();
            }

			if (Projectile.spriteDirection == 1)
			{
				DrawOffsetX = 0 + (int)randompos.X;
				DrawOriginOffsetY = -16;
				DrawOriginOffsetX = -55 + (int)randompos.Y;

				velocity = new Vector2(25, 0).RotatedBy(Projectile.rotation);
			}
			else
			{
				DrawOffsetX = -110 + (int)randompos.X;
				DrawOriginOffsetY = -16;
				DrawOriginOffsetX = 55 + (int)randompos.Y;

				velocity = new Vector2(-25, 0).RotatedBy(Projectile.rotation);
			}

			if (Projectile.ai[0] == 2)
			{
				SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/minigunfirestart") with { Volume = 0.5f}, player.position);
			}

			if (Projectile.ai[0] >= 50 & !isreleased & timeleft == 0)
			{
				randomangle = Main.rand.NextFloat(-1,1);
				randompos = new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-2, 2));
				if (Projectile.ai[0] % 2 == 0)
				{
					SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/minigunfireloop1") with { Volume = 0.5f, Pitch = Main.rand.NextFloat(-0.1f, 0.1f) }, player.position);
				}
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(6));
				if (player.HeldItem.shoot == 14)
				{
					int v = Projectile.NewProjectile(source, Projectile.position, velocity + perturbedSpeed, ProjectileID.BulletHighVelocity, Projectile.damage, Projectile.knockBack, player.whoAmI);
					Main.projectile[v].CritChance = Projectile.CritChance;
				}
				else
				{
					int v = Projectile.NewProjectile(source, Projectile.position, velocity + perturbedSpeed, player.HeldItem.shoot, Projectile.damage, Projectile.knockBack, player.whoAmI);
					Main.projectile[v].CritChance = Projectile.CritChance;
				}
				player.PickAmmo(player.inventory[player.selectedItem], out int _, out float _, out int _, out float _, out int _);
			}

			if (player.releaseUseItem & Projectile.ai[0] > 50)
			{
				if (!isreleased)
				{
					isreleased = true;
				}
			}

			if (player.releaseUseItem)
            {
				triggerrelease = true;
            }

			if (triggerrelease & Projectile.ai[0] > 50)
            {
				if (timeleft == 0)
				{
					SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/minigunfireend") with { Volume = 0.5f }, player.position);
				}
				timeleft++;
			}

			if (timeleft > 30)
            {
				Projectile.Kill();
            }
		}

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
		{
			overPlayers.Add(index);
		}
		private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
		{
			// Place the Prism directly into the player's hand at all times.
			Projectile.Center = playerHandPos;
			// The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.spriteDirection = Projectile.direction;

			// The Prism is a holdout projectile, so change the player's variables to reflect that.
			// Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;

			// If you do not multiply by projectile.direction, the player's hand will point the wrong direction while facing left.
			player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
		}
	}
}