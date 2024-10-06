using Raylib_cs;
using TextEditor.src.Class;

namespace TextEditor.src.GUI.EditorWindow
{
    internal class Menubar
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle MenubarRec { get; set; }

        public Menubar() 
        {
            Width = Globals.WindowWidth;
            Height = Globals.MenubarHeight;
            MenubarRec = new Rectangle(0, 0, Width, Height);
        }
        public void Update()
        {
            
        }
        public void Draw() 
        {
            Raylib.DrawRectangleRec(MenubarRec, Color.Blue);
        }


    }
}
