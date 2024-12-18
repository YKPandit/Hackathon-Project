// Adapter class that stores general info about item
// I.e name, description, value, rarity, weight, etc
// Also includes methods for attack, use, etc.

using New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System; 

public class Item
{
    protected Game1 item;
    protected Texture2D ItemSprite { get; set; } // Sprite for item
    protected Vector2 ItemPosition { get; set; } // Position of item on screen
    protected Vector2 ItemOrigin { get; set; } // Position to rotate
    public float rotation { get; set; } // Rotation of item
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public bool Attacking { get; set; }
    public bool Using { get; set; }

    public float opacity = 1.0f;
	private float scale = 50f;
    public bool pickedUp = false;

    public SpriteEffects spriteEffect = SpriteEffects.None;

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
            return new Rectangle((int)ItemPosition.X, (int)ItemPosition.Y, (int)scale, (int)(ItemSprite.Height*(scale/ItemSprite.Width)));
        }
    }
    public virtual void LoadContent(){ // Load item sprite and postition at characters hand area 
        // Default sprite load for item is fist
        ItemSprite = item.Content.Load<Texture2D>("Clenched_human_fist");
        ItemOrigin = new Vector2(ItemSprite.Width / 2f, ItemSprite.Height / 2f);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
{
    // Use a single scale factor to maintain aspect ratio
    float scaleFactor = (ItemPositionRectangle.Width / (float)ItemSprite.Width);
    
    spriteBatch.Draw(
        ItemSprite,
        ItemPosition,
        null,
        Color.White * opacity,
        rotation,
        ItemOrigin,
        new Vector2(scaleFactor, scaleFactor),
        SpriteEffects.None,
        0f
    );
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
		scale = 15.0f;
		opacity = 1.0f;

    }
    public void pickedUpItem()
    {
        opacity *= 0.0f;
        pickedUp = true;
    }

    public void setInvis()
    {
        opacity = 0.0f;
    }

    public void mousePosition(){
        Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        Vector2 dPos = ItemPosition - mousePosition;
        rotation = (float)Math.Atan2(-dPos.Y, -dPos.X);
        
        if(ItemPosition.X + ItemSprite.Width/2 < mousePosition.X)
        {
            spriteEffect = SpriteEffects.None;
        }
        else if(ItemPosition.X + ItemSprite.Width/2 > mousePosition.X)
        {
            spriteEffect = SpriteEffects.FlipHorizontally;
        }
    }

    public void Update(Vector2 pos){
		ItemPosition = pos;
        mousePosition();
	}
}

