using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class MeteorChunk : ModItem
	{
		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.knockBack = 0;
			Item.value = 100;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileID.Meteor1;
			Item.shootSpeed = 8f;
			Item.ammo = Item.type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MeteorChunk>(), 11);
			recipe.AddIngredient(ItemID.Meteorite, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}