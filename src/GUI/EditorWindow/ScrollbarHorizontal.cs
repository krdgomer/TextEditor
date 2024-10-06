using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.src.GUI.EditorWindow
{
    internal class ScrollbarHorizontal
    {
        public Rectangle ScrollbarRec {  get; set; } 
        public float ScrollOffsetX { get; set; }
        public bool EnableScrolling { get; set; }
        private bool IsDragging { get; set; }
        private Vector2 PreviousMousePosition { get; set; }

        public ScrollbarHorizontal(float textWidth,float textBoxWidth,float textBoxHeight ,float textBoxX,float textBoxY)
        {
            
            
            float scrollbarWidth = textBoxWidth * (textBoxWidth / textWidth);
            float scrollbarX = textBoxX + (ScrollOffsetX / textWidth) * textBoxWidth;
            ScrollbarRec = new Rectangle(scrollbarX, textBoxY + textBoxHeight, scrollbarWidth, 10);
            ScrollOffsetX = 0;
            EnableScrolling = false;
        }
        public void Update(float textWidth,float textBoxWidth)
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
                        float deltaX = mousePosition.X - PreviousMousePosition.X;
                        ScrollOffsetX += (int)(deltaX * (textWidth / textBoxWidth));
                        ScrollOffsetX = Math.Clamp(ScrollOffsetX, 0, (int)(textWidth - textBoxWidth));
                        PreviousMousePosition = mousePosition;
                    }
                }
           
            }
        }
        public void Draw(float textWidth,float textBoxWidth,float textBoxHeight,float textBoxX,float textBoxY)
        {
            float scrollbarWidth = textBoxWidth * (textBoxWidth / textWidth);
            float scrollbarX = textBoxX + (ScrollOffsetX / textWidth) * textBoxWidth;
            Raylib.DrawRectangle((int)scrollbarX, (int)textBoxY + (int)textBoxHeight, (int)scrollbarWidth, 10, Color.DarkGray);
        }
    }

        
}
