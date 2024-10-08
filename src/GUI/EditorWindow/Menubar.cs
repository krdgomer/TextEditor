using Raylib_cs;
using TextEditor.src.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ImGuiNET;
using rlImGui_cs;
using System.Numerics;
using TextEditor.GUI;
using System.IO;
using Rectangle = Raylib_cs.Rectangle;
using Color = Raylib_cs.Color;
using TextBox = TextEditor.GUI.TextBox;


namespace TextEditor.src.GUI.EditorWindow
{
    internal class Menubar
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle MenubarRec { get; set; }

        public TextBox _textbox;
        

        public Menubar(TextBox textbox) 
        {
            Width = Globals.WindowWidth;
            Height = Globals.MenubarHeight;
            MenubarRec = new Rectangle(0, 0, Width, Height);
            _textbox = textbox;
        }
        public void Update()
        {
           
        }
        public void Draw() 
        {
            // Draw the background rectangle for the menubar
            Raylib.DrawRectangleRec(MenubarRec, Color.LightGray);
            ImGui.StyleColorsLight();
            // Start ImGui frame
            

            // Set custom style for the menu bar
            
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(10, 10));  // Adjust height

            // Create a menu bar
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New File")) { NewFile(); }
                    if (ImGui.MenuItem("Open")) { OpenFile(); }
                    if (ImGui.MenuItem("Save")) { SaveFile(); }
                    if (ImGui.MenuItem("Exit")) { /* Handle Exit */ }
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Fileee"))
                {
                    if (ImGui.MenuItem("Open")) { /* Handle Open */ }
                    if (ImGui.MenuItem("Save")) { /* Handle Save */ }
                    if (ImGui.MenuItem("Exit")) { /* Handle Exit */ }
                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }

            // Revert styles to the default after rendering the menu bar
            ImGui.PopStyleVar();  // Revert height
            ImGui.PopStyleColor(2);  // Revert both color changes (text and background)



        }
        private void NewFile()
        {
            _textbox.TextBoxText = new Text("");
            
        }
        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    // Read the contents of the file
                    string fileContents = File.ReadAllText(filePath);

                    // Set the text in your TextBox
                    _textbox.TextBoxText = new Text(fileContents);
                    
                }
            }
        }

        private void SaveFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Set your filter
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Write the text from your TextBox to the file
                    string filePath = saveFileDialog.FileName;

                    File.WriteAllText(filePath, _textbox.TextBoxText.GetString()); // Make sure you implement GetText method
                }
            }
        }


    }
}
