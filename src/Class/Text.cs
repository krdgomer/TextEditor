using Microsoft.VisualBasic;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.src.Class
{
    internal class Text
    {
        public string text { get; set; }
        public int indexX { get; set; } = 0;
        public int indexY { get; set; } = 0;
        public List<string> StringLines { get; set; } = new List<string>();

        public Text(string _text) 
        {
            text = _text;
            ProcessText();
            indexY = StringLines.Count -1 ;
            indexX = StringLines[^1].Length;
            
        }
        public void ProcessText() 
        {
            string cloneText = text;
            while(cloneText.Contains("\n"))
            {
                int i = cloneText.IndexOf("\n");
                StringLines.Add(cloneText.Substring(0, i));
                cloneText = cloneText.Substring(i + 1);
            }
            StringLines.Add(cloneText);
            
        }
        public void RemoveChar()
        {
            
            if (indexX==0&&indexY!=0)
            {
                

                StringLines[indexY - 1] += StringLines[indexY];
                StringLines.RemoveAt(indexY);
                indexY -=1;
                indexX = StringLines[indexY].Length;
            }
            else if(indexX == 0 && indexY == 0)
            {

            }
            else
            {
                string lastString = StringLines[indexY];
                lastString = lastString.Remove(indexX-1 , 1);
                StringLines[indexY] = lastString;
                indexX -= 1; 
            }
            
        }

        public void AddChar(int key)
        {
            string lastString = StringLines[indexY];
            lastString = lastString.Insert(indexX, ((char)key).ToString());
            StringLines[indexY] = lastString;
            indexX+=1;
        }
        public void NewLine()
        {
            if (indexX == 0)
            {
                StringLines.Insert(indexY + 1, StringLines[indexY]);
                StringLines[indexY] = "";
                indexX = 0;
                indexY += 1;
            }
            else
            {
                string newline = StringLines[indexY].Substring(indexX, StringLines[indexY].Length - indexX);
                StringLines[indexY] = StringLines[indexY].Substring(0, indexX);
                StringLines.Insert(indexY + 1, newline);
                indexX = 0;
                indexY += 1;
            }
            
        }
        public bool checkEmpty()
        {
            if(StringLines.Count == 1 && StringLines.Last() == "")
            {
   
                return true;
            }
            else
            {
                return false;
            }
        }
        public void checkKeys()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                NewLine();
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Tab))
            {
                string lastString = StringLines[indexY];
                lastString = lastString.Insert(indexX, "    ");
                StringLines[indexY] = lastString;
                indexX += 4;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                if (indexX==0)
                {
                    if (indexY != 0)
                    {
                        indexX = StringLines[indexY - 1].Length;
                        indexY -= 1;
                    }
                    
                }
                else
                {
                    indexX -= 1;
                }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                if (indexX == StringLines[indexY].Length)
                {
                    StringLines[indexY] += " ";
                    indexX += 1;
                }
                else
                {
                    indexX += 1;
                }
                      
            }
            if(Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                if(!(indexY==0))
                {
                    if (StringLines[indexY - 1].Length > indexX)
                    {
                        indexY -= 1;
                    }
                    else
                    {
                        indexY -= 1;
                        indexX = StringLines[indexY].Length;
                    }
                }
                
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                if(indexY < StringLines.Count-1)
                {
                    if (StringLines[indexY + 1].Length > indexX)
                    {
                        indexY += 1;
                    }
                    else
                    {
                        indexY += 1;
                        indexX = StringLines[indexY].Length;
                    }
                }
                
            }
        }
        public string getTextAtIndex()
        {
            
            if (indexX < StringLines[indexY].Length)
            {
                string textAtIndex = StringLines[indexY];
                textAtIndex = textAtIndex.Substring(0, indexX );
                return textAtIndex;
                
            }
            else
            {
         
                return StringLines[indexY];
                
            }
            
            
        }

        public string FindLongestString()
        {
            if (StringLines == null ||  StringLines.Count == 0)
            {
                return null;
            }

            string longest = StringLines[0];

            foreach (string str in StringLines)
            {
                if (str.Length > longest.Length)
                {
                    longest = str;
                }
            }

            return longest;
        }

        public float getTextWidth(Font font,float fontsize,float spacing)
        {
            return Raylib.MeasureTextEx(font, FindLongestString(), fontsize, spacing).X;
        }

        public float getTextHeight(float fontsize)
        {
            return StringLines.Count * fontsize;
        }



    }
}