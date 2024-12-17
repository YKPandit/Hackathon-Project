// Adapter class that stores general info about item
// I.e name, description, value, rarity, weight, etc
// Also includes methods for attack, use, etc.

using New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Item
{
    protected Game1 item;
    protected Texture2D ItemSprite { get; set; } // Sprite for item
    protected Vector2 ItemPosition { get; set; } // Position of item on screen
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public bool Attacking { get; set; }
    public bool Using { get; set; }

    public float opacity = 1.0f;
    public bool pickedUp = false;

    public Item(Game1 item, Vector2 position, string name, string type, string rarity)
    {
        this.item = item;
        this.ItemPosition = position;
        LoadContent();
        Name = name;
        Type = type;
        Rarity = rarity;
        Attacking = false;
        Using = false;
    }

    public virtual Rectangle ItemPositionRectangle // Create hitbox for item
    {
        get
        {
            return new Rectangle((int)ItemPosition.X, (int)ItemPosition.Y, (int)100f, (int)(ItemSprite.Height*(100f/ItemSprite.Width)));
        }
    }
    public virtual void LoadContent(){ // Load item sprite and postition at characters hand area 
        // Default sprite load for item is fist
        ItemSprite = item.Content.Load<Texture2D>("Clenched_human_fist");
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(ItemSprite, ItemPositionRectangle, Color.White * opacity);
    }

    public virtual void Attack()
    {
        Attacking = true;
    }

    public virtual void Use()
    {
        Using = true;
    }

    public void setPosition(Vector2 newPos)
    {
        ItemPosition = newPos;
    }
    public void pickedUpItem()
    {
        opacity = 0.0f;
        pickedUp = true;
    }
}

