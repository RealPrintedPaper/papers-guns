using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace PapersGuns.Projectiles
{
	public class Point : ModProjectile
	{
        private IEntitySource source;

        public override void SetDefaults()
		{
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = 1;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 120;
			Projectile.tileCollide = false;
			AIType = ProjectileID.Bullet;
			Projectile.alpha = 255;
		}

        public override void AI()
		{
			Projectile.alpha = 255;
			for (int i = 0; i < 2; i++)
			{
				int v = Projectile.NewProjectile(source, Projectile.position + new Vector2(Main.rand.Next(-100, 100), Main.rand.Next(-100, 100)) + new Vector2(0, -1200), new Vector2(0, 20), ModContent.ProjectileType<HallowPointBulletShot>(), Projectile.damage, Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
				Main.projectile[v].CritChance = Projectile.CritChance;
			}

			if (Main.rand.NextBool(2))
			{
				SoundEngine.PlaySound(new SoundStyle(Main.rand.Next(new string[] {
				"PapersGuns/Sounds/flyby1",
				"PapersGuns/Sounds/flyby2",
				"PapersGuns/Sounds/flyby3",
				"PapersGuns/Sounds/flyby4",
				"PapersGuns/Sounds/flyby5",
				"PapersGuns/Sounds/flyby6",
				"PapersGuns/Sounds/flyby7" }))
				with { Volume = 0.6f, Pitch = Main.rand.NextFloat(-0.12f, 0f) }, Projectile.position);
			}
		}
	}
}