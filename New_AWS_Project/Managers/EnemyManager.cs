// Handles Enemies

namespace New_AWS_Project;

public static class EnemyManager
{
    public static List<Enemy> _enemies {get;} = new();
    public static void AddEnemy(string sprite, Vector2 position, int speed, int health, int damage, int cooldown){
        _enemies.Add(new Enemy(position, health, damage, sprite, speed, cooldown));
    }

    public static void Update(Player player){
        foreach (var en in _enemies){
            en.Update(player);
        }
        _enemies.RemoveAll(en => en.health <= 0);

    }

    public static void Draw(){
        foreach (var en in _enemies){
            en.Draw();
        }
    }
}

