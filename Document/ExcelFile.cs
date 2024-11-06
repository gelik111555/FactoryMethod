using FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Document;

public class ExcelFile : IDocument
{
    public void Open() => Console.WriteLine("Opening Excel document...");
    public void Edit() => Console.WriteLine("Editing Excel document...");
    public void Save() => Console.WriteLine("Saving Excel document...");
}
