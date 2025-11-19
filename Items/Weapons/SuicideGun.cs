using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class SuicideGun : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Handgun);
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			return false;
        }

        public override bool? UseItem(Player player)
        {
			player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " commited suicide..."), player.statLifeMax, 1);
			return true;
        }
	}
}