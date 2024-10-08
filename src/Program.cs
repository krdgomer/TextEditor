using System;
using System.Numerics;
using Raylib_cs;
using TextEditor.GUI;
using TextEditor.src.Class;
using TextEditor.src.GUI.EditorWindow;
using static System.Runtime.InteropServices.JavaScript.JSType;
using rlImGui_cs;
using ImGuiNET;
using Color = Raylib_cs.Color;

namespace TextEditor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
        

            Raylib.InitWindow(Globals.WindowWidth, Globals.WindowHeight, "Nightshade Editor");

            TextEditorWindow textEditorWindow = new TextEditorWindow();

            Raylib.SetTargetFPS(60);
            
            rlImGui.Setup(true);



            while (!Raylib.WindowShouldClose())
            {

                // Update
                rlImGui.Begin();

                textEditorWindow.Update();
                

                // Draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                textEditorWindow.Draw();

                rlImGui.End();
                Raylib.EndDrawing();
            }
            textEditorWindow.Unload();
            rlImGui.Shutdown();
            Raylib.CloseWindow();
        }
    }
}
