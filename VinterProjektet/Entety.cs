public class Entety
{
    public string name = "bob";

    //Raylib variables
    public Rectangle rect;
    public Rectangle source;
    protected Vector2 movement = new();

    //Sprites
    protected float animSpeed = 0.12f;
    
    //Stats
    public float Speed {get; protected set;}
    public int Health {get; protected set;}
    public int Str {get; protected set;}

    // protected List<Animation> animations = new List<Animation>()
    protected Dictionary<string, Animation> animations = new();
    
    protected Animation currentAnimation;

    protected string animIndex = "aDownStop";
    protected bool isMoving = false;

}

