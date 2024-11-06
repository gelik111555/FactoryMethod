using FactoryMethod.Document;
using FactoryMethod.Interfaces;

namespace FactoryMethod.Factories;

public class WordFileFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordFile();
    }
}
