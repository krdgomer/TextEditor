using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using TextEditor.src.Class;

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
        private float ScrollOffsetX { get; set; }
        private float ScrollOffsetY { get; set; }
        public float FontSize { get; set; }
        public float FontSpacing { get; set; }
        public int count { get; set; }
        public TextBox()
        {
            Width = 800;
            Height = 450;
            TextBoxText = new Text("Lorem\nipsum\ndolor\nsit\namet");
            TextFont = Raylib.LoadFont("D:/nyquil/dev/csharp/TextEditor/src/media/fonts/arial.ttf");
            MaxTextLength = 1024;
            TextBoxRec = new Rectangle(0, 0, Width, Height);
            ScrollOffsetX = 0;
            ScrollOffsetY = 0;
            FontSize = 20;
            FontSpacing = 1;
            count = 0;
        }
        public void Update()
        {
            int key = Raylib.GetCharPressed();
            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                TextBoxText.NewLine();
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Tab))
            {
                TextBoxText.StringLines[^1] += "    ";
                TextBoxText.text += "    ";
            }
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

            if (Raylib.IsKeyDown(KeyboardKey.Backspace) && !TextBoxText.checkEmpty())
            {
                if(count > 10)
                {
                    TextBoxText.RemoveChar();
                    count = 0;
                }
                else
                {
                    count++;
                }
                

            }



            if (Raylib.IsKeyPressed(KeyboardKey.F2))
            {
                File.WriteAllText("filename.cpp", TextBoxText.text);
            }

            //// Handle horizontal scrolling
            //float textWidth = Raylib.MeasureTextEx(TextFont, TextBoxText, FontSize, FontSpacing).X;
            //if (textWidth > TextBoxRec.Width)
            //{
            //    float wheelMove = Raylib.GetMouseWheelMove();
            //    if (wheelMove != 0)
            //    {
            //        ScrollOffsetX -= wheelMove * 20; // Adjust scroll speed
            //        ScrollOffsetX = Math.Clamp(ScrollOffsetX, 0, (int)(textWidth - TextBoxRec.Width));
            //    }
            //}
            //float textHeight = Raylib.MeasureTextEx(TextFont, Text, FontSize, FontSpacing).Y;
            //if (textHeight > TextBoxRec.Height)
            //{
            //    float wheelMove = Raylib.GetMouseWheelMove();
            //    if (wheelMove != 0)
            //    {
            //        ScrollOffsetY -= wheelMove * 20; // Adjust scroll speed
            //        ScrollOffsetY = Math.Clamp(ScrollOffsetY, 0, (int)(textHeight - TextBoxRec.Height));
            //    }
            //}
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(TextBoxRec, Color.White);

            //// Create a scissor area for the text box to clip text drawing
            //Raylib.BeginScissorMode((int)TextBoxRec.X, (int)TextBoxRec.Y, (int)TextBoxRec.Width, (int)TextBoxRec.Height);
            //Raylib.DrawTextEx(TextFont, Text, new Vector2(0 - ScrollOffsetX, 0 -ScrollOffsetY), FontSize, FontSpacing, Color.Black);
            //Raylib.EndScissorMode();

            //// Draw scrollbar if text exceeds the width of the text box
            //float textWidth = Raylib.MeasureTextEx(TextFont, Text, FontSize, FontSpacing).X;

            //if (textWidth > TextBoxRec.Width)
            //{
            //    float scrollbarWidth = TextBoxRec.Width * (TextBoxRec.Width / textWidth);
            //    float scrollbarX = TextBoxRec.X + (ScrollOffsetX / textWidth) * TextBoxRec.Width;

            //    Raylib.DrawRectangle((int)scrollbarX, (int)TextBoxRec.Y + (int)TextBoxRec.Height - 10, (int)scrollbarWidth, 10, Color.DarkGray);
            //}

            //// Draw scrollbar if text exceeds the height of the text box
            //float textHeight = Raylib.MeasureTextEx(TextFont, Text, FontSize, FontSpacing).Y;
            //Console.WriteLine(textHeight);
            //if (textHeight > TextBoxRec.Height)
            //{
            //    float scrollbarHeight = TextBoxRec.Height * (TextBoxRec.Height / textHeight);
            //    float scrollbarY = TextBoxRec.Y + (ScrollOffsetY / textHeight) * TextBoxRec.Height;

            //    Raylib.DrawRectangle((int)TextBoxRec.X + (int)TextBoxRec.Width - 10, (int)scrollbarY, 10, (int)scrollbarHeight, Color.DarkGray);
            //}

            //Raylib.DrawRectangleV(Raylib.MeasureTextEx(TextFont, Text, FontSize, FontSpacing), new Vector2(2,2), Color.Red);
            for(int i = 0; i < TextBoxText.StringLines.Count(); i++) 
            {
                Console.WriteLine(TextBoxText.StringLines[i]);
                Raylib.DrawTextEx(TextFont, TextBoxText.StringLines[i], new Vector2(0,i*FontSize), FontSize, FontSpacing, Color.Black);
            }
            float lastLineLength = Raylib.MeasureTextEx(TextFont, TextBoxText.StringLines.Last(), FontSize, FontSpacing).X;
            Raylib.DrawLineEx(new Vector2(lastLineLength + 3, TextBoxText.StringLines.Count() * FontSize),
                            new Vector2(lastLineLength + 3, (TextBoxText.StringLines.Count()-1)*FontSize),
                            3,Color.Black);

        }

        public void Unload()
        {
            Raylib.UnloadFont(TextFont);
        }
    }
}
