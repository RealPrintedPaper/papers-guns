using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PapersGuns
{
	public class PGPlayer : ModPlayer
	{
		public bool suitcaseon;
		public bool backupmagon;
		public bool vampirepointkiton;
		public bool scavengerbagon;
		public bool riotshield;
		public bool captainshield;

        public override void ResetEffects()
        {
			suitcaseon = false;
			backupmagon = false;
			vampirepointkiton = false;
			scavengerbagon = false;
			riotshield = false;
			captainshield = false;


		}
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Projectile, consider using OnHitNPC instead */
		{
			if (proj.type == ModContent.ProjectileType<Projectiles.LargeRuby>())
			{
				if (target.type != NPCID.TargetDummy)
				{
					SoundEngine.PlaySound(SoundID.Item4, Player.position);
					int health = (damage / 100) + 1;
					Main.player[proj.owner].statLife += health;
					Player.HealEffect(health, true);
				}
			}

			if (proj.type == ModContent.ProjectileType<Projectiles.HealthParticle>())
			{
				if (target.type != NPCID.TargetDummy)
				{
					SoundEngine.PlaySound(SoundID.Item4, Player.position);
					int health = (damage / 3) + 1;
					Main.player[proj.owner].statLife += health;
					Player.HealEffect(health, true);
				}
			}

			if (proj.type == ModContent.ProjectileType<Projectiles.LargeEmerald>())
			{
				if (target.type != NPCID.TargetDummy)
				{
					Main.player[proj.owner].AddBuff(ModContent.BuffType<Buffs.EmeraldBlessing>(), 300);
				}
			}

			if (proj.type == ModContent.ProjectileType<Projectiles.PalladiumBulletP>())
            {
				if (target.type != NPCID.TargetDummy)
				{
					Main.player[proj.owner].AddBuff(BuffID.RapidHealing, 300);
				}
			}

			if (vampirepointkiton & crit)
			{
				if (target.type != NPCID.TargetDummy)
				{
					if (Player.HeldItem.DamageType == DamageClass.Ranged)
					{
						int healing;
						if (NPC.downedMoonlord)
						{
							healing = (damage / 50) + 1;
						}
						else
						{
							healing = (damage / 30) + 1;
						}

						Player.statLife += healing;
						if (Main.myPlayer == Player.whoAmI)
						{
							Player.HealEffect(healing, true);
						}
					}
				}
			}
		}
		private void sound()
		{
			SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/shielddink") with { Volume = 0.5f }, Player.position);
		}
		public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
		{
			float dmg = damage;
			if (damage >= 1)
			{
				if (riotshield)
				{
					if (Player.direction < 0)
					{
						if (npc.position.X > Player.position.X)
						{
							damage = (int)(dmg * 0.66f);
							sound();
						}
					}
					else
					{
						if (npc.position.X < Player.position.X)
						{
							damage = (int)(dmg * 0.66f);
							sound();
						}
					}
				}
				if (captainshield)
				{
					if (Player.direction < 0)
					{
						if (npc.position.X > Player.position.X)
						{
							damage = (int)(dmg * 0.5f);
							sound();
						}
					}
					else
					{
						if (npc.position.X < Player.position.X)
						{
							damage = (int)(dmg * 0.5f);
							sound();
						}
					}
				}
			}
		}

		public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
		{
			float dmg = damage;
			if (damage >= 1)
			{
				if (riotshield)
				{
					if (Player.direction < 0)
					{
						if (proj.position.X > Player.position.X)
						{
							damage = (int)(dmg * 0.66f);
							sound();
						}
					}
					else
					{
						if (proj.position.X < Player.position.X)
						{
							damage = (int)(dmg * 0.66f);
							sound();
						}
					}
				}
				if (captainshield)
				{
					if (Player.direction < 0)
					{
						if (proj.position.X > Player.position.X)
						{
							damage = (int)(dmg * 0.5f);
							sound();
						}
					}
					else
					{
						if (proj.position.X < Player.position.X)
						{
							damage = (int)(dmg * 0.5f);
							sound();
						}
					}
				}
			}
		}

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			bool inWater = !attempt.inLava && !attempt.inHoney;
			if (inWater && Player.ZoneBeach)
			{
				if (!attempt.veryrare && !attempt.legendary && attempt.rare && Main.rand.NextBool(4))
				{
					itemDrop = ModContent.ItemType<Items.Weapons.PistolShrimp>();
				}
				else
                {
					return;
                }			
			}
		}

        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
			if (suitcaseon)
			{
				return Main.rand.NextFloat() >= .25f;
			}
			if (backupmagon)
			{
				return Main.rand.NextFloat() >= .10f;
			}
			return true;
        }
    }
}