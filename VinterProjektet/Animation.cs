public class Animation
{
    private Texture2D sprite = Raylib.LoadTexture("Sprites/dungeon-pack-free_version/sprite/free_character_0.png");
    private Rectangle source;
    private int frameSize = 32;
    private int[] frame = {0,2};
    private int frameIndex = 0;
    private int frameStart = 0;
    private int frameEnd = 2;
    private int row = 0;
    private bool frameDrawn = false;

    private static System.Timers.Timer timer;

    public Animation()
    {
        timer = new System.Timers.Timer();
        timer.Interval = 300;

        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    public void Draw(Player p)
    {
        source = new Rectangle(frame[frameIndex] * frameSize, row * frameSize, frameSize, frameSize);

        Raylib.DrawTexturePro(sprite, source, p.rect, Vector2.Zero, 0, Color.WHITE);
        
        if (!frameDrawn)
        {
            
            if (frame[frameIndex] == frameEnd) frameIndex = frameStart;
            else frameIndex++;
        }
        frameDrawn = true;
    }
    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        frameDrawn = false;
    }
}
