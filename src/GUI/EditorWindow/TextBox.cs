using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.GUI
{
    internal class TextBox
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        public Font TextFont { get; set; }
        public int MaxTextLength { get; set; }
        public Rectangle TextBoxRec { get; set; }
        private float ScrollOffset { get; set; }
        public float FontSize { get; set; }
        public float FontSpacing { get; set; }

        public TextBox()
        {
            Width = 800;
            Height = 450;
            Text = "";
            TextFont = Raylib.LoadFont("D:/nyquil/dev/csharp/TextEditor/src/media/fonts/arial.ttf");
            MaxTextLength = 1024;
            TextBoxRec = new Rectangle(0, 0, Width, Height);
            ScrollOffset = 0;
            FontSize = 20;
            FontSpacing = 1;
        }
        public void Update()
        {
            int key = Raylib.GetCharPressed();
            while (key > 0)
            {
                if ((key >= 32) && (key <= 125) && (Text.Length < MaxTextLength))
                {
                    Text += (char)key;                    
                }

                key = Raylib.GetCharPressed();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && Text.Length > 0)
            {
                Text = Text.Substring(0, Text.Length - 1);
            }



            // Handle scrolling
            float textHeight = Raylib.MeasureTextEx(TextFont, Text, 20, 1).Y;
            if (textHeight > TextBoxRec.Height)
            {
                float wheelMove = Raylib.GetMouseWheelMove();
                if (wheelMove != 0)
                {
                    ScrollOffset -= wheelMove * 20; // Adjust scroll speed
                    ScrollOffset = Math.Clamp(ScrollOffset, 0, (int)(textHeight - TextBoxRec.Height));
                }
            }
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(TextBoxRec, Color.LightGray);

            // Create a scissor area for the text box to clip text drawing
            Raylib.BeginScissorMode((int)TextBoxRec.X, (int)TextBoxRec.Y, (int)TextBoxRec.Width, (int)TextBoxRec.Height);
            Raylib.DrawTextEx(TextFont, Text, new Vector2(0, 0 - ScrollOffset), 20, 1, Color.Black);
            Raylib.EndScissorMode();

            // Draw scrollbar if text exceeds the height of the text box
            float textHeight = Raylib.MeasureTextEx(TextFont, Text, 20, 1).Y;
            if (textHeight > TextBoxRec.Height)
            {
                float scrollbarHeight = TextBoxRec.Height * (TextBoxRec.Height / textHeight);
                float scrollbarY = TextBoxRec.Y + (ScrollOffset / textHeight) * TextBoxRec.Height;

                Raylib.DrawRectangle((int)TextBoxRec.X + (int)TextBoxRec.Width - 10, (int)scrollbarY, 10, (int)scrollbarHeight, Color.DarkGray);
            }

        }

        public void Unload()
        {
            Raylib.UnloadFont(TextFont);
        }
    }
}
