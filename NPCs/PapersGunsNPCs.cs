using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace PapersGuns.NPCs
{
	public class PapersGunsNPCs : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool aWrath;
		public bool Illuminated;
		public bool Terraflamed;
		public bool RoomTemped;

        public override void ResetEffects(NPC npc)
		{
			aWrath = false;
			Illuminated = false;
			Terraflamed = false;
			RoomTemped = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (aWrath)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 500;
				if (damage < 50)
				{
					damage = 50;
				}
			}

			if (Illuminated)
            {
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 50;
				if (damage < 5)
				{
					damage = 5;
				}
			}

			if (Terraflamed)
            {
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 40;
				if (damage < 4)
				{
					damage = 4;
				}
			}
			if (RoomTemped)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 80;
				if (damage < 8)
				{
					damage = 8;
				}
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (aWrath)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 86, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 2f;
				}
			}
			else if (Illuminated)
			{
				int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 66, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, Main.rand.Next(new Color[] {new Color(0, 255, 150), new Color(210, 150, 150)}), 2f);
				Main.dust[dust].noGravity = true;
			}
			else if (Terraflamed)
			{
				int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 106, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 2f);
				Main.dust[dust].noGravity = true;
			}
			/*else
            {
				npc.color = default(Color);
            }*/
		}

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
			if (System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
			{
				LeadingConditionRule eaterofworldsdrop = new(new Conditions.LegacyHack_IsABoss());
				eaterofworldsdrop.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.BrownBess>(), 10));
				npcLoot.Add(eaterofworldsdrop);
			}

			if (Main.hardMode == false)
            {
				if (npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.SkeletronHead || npc.type == NPCID.ArmsDealer)
				{
					npcLoot.Add(ItemDropRule.Common(ItemID.IllegalGunParts, 10));
				}
			}
			else
			{
				if (npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.SkeletronHead || npc.type == NPCID.ArmsDealer)
				{
					npcLoot.Add(ItemDropRule.Common(ItemID.IllegalGunParts, 3));
				}
			}

			if (NPC.downedBoss3)
			{
				if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon || npc.type == NPCID.Lavabat || npc.type == NPCID.LavaSlime || npc.type == NPCID.Hellbat || npc.type == NPCID.RedDevil || npc.type == NPCID.FireImp && !npc.SpawnedFromStatue)
				{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ForbiddenGunParts>(), 100));
				}
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.BruhGun>(), 100));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.HenryAR7>(), 10));
			}
			if (npc.type == NPCID.Mothron)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.BrokenHeroGun>(), 4));
			}
			if (npc.type == NPCID.Vampire | npc.type == NPCID.VampireBat)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.VampirePointKit>(), 20));
			}

			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.SuicideGun>(), 100000));

			switch (npc.type)
			{
				case NPCID.KingSlime:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.MacePistol>(), 10));
					break;
				case NPCID.Deerclops:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.DeerGun>(), 10));
					break;
				case NPCID.BrainofCthulhu:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Bren>(), 10));
					break;
				case NPCID.QueenBee:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.M14>(), 10));
					break;
				case NPCID.SkeletronHead:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Skeletonized1911>(), 10));
					break;
				case NPCID.WallofFlesh:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.WaltherMP>(), 10));
					break;
				case NPCID.QueenSlimeBoss:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.L85A2>(), 10));
					break;
				case NPCID.TheDestroyer:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.MiniMark45>(), 10));
					break;
				case NPCID.Spazmatism:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.SPAS12>(), 10));
					break;
				case NPCID.Retinazer:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.RemingtonM700>(), 10));
					break;
				case NPCID.SkeletronPrime:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.SkeletonizedM4>(), 10));
					break;
				case NPCID.Plantera:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.M16>(), 10));
					break;
				case NPCID.HallowBoss:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Type11LMG>(), 10));
					break;
				case NPCID.DukeFishron:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.DukesDoubleBarrelShotgun>(), 10));
					break;
				case NPCID.Golem:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Galil>(), 10));
					break;
				case NPCID.CultistBoss:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.TAR21>(), 10));
					break;
				case NPCID.MoonLordCore:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.SHARP>(), 10));
					break;
			}
		}
	}
}