namespace New_AWS_Project;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;
    private GameManager GameManager;

    private Viewport _viewport;

    // Flags
    private bool _isResizing;

    public Game1()
    {
        Globals._graphics = new GraphicsDeviceManager(this);
        Globals._graphics.PreferredBackBufferWidth = Globals._resolutionWidth;
		Globals._graphics.PreferredBackBufferHeight = Globals._resolutionHeight;
		Globals._graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

		Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnClientSizeChanged;

        Globals.game1 = this;
    }
    private void OnClientSizeChanged(object sender, EventArgs e)
    {
        if (!_isResizing && Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
        {
            _isResizing = true;
            UpdateScreenScaleMatrix();
            _isResizing = false;
        }
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Globals.Content = Content;
        GameManager = new GameManager();

        UpdateScreenScaleMatrix();
        base.Initialize();
		
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals._spriteBatch = _spriteBatch;
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

        GraphicsDevice.Viewport = _viewport;

		Globals._spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Globals._screenScaleMatrix);
        GameManager.Draw();
    	Globals._spriteBatch.End();
        // TODO: Add your drawing code here
        base.Draw(gameTime);
    }
    
    private void UpdateScreenScaleMatrix()
    {
        // Size of actual screen
        float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
        float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

        // Calculate virtual resolution based on current screen width and height
        if (screenWidth/ Globals._resolutionWidth > screenHeight / Globals._resolutionHeight)
        {
            float aspect = screenHeight / Globals._resolutionHeight;
            Globals.screenWidth = (int)(aspect * Globals._resolutionWidth);
            Globals.screenHeight = (int)screenHeight;
        }
        else {
            float aspect = screenWidth / Globals._resolutionWidth;
            Globals.screenWidth = (int)screenWidth;
            Globals.screenHeight = (int)(aspect * Globals._resolutionHeight);
        }

        Globals._screenScaleMatrix = Matrix.CreateScale(Globals.screenWidth / (float)Globals._resolutionWidth, Globals.screenHeight / (float)Globals._resolutionHeight, 1.0f);

        _viewport = new Viewport{
            X = (int)(screenWidth / 2 - Globals.screenWidth / 2),
            Y = (int)(screenHeight / 2 - Globals.screenHeight / 2),
            Width = Globals.screenWidth,
            Height = Globals.screenHeight,
        };
    }
}
