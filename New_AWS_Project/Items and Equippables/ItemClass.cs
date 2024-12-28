// Adapter class that stores general info about item
// I.e name, description, value, rarity, weight, etc
// Also includes methods for attack, use, etc.

namespace New_AWS_Project;

public class Item
{
    protected Texture2D ItemSprite { get; set; } // Sprite for item
    protected Vector2 ItemPosition { get; set; } // Position of item on screen
    protected Vector2 ItemOrigin { get; set; } // Position to rotate
    public float rotation { get; set; } // Rotation of item
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public float opacity = 1.0f;
    public bool pickedUp = false;
    protected float cooldown;
    protected float cooldownLeft = 0;

    public SpriteEffects spriteEffect = SpriteEffects.None;

    public Item(Vector2 position, string name, string type, string rarity)
    {
        this.ItemPosition = position;
        LoadContent();
        Name = name;
        Type = type;
        Rarity = rarity;
        cooldown = 0.5f;
    }

    public Texture2D getTexture()
    {
        return ItemSprite;
    }
    public virtual Rectangle ItemPositionRectangle // Create hitbox for item
    {
        get
        {
            int x, y, w, h;
            if (rotation != 0)
            {
                var cos = Math.Abs(Math.Cos(rotation));
                var sin = Math.Abs(Math.Sin(rotation));
                var t1_opp = ItemSprite.Width * cos;
                var t1_adj = Math.Sqrt(Math.Pow(ItemSprite.Width, 2) - Math.Pow(t1_opp, 2));
                var t2_opp = ItemSprite.Height * sin;
                var t2_adj = Math.Sqrt(Math.Pow(ItemSprite.Height, 2) - Math.Pow(t2_opp, 2));

                w = (int)(t1_opp + t2_opp);
                h = (int)(t1_adj + t2_adj);
                x = (int)(ItemPosition.X - (w / 2));
                y = (int)(ItemPosition.Y - (h / 2));
            }
            else
            {
                x = (int)ItemPosition.X;
                y = (int)ItemPosition.Y;
                w = ItemSprite.Width;
                h = ItemSprite.Height;
            }
            return new Rectangle(x, y, w, h);
        }
    }
    public virtual void LoadContent(){ // Load item sprite and postition at characters hand area 
        // Default sprite load for item is fist
        ItemSprite = Globals.Content.Load<Texture2D>("Fist");
    }

    public void Draw()
    {
        
        Globals._spriteBatch.Draw(
            ItemSprite,
            ItemPosition,
            null,
            Color.White * opacity,
            rotation,
            ItemOrigin,
            1f,
            spriteEffect,
            0f
        );
    }

    public virtual void Use()
    {
    }

    public void setPosition(Vector2 newPos)
    {
        ItemPosition = newPos;
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

    public void mousePosition(Vector2 mousePosition){
        Vector2 dPos = ItemPosition - mousePosition;
        rotation = (float)Math.Atan2(dPos.Y, dPos.X);
        
        if(ItemPosition.X + ItemSprite.Width/2 < mousePosition.X)
        {
            spriteEffect = SpriteEffects.None;
        }
        else if(ItemPosition.X + ItemSprite.Width/2 > mousePosition.X)
        {
            spriteEffect = SpriteEffects.FlipVertically;
        }
    }

    public void Update(Vector2 pos){
		ItemPosition = pos;
        ItemOrigin = new Vector2(ItemSprite.Width, ItemSprite.Height / 2f);

        if (cooldownLeft > 0)
        {
            cooldownLeft -= Globals.totalSeconds;
        }
        
        if (InputManager.LeftDown){
            Use();
        }
	}
}

