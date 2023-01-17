public class Animation
{
    private string spriteSheetName;

    //Changing Variables
    private List<int> frame;
    private int frameSize;
    private int columnWidth;
    private int border = 0;

    //Set Variables
    private Rectangle source;
    private int frameIndex = 0;
    private int row = 0;

    public Animation next;

    //Timer
    private float timerMaxValue;
    private float timerCurrentValue;

    private Dictionary<string, Texture2D> spriteSheets = new();

    public Animation(string spriteSheetFile, int frameSize, int[] frame, int columnWidth, float timerMaxValue, bool border)
    {
        if (!spriteSheets.ContainsKey(spriteSheetFile))
        {
            spriteSheets.Add(spriteSheetFile, Raylib.LoadTexture(spriteSheetFile));
        }
        spriteSheetName = spriteSheetFile;

        this.frameSize = frameSize;
        this.columnWidth = columnWidth;
        this.frame = new List<int>(frame);

        if (border) this.border = frameSize / 3;

        this.timerMaxValue = timerMaxValue;
        timerCurrentValue = timerMaxValue;

        next = this;
    }

    //Draw the current frame of the animation
    public void Draw(Entety e)
    {
        if(frame[frameIndex] != 0) row = frame[frameIndex] / columnWidth;
        else row = 0;

        source = new Rectangle(((frame[frameIndex] % 12) * frameSize) + border, (row * frameSize) + border, frameSize - (border * 2), frameSize - (border*2));

        Raylib.DrawTexturePro(spriteSheets[spriteSheetName], source, e.animRect, Vector2.Zero, 0, Color.WHITE);

        timerCurrentValue -= Raylib.GetFrameTime();
        if (timerCurrentValue < 0)
        {
            timerCurrentValue = timerMaxValue;

            if (frameIndex == frame.Count - 1) frameIndex = 0;
            else frameIndex++;
        }
    }
}
