using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.TemplatePattern
{
   public class TextFile : DataProcessor
    {
        //public void ReadSaveFile()
        //{
        //    ReadFile();
        //    ProcessFile();
        //    SaveFile();
        //}
        public override void ReadFile()
        {
            Console.WriteLine("Read from text file");
        }

        public override void ProcessFile()
        {
            Console.WriteLine("Process text file");
        }


        //public void SaveFile()
        //{
        //    Console.WriteLine("Save file");
        //}
    }
}
