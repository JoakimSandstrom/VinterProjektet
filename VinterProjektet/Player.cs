public class Player : Entety
{
    //POSITION
    //BILD
    //MOVEMENT
    
    

    public Player()
    {
        //Set Player speed
        Speed = 5f;

        //Set player Sprite variables
        sprite = Raylib.LoadTexture("Sprites/dungeon-pack-free_version/sprite/free_character_0.png");
        frameEnd = 2;

        //Set player sprite and rectangle to keep track of position and collision
        
        rect = new Rectangle(480, 480, frameSize*3, frameSize*3);
        

    }

    //Every frame
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
            //currentAnim = animations[2]
        }

        //Add Vector2 to Player position
        //If new position is outside the playable area, push the Player back in
        rect.x += movement.X;
        if (!Raylib.CheckCollisionRecs(rect, Map.Col)) rect.x -= movement.X;
        rect.y += movement.Y;
        if (!Raylib.CheckCollisionRecs(rect, Map.Col)) rect.y -= movement.Y;
    }

    
    public void Draw()
    {
        //currenAnim.Draw();
        
        // Raylib.DrawTexture
        // (
        //     sprite,
        //     (int)rect.x,
        //     (int)rect.y,
        //     Color.WHITE
        // );
    }
}
