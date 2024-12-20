// Specific class to handle the sword weapon, child of Item

using New_AWS_Project;

public class Sword : Item
{
    // Constructor
    public Sword(Vector2 position, string name, string type, string rarity)
    : base(position, name, type, rarity){LoadContent();}

    public override void LoadContent(){ 
        // Load sword sprite
        base.ItemSprite = Globals.Content.Load<Texture2D>("3bbc0d500f6805b6e086d8f51ccd1870(1)");
    }

}

