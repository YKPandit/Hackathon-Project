// File to manage data for each room, also represents a room object

namespace New_AWS_Project;

public static class RoomManager
{
    public static List<Item> _items {get;} = new();

    public static void AddItem(Item item){
        _items.Add(item);
        item.UpdateItemPositionRectangle();
    }

    public static void Update(Player player){
        if (!player.inventory.attacking){
            foreach(Item item in _items){
                if(player.PositionRectangle.Intersects(item.ItemPositionRectangle) && !player.inventory.inventoryFull && InputManager._currentKeyboardState.IsKeyDown(Keys.Q) && !InputManager._previousKeyboardState.IsKeyDown(Keys.Q))
                {
                    player.pickUp(item);
                    _items.Remove(item);
                    break;
                }
            }
        }
    }

    public static void Draw(){
        foreach(Item item in _items){
            item.Draw();
        }
    }
}
