global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(960, 960, "Världens sämsta spel");
Raylib.SetTargetFPS(60);

Map map = new Map();

Player p = new Player();
Enemy e = new Enemy();

while(!Raylib.WindowShouldClose())
{
    //LOGIK
    p.Update(e);
    e.Update(p);
    
    //GRAFIK
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    map.Draw();
    p.Draw();
    e.Draw();


    Raylib.EndDrawing();
}