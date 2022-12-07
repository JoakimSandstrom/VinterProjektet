public class Map
{
    //Load texture to memory
    static Texture2D tx = Raylib.LoadTexture("Sprites/Map.png");
    public static Rectangle Col { get; private set; } = new Rectangle(128,176,Map.tx.width*3-256,Map.tx.height*3-320);
    
    //Draw Texture on screen
    public static void Draw()
    {
        Raylib.DrawTextureEx(tx, Vector2.Zero, 0, 3, Color.WHITE);
    }

}
