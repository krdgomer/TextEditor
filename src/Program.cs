using System;
using System.Numerics;
using Raylib_cs;
using TextEditor.GUI;
using TextEditor.src.Class;
using TextEditor.src.GUI.EditorWindow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
        

            Raylib.InitWindow(Globals.WindowWidth, Globals.WindowHeight, "Nightshade Editor");

            TextEditorWindow textEditorWindow = new TextEditorWindow();

            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                // Update


                textEditorWindow.Update();
                

                // Draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                textEditorWindow.Draw();
                

                Raylib.EndDrawing();
            }
            textEditorWindow.Unload();

            Raylib.CloseWindow();
        }
    }
}
