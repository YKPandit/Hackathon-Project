namespace New_AWS_Project;

public class Game1 : Game
{
    private GameManager GameManager;
    private float scale;

    // Flags
    private bool _isResizing;

    public Game1()
    {
        Globals._graphics = new GraphicsDeviceManager(this);
        Globals._graphics.PreferredBackBufferWidth = (int) Globals._resolution.X;
		Globals._graphics.PreferredBackBufferHeight = (int) Globals._resolution.Y;

		Globals._graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Globals._camera = new Camera();

		Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnClientSizeChanged;

        Globals.game1 = this;
    }
    private void OnClientSizeChanged(object sender, EventArgs e)
    {
        if (!_isResizing && Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
        {
            _isResizing = true;
            Globals._screenSize = new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight);
            scale = Math.Min(Globals._screenSize.X / Globals._resolution.X, Globals._screenSize.Y / Globals._resolution.Y);
            Globals._camera.SetZoom(scale); // to get the zoom 
            Globals._camera.Update(); // to create the matrix 
            _isResizing = false;
        }
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Globals.Content = Content;
        GameManager = new GameManager();

        Globals._screenSize = new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight);
        scale = Math.Min(Globals._screenSize.X / Globals._resolution.X, Globals._screenSize.Y / Globals._resolution.Y);
        Globals._camera.SetZoom(scale); // to get the zoom 
        Globals._camera.Update(); // to create the matrix 
        
        base.Initialize();
		
    }

    protected override void LoadContent()
    {

        Globals._spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        Globals.Update(gameTime);
        GameManager.Update();
        
        base.Update(gameTime);

    }
    

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

		Globals._spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Globals._camera.GetViewMatrix());
        GameManager.Draw();
    	Globals._spriteBatch.End();
        // TODO: Add your drawing code here
        base.Draw(gameTime);
    }
}
