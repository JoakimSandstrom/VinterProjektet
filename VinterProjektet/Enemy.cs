public class Enemy: Entety
{
    //POSITION
    //BILD
    //MOVEMENT

    //Stupid variables to calculate movement
    private float totalX;
    private float totalY;
    private bool xIsPos;
    private bool yIsPos;
    private float totalDistance;
    private float xFactor;
    private float yFactor;
    private float totalSqrt;

    public Enemy()
    {
        Speed = 4f;

        sprite = Raylib.LoadTexture("Sprites/Player.png");
        rect = new Rectangle(400, 400, sprite.width, sprite.height);
    }
    
    //This controlls the AI
    public void Update(Player p)
    {
        //Reset Vector2
        movement = Vector2.Zero;

        //Get the relative position of the player
        movement.X = p.rect.x - rect.x;
        movement.Y = p.rect.y - rect.y;

        //Normalize Vector2 if not 0. 0 breaks the code.
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * Speed;
        }

        //Add Vector2 to Player position
        rect.x += movement.X;
        rect.y += movement.Y;

    }

    public void Draw()
    {
        Raylib.DrawTexture
        (
            sprite,
            (int)rect.x,
            (int)rect.y,
            Color.WHITE
        );
    }
}
