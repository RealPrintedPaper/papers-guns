using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace PapersGuns.Buffs
{
    public class rekt : ModBuff
    {
        private IEntitySource source;
        int timer = 0;

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            timer++;

            for (int i = 0; i < 10; i++)
            {
                int v = Projectile.NewProjectile(source, npc.position  + new Vector2(npc.width / 2, npc.height / 2) + new Vector2(Main.rand.Next(-100, 100), Main.rand.Next(-100, 100)), Vector2.Zero, ModContent.ProjectileType<Projectiles.HitMarker>(), 100, 0, 0);
                Main.projectile[v].CritChance = 4;
                Main.projectile[v].ArmorPenetration = npc.defense;
            }
            if (timer % 3 == 0)
            {
                SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/HitMarker"), npc.position);
            }

            if (Main.rand.NextBool(50))
            {
                SoundEngine.PlaySound(new SoundStyle("PapersGuns/Sounds/MLG/MLG" + Main.rand.Next(1,16)) with { Volume = 0.6f }, npc.position);
            }
            if (Main.rand.NextBool(5))
            {
                int g = Gore.NewGore(source, npc.position + new Vector2(Main.rand.Next(-50,50), Main.rand.Next(-50, 50)) - new Vector2(npc.width, npc.height), new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5)), Main.rand.Next(new int[] {
                    ModContent.GoreType<Gores.MLG.Airhorn>(), 
                    ModContent.GoreType<Gores.MLG.Dorito>(), 
                    ModContent.GoreType<Gores.MLG.Doritos>(), 
                    ModContent.GoreType<Gores.MLG.Faze>(), 
                    ModContent.GoreType<Gores.MLG.Frog>(), 
                    ModContent.GoreType<Gores.MLG.Illuminati>(), 
                    ModContent.GoreType<Gores.MLG.Lenny>(), 
                    ModContent.GoreType<Gores.MLG.MlgLogo>(), 
                    ModContent.GoreType<Gores.MLG.MntDew>() 
                }), 1f);
                Main.gore[g].scale = 0.5f;
            }
        }
    }
}