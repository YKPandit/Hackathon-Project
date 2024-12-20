// Manages inputs from user

namespace New_AWS_Project;

public static class InputManager{
    public static MouseState _currentMouseState;
    public static KeyboardState _currentKeyboardState;
    public static MouseState _previousMouseState;
    public static KeyboardState _previousKeyboardState;
    public static Vector2 MousePosition => Vector2.Transform(Mouse.GetState().Position.ToVector2(), Matrix.Invert(Globals._screenScaleMatrix));
    public static Vector2 Direction;

    public static void Update(){
        _previousMouseState = _currentMouseState;
        _previousKeyboardState = _currentKeyboardState;
        
        _currentMouseState = Mouse.GetState();
        _currentKeyboardState = Keyboard.GetState();


        Direction = Vector2.Zero;
        if (_currentKeyboardState.IsKeyDown(Keys.W)) Direction.Y--;
        if (_currentKeyboardState.IsKeyDown(Keys.S)) Direction.Y++;
        if (_currentKeyboardState.IsKeyDown(Keys.A)) Direction.X--;
        if (_currentKeyboardState.IsKeyDown(Keys.D)) Direction.X++;

    }
}