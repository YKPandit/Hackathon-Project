// Handles Projectiles shot by the player

namespace New_AWS_Project;

public static class PlayerProjectileManager
{
    private static List<Projectile> _projectiles {get;} = new();
    public static void AddProjectile(string sprite, Vector2 position, int speed, float rotation, float lifespan, int damage){
        _projectiles.Add(new Projectile(sprite, position, speed, rotation, lifespan, damage));
    }

    public static void Update(Enemy enemy){
        foreach (var projectile in _projectiles){
            projectile.Update(enemy);
        }
        int current = (_projectiles.Count - 1) > 0 ? _projectiles.Count - 1 : 0;
        if (_projectiles.Count > 0 && !enemy.dead &&  enemy.PositionRectangle.Intersects(_projectiles[current].ItemPositionRectangle))
        {
            enemy.enemyDamage(_projectiles[current].Damage);
            _projectiles.Remove(_projectiles[current]);
        }
        _projectiles.RemoveAll(projectile => projectile.Lifespan <= 0);

    }

    public static void Draw(){
        foreach (var projectile in _projectiles){
            projectile.Draw();
        }
    }
}

