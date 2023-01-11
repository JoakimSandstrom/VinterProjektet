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
    private int[] aDownAttack = {3,4,5};
    private int[] aLeftAttack = {15,16,17};
    private int[] aRightAttack = {27,28,29};
    private int[] aUpAttack = {39,40,41};

    //Timer
    //private float timerMaxValue;
    //private float timerCurrentValue;
    private float timer;
    
    public Player()
    {
        //Set Player and Animation Speed
        Speed = 5f;
        animSpeed = 0.12f;

        

        //Load player Animations
        animations.Add("aDownStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aDownStop, 12, animSpeed, false));
        animations.Add("aDown", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aDown, 12, animSpeed, false));
        animations.Add("aLeftStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aLeftStop, 12, animSpeed, false));
        animations.Add("aLeft", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aLeft, 12, animSpeed, false));
        animations.Add("aRightStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aRightStop, 12, animSpeed, false));
        animations.Add("aRight", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aRight, 12, animSpeed, false));
        animations.Add("aUpStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aUpStop, 12, animSpeed, false));
        animations.Add("aUp", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aUp, 12, animSpeed, false));
        animations.Add("aDownAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aDownAttack, 12, animSpeed, false));
        animations.Add("aLeftAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aLeftAttack, 12, animSpeed, false));
        animations.Add("aRightAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aRightAttack, 12, animSpeed, false));
        animations.Add("aUpAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", 32, aUpAttack, 12, animSpeed, false));

        //Set Next Animation
        animations["aDown"].next = animations["aDownStop"];
        animations["aLeft"].next = animations["aLeftStop"];
        animations["aRight"].next = animations["aRightStop"];
        animations["aUp"].next = animations["aUpStop"];
        animations["aDownAttack"].next = animations["aDownStop"];
        animations["aLeftAttack"].next = animations["aLeftStop"];
        animations["aRightAttack"].next = animations["aRightStop"];
        animations["aUpAttack"].next = animations["aUpStop"];

        //Set Starting Animation
        currentAnimation = animations["aDownStop"];

        //Set player rectangle to keep track of position and collision
        rect = new Rectangle(480, 480, 32*3, 32*3);
    }

    //Every frame
    public void Update()
    {
        if (timer > 0) {timer -= Raylib.GetFrameTime(); return;}
        //Reset Vector2
        movement = Vector2.Zero;

        //Controlls
        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Attack();
            return;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {movement.Y = 1; animIndex = "aDown"; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {movement.X = -1; animIndex = "aLeft"; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {movement.X = 1; animIndex = "aRight"; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {movement.Y = -1; animIndex = "aUp"; isMoving = true;}

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
        else if (!isMoving && (animIndex == "aDown" || animIndex == "aLeft" || animIndex == "aRight" || animIndex == "aUp")) 
            {currentAnimation = currentAnimation.next;}
        isMoving = false;
    }

    public void Attack()
    {
        if (animIndex.Contains("Stop")) animIndex = animIndex.Substring(0,animIndex.LastIndexOf("Stop"));
        currentAnimation = animations[animIndex+"Attack"];
        timer = animSpeed*3;
    }

    //Draw to screen
    public void Draw()
    {
        //Raylib.DrawRectangleRec(rect, Color.DARKBLUE);
        currentAnimation.Draw(this);
        
    }
}
