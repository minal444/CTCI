using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.TemplatePattern
{
    public class ExcelFile :DataProcessor
    {
        //public void ReadSaveFile()
        //{
        //    ReadFile();
        //    ProcessFile();
        //    SaveFile();
        //}
        public override void ReadFile()
        {
            Console.WriteLine("Read from excel file");
        }

        public override void ProcessFile()
        {
            Console.WriteLine("Process excel file");
        }


        //public void SaveFile()
        //{
        //    Console.WriteLine("Save file");
        //}
    }
}
