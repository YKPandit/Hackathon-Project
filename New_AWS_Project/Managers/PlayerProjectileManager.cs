// Handles Projectiles shot by the player

namespace New_AWS_Project;

public static class PlayerProjectileManager
{
    private static List<Projectile> _projectiles {get;} = new();

    public static void AddProjectile(string sprite, Vector2 position, int speed, float rotation, float lifespan){
        _projectiles.Add(new Projectile(sprite, position, speed, rotation, lifespan));
    }

    public static void Update(){
        foreach (var projectile in _projectiles){
            projectile.Update();
        }
        _projectiles.RemoveAll(projectile => projectile.Lifespan <= 0);

    }

    public static void Draw(){
        foreach (var projectile in _projectiles){
            projectile.Draw();
        }
    }
}

