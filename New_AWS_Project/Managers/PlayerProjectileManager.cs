// Handles Projectiles shot by the player

namespace New_AWS_Project;

public static class PlayerProjectileManager
{
    public static List<Projectile> _projectiles {get;} = new();
    public static void AddProjectile(string sprite, Vector2 position, int speed, float rotation, float lifespan, int damage){
        _projectiles.Add(new Projectile(sprite, position, speed, rotation, lifespan, damage));
    }

    public static void Update(List<Enemy> _enemies){
        foreach (var projectile in _projectiles){
            projectile.Update();
            foreach (var en in _enemies){
                if (projectile.ItemPositionRectangle.Intersects(en.PositionRectangle)){
                    en.enemyDamage(projectile.Damage);
                    projectile.Destroy();
                }
            }
        }
        _projectiles.RemoveAll(projectile => projectile.Lifespan <= 0);

    }

    public static void Draw(){
        foreach (var projectile in _projectiles){
            projectile.Draw();
        }
    }
}

