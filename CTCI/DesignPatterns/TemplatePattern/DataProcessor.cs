using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.TemplatePattern
{
    public abstract class DataProcessor
    {
        public void ReadSaveFile()
        {
            ReadFile();
            ProcessFile();
            SaveFile();
        }

        public abstract void ReadFile();
        public abstract void ProcessFile();
        public void SaveFile()
        {
            Console.WriteLine("Save file");
        }
    }
}
