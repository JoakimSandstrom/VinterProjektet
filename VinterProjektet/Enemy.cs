public class Enemy: Entety
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

    public Enemy()
    {
        //Set Enemy and Animation Speed
        Speed = 3f;
        animSpeed = 0.12f;

        //Load player Animations
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aDownStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aDown, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aLeftStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aLeft, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aRightStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aRight, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aUpStop, 12, animSpeed));
        animations.Add(new Animation("Sprites/dungeon-pack-free_version/sprite/free_monsters_0.png", 48, aUp, 12, animSpeed));

        //Set Starting Animation
        currentAnimation = animations[animIndex];

        //Set Enemy rectangle to keep track of position and collision
        rect = new Rectangle(300, 300, 32*3, 32*3);
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

        //Add Vector2 to Enemy position
        rect.x += movement.X;
        rect.y += movement.Y;
    }

    //Draw to screen
    public void Draw()
    {
        currentAnimation.Draw(this);
    }
}

