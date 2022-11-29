public class Entety
{
    public string name = "bob";

    //Raylib variables
    public Rectangle rect;
    protected Texture2D sprite;
    protected Vector2 movement = new();

    //Stats
    public float Speed {get; protected set;}
    public int Health { get; set; }
    public int Str { get; set; }

}

