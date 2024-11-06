using FactoryMethod.Document;
using FactoryMethod.Interfaces;

namespace FactoryMethod.Factories;

public class ExcelFileFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelFile();
    }
}
