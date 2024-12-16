// Adapter class that stores general info about item
// I.e name, description, value, rarity, weight, etc
// Also includes methods for attack, use, etc.

using New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Item
{
    private Game1 item;
    private Texture2D ItemSprite { get; set; } // Sprite for item
    private Vector2 ItemPosition { get; set; } // Position of item on screen
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public bool Attacking { get; set; }
    public bool Using { get; set; }

    public Item(string name, string type, string rarity)
    {
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
            return new Rectangle();
        }
    }

    public virtual void LoadContent(){ // Load item sprite and postition at characters hand area
        // Default sprite load for item is fist
    }

    public virtual void attack(){
        // Default attack method for items is fist

        Attacking = true;
        
    }

    public virtual void use(Game1 entity){
        // Default use method for items is to do nothing
        Using = true;
    }
}

