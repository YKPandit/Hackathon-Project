// Specific class to handle the sword weapon, child of Item

using New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Sword : Item
{
    // Constructor
    public Sword(Game1 item, Vector2 position, string name, string type, string rarity)
    : base(item, position, name, type, rarity){LoadContent();}

        public override Rectangle ItemPositionRectangle // Create hitbox for item
    {
        get
        {
            return new Rectangle((int)ItemPosition.X, (int)ItemPosition.Y, (int)100f, (int)(ItemSprite.Height*(100f/ItemSprite.Width)));
        }
    }
    public override void LoadContent(){ 
        // Load sword sprite
        base.ItemSprite = item.Content.Load<Texture2D>("3bbc0d500f6805b6e086d8f51ccd1870");
    }



}

