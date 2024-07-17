using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.src.Class
{
    internal class Text
    {
        public string text { get; set; }
        public List<int> LineStartIndexes { get; set; } = new List<int>();
        public List<string> StringLines { get; set; } = new List<string>();

        public Text(string _text) 
        {
            text = _text;
            ProcessText();
        }
        public void ProcessText() 
        {
            string cloneText = text;
            while(cloneText.Contains("\n"))
            {
                int i = cloneText.IndexOf("\n");
                LineStartIndexes.Add(i);
                StringLines.Add(cloneText.Substring(0, i));
                cloneText = cloneText.Substring(i + 1);
            }
            StringLines.Add(cloneText);
            
        }
        public void RemoveChar()
        {
            if (StringLines.Last() == "")
            {
                StringLines.RemoveAt(StringLines.Count - 1);
            }
            else
            {
                string lastString = StringLines.Last();
                lastString = lastString.Substring(0, lastString.Length - 1);
                StringLines[StringLines.Count - 1] = lastString;
            }
            text = text.Substring(0, text.Length - 1);
        }

        public void AddChar(int key)
        {
            string lastString = StringLines.Last();
            lastString += (char)key;
            StringLines[StringLines.Count - 1] = lastString;
            text += (char)key;
        }
        public void NewLine()
        {
            StringLines.Add("");
            text += "\n";
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
    }
}
