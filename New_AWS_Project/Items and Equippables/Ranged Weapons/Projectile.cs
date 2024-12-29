// Class to represent a projectile that can be fired from a ranged weapon
using System.ComponentModel;

namespace New_AWS_Project;

public class Projectile
{
    public Texture2D Texture { get; set; }
    public Vector2 Origin { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    public int Speed { get; set; }
    public float Rotation { get; set; }
    public float Lifespan {get; set;}
    public int Damage;

    public Projectile(string sprite, Vector2 position, int speed, float rotation, float lifespan, int damage)
    {
        Position = position;
        Speed = speed;
        Rotation = rotation;
        Lifespan = lifespan;
        Direction = new Vector2(-(float)Math.Cos(rotation), -(float)Math.Sin(rotation));
        Texture = Globals.Content.Load<Texture2D>(sprite);
        Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        Damage = damage;
    }

        public virtual Rectangle ItemPositionRectangle // Create hitbox for item
    {
        get
        {
            int x, y, w, h;
            if (Rotation != 0)
            {
                var cos = Math.Abs(Math.Cos(Rotation));
                var sin = Math.Abs(Math.Sin(Rotation));
                var t1_opp = Texture.Width * cos;
                var t1_adj = Math.Sqrt(Math.Pow(Texture.Width, 2) - Math.Pow(t1_opp, 2));
                var t2_opp = Texture.Height * sin;
                var t2_adj = Math.Sqrt(Math.Pow(Texture.Height, 2) - Math.Pow(t2_opp, 2));

                w = (int)(t1_opp + t2_opp);
                h = (int)(t1_adj + t2_adj);
                x = (int)(Position.X - (w / 2));
                y = (int)(Position.Y - (h / 2));
            }
            else
            {
                x = (int)Position.X;
                y = (int)Position.Y;
                w = Texture.Width;
                h = Texture.Height;
            }
            return new Rectangle(x, y, w, h);
        }
    }

    public void Draw()
    {
        
        Globals._spriteBatch.Draw(
            Texture,
            Position,
            null,
            Color.White, 
            Rotation,
            Origin,
            1.0f, // scale
            SpriteEffects.None,
            0f
        );
    }


    public void Update(Enemy enemy)
    {
        Position += Direction * Speed * Globals.totalSeconds;
        Lifespan -= Globals.totalSeconds;

    }
}
