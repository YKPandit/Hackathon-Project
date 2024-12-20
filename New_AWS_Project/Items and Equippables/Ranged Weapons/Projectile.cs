// Class to represent a projectile that can be fired from a ranged weapon
namespace New_AWS_Project;

public class Projectile
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    public int Speed { get; set; }
    public float Rotation { get; set; }
    public float Lifespan {get; set;} 

    public Projectile(string sprite, Vector2 position, int speed, float rotation, float lifespan)
    {
        Position = position;
        Speed = speed;
        Rotation = rotation;
        Lifespan = lifespan;
    }
    public void loadContent(string sprite)
    {
        Texture = Globals.Content.Load<Texture2D>(sprite);
    }

    public void Update()
    {
        Position += Direction * Speed * Globals.totalSeconds;
        Lifespan -= Globals.totalSeconds;
    }
}
