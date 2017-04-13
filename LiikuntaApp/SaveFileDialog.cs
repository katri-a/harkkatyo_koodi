using System;
using Microsoft.Win32.SafeHandles;

namespace LiikuntaApp
{
    internal class SaveFileDialog
    {
        public SaveFileDialog()
        {
        }

        public SafeFileHandle FileName { get; internal set; }
        public bool RestoreDirectory { get; internal set; }

        internal object ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}