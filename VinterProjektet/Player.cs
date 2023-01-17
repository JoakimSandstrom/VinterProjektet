public class Player : Entety
{
    //Animations
    private int frameSize = 32;
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
    private float timer;


    
    public Player()
    {
        //Set Player stats
        Speed = 5f;
        Str = 1;

        //Set player rectangles to keep track of position, collistion and attacking
        animRect = new Rectangle(480, 480, 32*scale, 32*scale);
        attackBox = new Rectangle(animRect.x+24, animRect.y+24, 32*scale, 32*scale);
        hitBox = new Rectangle(animRect.x+30,animRect.y+12,12*scale,16*scale);
        

        //Load player Animations
        animations.Add("aDownStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aDownStop, 12, animSpeed, false));
        animations.Add("aDown", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aDown, 12, animSpeed, false));
        animations.Add("aLeftStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aLeftStop, 12, animSpeed, false));
        animations.Add("aLeft", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aLeft, 12, animSpeed, false));
        animations.Add("aRightStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aRightStop, 12, animSpeed, false));
        animations.Add("aRight", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aRight, 12, animSpeed, false));
        animations.Add("aUpStop", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aUpStop, 12, animSpeed, false));
        animations.Add("aUp", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aUp, 12, animSpeed, false));
        animations.Add("aDownAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aDownAttack, 12, animSpeed/2, false));
        animations.Add("aLeftAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aLeftAttack, 12, animSpeed/2, false));
        animations.Add("aRightAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aRightAttack, 12, animSpeed/2, false));
        animations.Add("aUpAttack", new Animation("Sprites/dungeon-pack-free_version/sprite/free_character_0.png", frameSize, aUpAttack, 12, animSpeed/2, false));

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
    }

    //Every frame
    public void Update()
    {
        //Update timer
        if (timer > 0) {timer -= Raylib.GetFrameTime(); return;}
        
        //Reset Vector2
        movement = Vector2.Zero;

    //**Controlls**
        //Attack controlls and method
        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
        {
            //Change current animation to an attack animation
            if (animIndex.Contains("Stop")) animIndex = animIndex.Substring(0,animIndex.LastIndexOf("Stop"));
            currentAnimation = animations[animIndex+"Attack"];
            timer = animSpeed*1.5f;
            Attack();
            //Return to stop moving when attacking
            return;
        }

        //Movement controlls
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {movement.Y = 1; animIndex = "aDown"; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {movement.X = -1; animIndex = "aLeft"; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {movement.X = 1; animIndex = "aRight"; isMoving = true;}
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {movement.Y = -1; animIndex = "aUp"; isMoving = true;}

        //Normalize Vector2 if not 0 which would break the code.
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * Speed;
        }

        //Add Vector2 to Player position
        //If new position is outside the playable area, push the Player back in
        animRect.x += movement.X;
        if (!Raylib.CheckCollisionRecs(animRect, Map.Col)) animRect.x -= movement.X;
        animRect.y += movement.Y;
        if (!Raylib.CheckCollisionRecs(animRect, Map.Col)) animRect.y -= movement.Y;
        //Change animation state
        if (isMoving) currentAnimation = animations[animIndex];
        else if (!isMoving && (animIndex == "aDown" || animIndex == "aLeft" || animIndex == "aRight" || animIndex == "aUp")) 
            {currentAnimation = currentAnimation.next;}
        isMoving = false;

        hitBox.x = animRect.x+30;
        hitBox.y = animRect.y+12;
    }

    //Deal damage to enemies within range of attack
    public void Attack()
    {
        
    }

    //Draw to screen
    public void Draw()
    {
        Raylib.DrawRectangleRec(hitBox, Color.DARKBLUE);
        currentAnimation.Draw(this);
        
    }
}
