global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(960, 960, "Världens sämsta spel");
Raylib.SetTargetFPS(60);

Player p = new Player();
Enemy e = new Enemy();

while(!Raylib.WindowShouldClose())
{
    //LOGIK
    p.Update();
    e.Update(p);
    
    //GRAFIK
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    Map.Draw();
    p.Draw();
    //e.Draw();


    Raylib.EndDrawing();
}