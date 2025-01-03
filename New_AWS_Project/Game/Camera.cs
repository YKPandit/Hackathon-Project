using New_AWS_Project;

public class Camera
{
    private Vector2 position;
    public float zoom { get; private set; }
    private float rotation;
    private Viewport viewport;
    private float cameraTranslation;
    private Matrix matrix;

    public Camera(float cameraTranslation = 0f)
    {
        rotation = 0.0f;
        position = Vector2.Zero;
        zoom = 1.0f;

        viewport = new Viewport();
        // where is the Camera
        // 0 = left top
        // 0.5 = middle
        this.cameraTranslation = cameraTranslation;
        Update();
    }

    public void Update()
    {
        viewport = Globals._graphics.GraphicsDevice.Viewport;

        Matrix positionMatrix = Matrix.CreateTranslation(new Vector3(-position, 0.0f));
        Matrix rotationMatrix = Matrix.CreateRotationZ(rotation);
        Matrix scaleMatrix = Matrix.CreateScale(new Vector3(zoom, zoom, 1f));
        Matrix viewportTranslation = Matrix.CreateTranslation(new Vector3(viewport.Width * cameraTranslation, viewport.Height * cameraTranslation, 0.0f));

        matrix = positionMatrix * rotationMatrix * scaleMatrix * viewportTranslation;
    }


    public Matrix GetViewMatrix()
    {
        return matrix;
    }


    public void Zoom(float amount)
    {
        zoom += amount;
    }


    public void SetZoom(float amount)
    {
        zoom = amount;
    }

    public void Zoom(float amount, float min, float max)
    {
        zoom += amount;
        zoom = MathHelper.Clamp(zoom, min, max); //min/max zoom Level
    }


    public void Rotate(float amount)
    {
        rotation += amount;
    }


    public void Move(Vector2 amount)
    {
        // Convert the movement vector to world space
        position += Vector2.Transform(amount, Matrix.CreateRotationZ(-rotation));
    }

    public void MoveAfterRotation(Vector2 amount)
    {
        position += amount;
    }


    public Vector2 ScreenToWorld(Vector2 screenPosition)
    {
        return Vector2.Transform(screenPosition, Matrix.Invert(GetViewMatrix()));
    }


    public Vector2 WorldToScreen(Vector2 worldPosition)
    {
        return Vector2.Transform(worldPosition, GetViewMatrix());
    }
}