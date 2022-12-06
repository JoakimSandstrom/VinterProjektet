public class Player : Entety
{

    //POSITION
    //BILD
    //MOVEMENT

    public Player()
    {
        Speed = 5f;

        sprite = Raylib.LoadTexture("Sprites/Snowman.png");
        rect = new Rectangle(480, 480, sprite.width, sprite.height);
    }
    public void Update()
    {
        //Reset Vector2
        movement = Vector2.Zero;

        //Controlls
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) movement.X = -1;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) movement.X = 1;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP)) movement.Y = -1;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) movement.Y = 1;

        //Normalize Vector2 if not 0. 0 breaks the code.
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * Speed;
        }

        //Add Vector2 to Player position
        rect.x += movement.X;
        rect.y += movement.Y;

        if (!Raylib.CheckCollisionRecs(rect, Map.Col))
        {
            rect.x -= movement.X;
            rect.y -= movement.Y;
        }
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
