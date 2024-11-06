using FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Document;

internal class WordFile: IDocument
{
    public void Open() => Console.WriteLine("Opening Word document...");
    public void Edit() => Console.WriteLine("Editing Word document...");
    public void Save() => Console.WriteLine("Saving Word document...");
}
