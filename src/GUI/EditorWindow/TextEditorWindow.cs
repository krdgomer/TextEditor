using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.GUI;

namespace TextEditor.src.GUI.EditorWindow
{
    internal class TextEditorWindow
    {
        TextBox TextEditorTextBox = new TextBox();
        Menubar MenuBar = new Menubar();

        public void Update()
        {
            TextEditorTextBox.Update();
            MenuBar.Update();
        }
        public void Draw()
        {
            MenuBar.Draw();
            TextEditorTextBox.Draw();
            
        }
        public void Unload()
        {
            TextEditorTextBox.Unload();
        }
    }
}
