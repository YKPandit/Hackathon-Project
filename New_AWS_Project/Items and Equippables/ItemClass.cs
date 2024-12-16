// Adapter class that stores general info about item
// I.e name, description, value, rarity, weight, etc
// Also includes methods for attack, use, etc.

using New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public string Rarity { get; set; }
    public bool Attacking { get; set; }
    public bool Using { get; set; }
    public Texture2D ItemSprite { get; set; } // Sprite for item
    public Item(string name, string rarity)
    {
        Name = name;
        Rarity = rarity;
        Attacking = false;
        Using = false;
    }

    public Rectangle ItemPositionRectangle // Create hitbox for item
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
    }
}

