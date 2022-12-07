public class Entety
{
    public string name = "bob";

    //Raylib variables
    public Rectangle rect;
    public Rectangle source;
    protected Vector2 movement = new();

    //Sprites
    protected Texture2D sprite;
    protected int frameSize = 32;
    protected int frame = 0;
    protected int frameStart = 0;
    protected int frameEnd;
    protected int row = 0;
    
    //Stats
    public float Speed {get; protected set;}
    public int Health {get; protected set;}
    public int Str {get; protected set;}

}

