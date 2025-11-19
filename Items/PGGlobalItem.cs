using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace PapersGuns.Items
{
    public class PGGlobalItem : GlobalItem
    {
        private IEntitySource source;

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (arg == ItemID.MoonLordBossBag)
            {
                player.QuickSpawnItem(source, ModContent.ItemType<Items.EnergyFragment>(), Main.rand.Next(1, 3));
            }

            if (arg == ItemID.EyeOfCthulhuBossBag || arg == ItemID.SkeletronBossBag)
            {
                if (!Main.hardMode)
                {
                    if (Main.rand.NextBool(10))
                    {
                        player.QuickSpawnItem(source, ItemID.IllegalGunParts, 1);
                    }
                }
                else
                {
                    if (Main.rand.NextBool(3))
                    {
                        player.QuickSpawnItem(source, ItemID.IllegalGunParts, 1);
                    }
                }
            }
            if (arg == ItemID.SkeletronBossBag && Main.rand.NextBool(10))
            {
                player.QuickSpawnItem(source, ModContent.ItemType<Items.ForbiddenGunParts>(), Main.rand.Next(1, 3));
            }

            if (arg == ItemID.SkeletronPrimeBossBag || arg == ItemID.TwinsBossBag || arg == ItemID.DestroyerBossBag)
            {
                if (Main.rand.NextBool(3))
                {
                    player.QuickSpawnItem(source, ItemID.IllegalGunParts, 1);
                }
            }
        }

        public override bool InstancePerEntity => true;
    }
}
