﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.src.GUI
{
    internal interface IGuiElement
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
