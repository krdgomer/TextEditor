using Raylib_cs;
using System.Numerics;

using TextEditor.src.Class;
using TextEditor.src.GUI.EditorWindow;

namespace TextEditor.GUI
{
    internal class TextBox
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Text TextBoxText { get; set; }
        public Font TextFont { get; set; }
        public int MaxTextLength { get; set; }
        public Rectangle TextBoxRec { get; set; }
        public float FontSize { get; set; }
        public float FontSpacing { get; set; }
        public ScrollbarHorizontal ScrollbarHorizontal { get; set; }
        public ScrollbarVertical ScrollbarVertical { get; set; }
        public TextBox()
        {
            
            TextBoxText = new Text("Lorem\nipsum\ndolor\nsit\namet");
            TextFont = Raylib.LoadFont("D:/nyquil/dev/csharp/TextEditor/src/media/fonts/arial.ttf");
            MaxTextLength = 1024;
            FontSize = 20;
            FontSpacing = 1;
            Width = Globals.WindowWidth - 10;
            Height = Globals.WindowHeight - Globals.MenubarHeight -10;
            TextBoxRec = new Rectangle(0, Globals.MenubarHeight, Width, Height);
            ScrollbarHorizontal = new ScrollbarHorizontal(TextBoxText.getTextWidth(TextFont,FontSize,FontSpacing),Width,Height,0,0);
            ScrollbarVertical = new ScrollbarVertical(TextBoxText.getTextHeight(FontSize), Width, Height, 0, 0);
            
            

        }
        public void Update()
        {
            int key = Raylib.GetCharPressed();

            TextBoxText.checkKeys();

            while (key > 0)
            {
            
                if ((key >= 32) && (key <= 125) && (TextBoxText.text.Length < MaxTextLength))
                {
                    TextBoxText.AddChar(key);
                }

                key = Raylib.GetCharPressed();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && !TextBoxText.checkEmpty())
            {
                TextBoxText.RemoveChar();
                
            }







            // Handle horizontal scrolling
            HandleScrolling();
            ScrollbarHorizontal.Update(TextBoxText.getTextWidth(TextFont,FontSize,FontSpacing),Width);
            ScrollbarVertical.Update(TextBoxText.getTextHeight(FontSize),Height);
            
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(TextBoxRec, Color.RayWhite);

            // Adjust for the menubar height
            float yOffset = Globals.MenubarHeight;

            // Create a scissor area for the text box to clip text drawing
            Raylib.BeginScissorMode((int)TextBoxRec.X, (int)TextBoxRec.Y, (int)TextBoxRec.Width, (int)TextBoxRec.Height);
            for (int i = 0; i < TextBoxText.StringLines.Count(); i++)
            {
                Raylib.DrawTextEx(TextFont, TextBoxText.StringLines[i],
                                  new Vector2(0 - ScrollbarHorizontal.ScrollOffsetX,
                                              (i * FontSize) - ScrollbarVertical.ScrollOffsetY + yOffset),
                                  FontSize, FontSpacing, Color.Black);
            }
            Raylib.EndScissorMode();

            ScrollbarHorizontal.Draw(TextBoxText.getTextWidth(TextFont, FontSize, FontSpacing), Width, Height, 0, Globals.MenubarHeight);
            ScrollbarVertical.Draw(TextBoxText.getTextHeight(FontSize), Width, Height, 0, 0);

            float lastLineLength = Raylib.MeasureTextEx(TextFont, TextBoxText.getTextAtIndex(), FontSize, FontSpacing).X;
            Raylib.DrawLineEx(new Vector2(lastLineLength + 3,
                                          (TextBoxText.indexY * FontSize) + yOffset),
                              new Vector2(lastLineLength + 3,
                                          ((TextBoxText.indexY + 1) * FontSize) + yOffset),
                              2, Color.Black);

        }

        public void Unload()
        {
            Raylib.UnloadFont(TextFont);
        }

        public void HandleScrolling()
        {
            float textWidth = TextBoxText.getTextWidth(TextFont,FontSize,FontSpacing);
            float textHeight = TextBoxText.getTextHeight(FontSize);
            if (textWidth > TextBoxRec.Width)
            {
                ScrollbarHorizontal.EnableScrolling = true;
            }
            else 
            {
                ScrollbarHorizontal.EnableScrolling = false;
            }
            
            if (textHeight > TextBoxRec.Height)
            {
                ScrollbarVertical.EnableScrolling = true;
            }
            else
            {
                ScrollbarVertical.EnableScrolling= false;
            }
        }
        
    }
}
