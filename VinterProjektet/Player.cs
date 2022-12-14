public class Player : Entety
{
    //POSITION
    //BILD
    //MOVEMENT
    
    //Animations
    private int[] aDownStop = {1};
    private int[] aDown = {0,1,2,1};
    private int[] aLeftStop = {13};
    private int[] aLeft = {12,13,14,13};
    private int[] aRightStop = {25};
    private int[] aRight = {24,25,26,25};
    private int[] aUpStop = {37};
    private int[] aUp = {36,37,38,37};

    private int animIndex = 0;
    private bool isMoving = false;
    
    public Player()
    {
        //Set Player and Animation Speed
        Speed = 5f;
        animSpeed = 0.12f;

        //Load player Animations
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aDownStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aDown, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aLeftStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aLeft, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aRightStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aRight, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aUpStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aUp, 12, animSpeed));

        //Set Starting Animation
        currentAnimation = animations[animIndex];

        //Set player rectangle to keep track of position and collision
        rect = new Rectangle(480, 480, 32*3, 32*3);
    }

    //Every frame
    public void Update()
    {
        //Reset Vector2
        movement = Vector2.Zero;

        //Controlls
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {movement.Y = 1; animIndex = 1; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {movement.X = -1; animIndex = 3; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {movement.X = 1; animIndex = 5; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {movement.Y = -1; animIndex = 7; isMoving = true;}

        //Normalize Vector2 if not 0. 0 breaks the code.
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * Speed;
        }

        //Add Vector2 to Player position
        //If new position is outside the playable area, push the Player back in
        rect.x += movement.X;
        if (!Raylib.CheckCollisionRecs(rect, Map.Col)) rect.x -= movement.X;
        rect.y += movement.Y;
        if (!Raylib.CheckCollisionRecs(rect, Map.Col)) rect.y -= movement.Y;
        
        //Change animation state
        if (isMoving) currentAnimation = animations[animIndex];
        else if (!isMoving && animIndex % 2 != 0) {animIndex--; currentAnimation = animations[animIndex];}
        isMoving = false;
    }

    //Draw to screen
    public void Draw()
    {
        currentAnimation.Draw(this);
    }
}
