public class Map
{
    //World scale. All textures are scaled by this.
    public static int scale = 3;

    //Load texture to memory
    static Texture2D tx = Raylib.LoadTexture("Sprites/Map.png");
    public static List<Rectangle> collision = new();

    public Map()
    {
        collision.Add(new Rectangle(0,0,Map.tx.width*scale,144));
        collision.Add(new Rectangle(0,0,96,Map.tx.height*scale));
        collision.Add(new Rectangle(Map.tx.width*scale-96,0,96,Map.tx.height*scale));
        collision.Add(new Rectangle(0,Map.tx.height*scale-96,Map.tx.width*scale,144));
        collision.Add(new Rectangle(240,240,48,48));
        collision.Add(new Rectangle(336,192,48,48));
        collision.Add(new Rectangle(576,192,48,48));
        collision.Add(new Rectangle(672,240,48,48));
        collision.Add(new Rectangle(192,720,48,48));
        collision.Add(new Rectangle(720,720,48,48));
    }

    //Draw Texture on screen
    public void Draw()
    {
        Raylib.DrawTextureEx(tx, Vector2.Zero, 0, scale, Color.WHITE);
        foreach (Rectangle r in collision)
        {
            //Raylib.DrawRectangleRec(r, Color.DARKBLUE);
        }
    }
}
