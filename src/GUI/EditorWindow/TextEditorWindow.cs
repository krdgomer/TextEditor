using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.GUI;
using TextBox = TextEditor.GUI.TextBox;

namespace TextEditor.src.GUI.EditorWindow
{
    internal class TextEditorWindow
    {
        TextBox TextEditorTextBox;
        Menubar MenuBar;

        public TextEditorWindow() 
        {
            TextEditorTextBox = new TextBox();
            MenuBar = new Menubar(TextEditorTextBox);
        }

        public void Update()
        {
            TextEditorTextBox.Update();
            MenuBar.Update();
        }
        public void Draw()
        {
            TextEditorTextBox.Draw();
            MenuBar.Draw();
            
            
        }
        public void Unload()
        {
            TextEditorTextBox.Unload();
        }
    }
}
