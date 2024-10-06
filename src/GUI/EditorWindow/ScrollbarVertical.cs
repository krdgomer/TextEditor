using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.src.GUI.EditorWindow
{
    
    internal class ScrollbarVertical
    {
        public Rectangle ScrollbarRec { get; set; }
        public float ScrollOffsetY { get; set; }
        public bool EnableScrolling { get; set; }
        private bool IsDragging { get; set; }
        private Vector2 PreviousMousePosition { get; set; }
        public ScrollbarVertical(float textHeight, float textBoxWidth, float textBoxHeight, float textBoxX, float textBoxY)
        {
            float scrollbarHeight = textBoxHeight * (textBoxHeight / textHeight);
            float scrollbarY = textBoxY + (ScrollOffsetY / textHeight) * textBoxHeight;
            ScrollbarRec = new Rectangle(textBoxX + textBoxWidth - 10, scrollbarY, 10, scrollbarHeight);
            ScrollOffsetY = 0;

        }
        public void Update(float textHeight,float textBoxHeight)
        {
            if (EnableScrolling)
            {
                float wheelMove = Raylib.GetMouseWheelMove();
                Vector2 mousePosition = Raylib.GetMousePosition();


                

                if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePosition, ScrollbarRec))
                {
                    IsDragging = true;
                    PreviousMousePosition = mousePosition;
                }

                if (IsDragging)
                {
                    if (Raylib.IsMouseButtonReleased(MouseButton.Left))
                    {
                        IsDragging = false;
                    }
                    else
                    {
                        float deltaY = mousePosition.Y - PreviousMousePosition.Y;
                        ScrollOffsetY += (int)(deltaY * (textHeight / textBoxHeight));
                        ScrollOffsetY = Math.Clamp(ScrollOffsetY, 0, (int)(textHeight - textBoxHeight));
                        PreviousMousePosition = mousePosition;
                    }
                }
                else
                {
                    if (wheelMove != 0)
                    {
                        ScrollOffsetY -= wheelMove * 20; // Adjust scroll speed
                        ScrollOffsetY = Math.Clamp(ScrollOffsetY, 0, (int)(textHeight - textHeight));
                        Console.WriteLine("AAAAA");
                    }
                }
            }
            
        }
        public void Draw(float textHeight, float textBoxWidth, float textBoxHeight, float textBoxX, float textBoxY) 
        {
            float scrollbarHeight = textBoxHeight * (textBoxHeight / textHeight);
            float scrollbarY = textBoxY + (ScrollOffsetY / textHeight) * textBoxHeight;
            Raylib.DrawRectangle((int)textBoxX + (int)textBoxWidth , (int)scrollbarY, 10, (int)scrollbarHeight, Color.DarkGray);
        }
    }
}
