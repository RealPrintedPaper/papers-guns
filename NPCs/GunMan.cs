using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;

namespace PapersGuns.NPCs
{
    [AutoloadHead]
    public class GunMan : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gun Man");
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;

            NPC.Happiness
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Like)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Like)
                .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike);
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            int Armsdealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (Armsdealer >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Tony",
                "Toby",
                "Tory",
                "Ruger",
                "Colt",
                "Smith",
                "Wessy",
                "Makrov",
                "Python",
                "Tommy",
                "Walther",
                "Hekter"

            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("AK47").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Gewehr98").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Glock17").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("WinchesterModel1912").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ColtPython").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Dragunov").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("MP40").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Rpg7").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Rocket0").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("PotatoCannon").Type);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Potato").Type);
            nextSlot++;

            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Type63").Type);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("TaurusRagingBull").Type);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("AACHoneyBadger").Type);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("PancorJackhammer").Type);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("DesertEagle").Type);
                nextSlot++;
            }
            if (NPC.downedPlantBoss)
            {
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Usas12").Type);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("M60").Type);
                nextSlot++;
            }
            if (Main.expertMode)
            {
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("GoldenDeagle").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("Ntw20").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("DualAA12").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("MiniNukeLauncher").Type);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("MiniNuke").Type);
                }
            }
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            int Armsdealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (Armsdealer >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("You know that " + Main.npc[Armsdealer].GivenName + " guy? He's my bro."));
                chat.Add(Language.GetTextValue("Make sure you go see " + Main.npc[Armsdealer].GivenName + " if you need to restock on ammunition."));
            }

            chat.Add(Language.GetTextValue("Why are you looking at me like that? Do I look silly? I'm a silly guy?"));
            chat.Add(Language.GetTextValue("What're ya buying?"));
            chat.Add(Language.GetTextValue("Gun! Sorry, happens when I see my reflection."));
            chat.Add(Language.GetTextValue("Wanna buy some unlicensed beverages?"));
            chat.Add(Language.GetTextValue("I used to be a range safety officer. But then I... Nevermind."));
            chat.Add(Language.GetTextValue("Home to many guns! You want some?"));
            chat.Add(Language.GetTextValue("Yeah, my safety is on."));
            chat.Add(Language.GetTextValue("There's only one rule of firearm safety I cannot physically follow."));
            chat.Add(Language.GetTextValue("Don't touch my face please."));
            chat.Add(Language.GetTextValue("Line 'em up and knock 'em down, as I like to say!"));
            chat.Add(Language.GetTextValue("That's me, I'm the gun guy!"));
            return chat;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (Main.hardMode == true)
            {
                damage = 35;
                knockback = 3f;
            }
            else
            {
                damage = 15;
                knockback = 2f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<Items.Weapons.ColtPython>(), 1, false, 0, false, false);
            if (Main.rand.NextBool(3))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.IllegalGunParts, 1, false, 0, false, false);
            }
        }
    }
}