using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Buffs
{
    public class Illuminated : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<NPCs.PapersGunsNPCs>().Illuminated = true;
        }
    }
}