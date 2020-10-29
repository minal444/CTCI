using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.TemplatePattern
{
    public class ClientTemplete
    {
        public void Process()
        {
            ExcelFile obj = new ExcelFile();
            obj.ReadSaveFile();

            TextFile obj1 = new TextFile();
            obj1.ReadSaveFile();
        }
    }
}
