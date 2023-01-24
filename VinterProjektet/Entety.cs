public class Entety
{
    public string name = "bob";

    //Raylib variables
    //public Rectangle source;
    protected Vector2 movement = new();
    protected int scale = Map.scale;

    //Hitbox
    public Rectangle attackBox;
    public Rectangle animRect;
    public Rectangle hitBox;

    //Stats
    public float Speed {get; protected set;}
    public int Health {get; protected set;}
    public int Str {get; protected set;}
    public float InvFrame {get; protected set;}
    public bool Dead {get; set;} = false;

    //Animation dictionary and variables
    protected Dictionary<string, Animation> animations = new();
    protected Animation currentAnimation;
    protected string animIndex = "aDownStop";
    protected bool isMoving = false;
    protected float animSpeed = 0.12f;
    public bool changedAnim = false;
}

