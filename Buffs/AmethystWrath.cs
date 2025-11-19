using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class AmethystWrath : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Amethyst Wrath");
            // Description.SetDefault("You are becoming crystallized!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<NPCs.PapersGunsNPCs>().aWrath = true;
            npc.defense = 0;
            if(!npc.boss)
            {
                npc.velocity *= 0.5f;
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.venom = true;
            player.statDefense = 0;
            player.velocity *= 0.5f;
        }
    }
}