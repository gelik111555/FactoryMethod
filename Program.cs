using FactoryMethod.Interfaces;
using FactoryMethod;
using FactoryMethod.Factories;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Получаем список всех доступных фабрик
        var availableFactories = GetAvailableFactories();

        Console.WriteLine("Доступные типы документов:");
        foreach (var factoryName in availableFactories)
        {
            Console.WriteLine(factoryName);
        }
        Assembly assembly = Assembly.GetExecutingAssembly();

        Console.WriteLine("\nСоздание документа\n");

        // Выбор типа документа, который мы хотим создать
        DocumentFactory factory = GetDocumentFactory("Word");

        // Создание документа через фабрику
        IDocument document = factory.CreateDocument();

        // Работа с документом
        document.Open();
        document.Edit();
        document.Save();
    }

    static List<string> GetAvailableFactories()
    {
        // Получаем текущую сборку
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Ищем все типы, наследующие DocumentFactory
        var factoryTypes = assembly.GetTypes()
            .Where(type => type.IsSubclassOf(typeof(DocumentFactory)) && !type.IsAbstract)
            .ToList();

        // Получаем имена классов фабрик без суффикса "Factory"
        return factoryTypes.Select(type => type.Name.Replace("DocumentFactory", "")).ToList();
    }

    // Метод, возвращающий нужную фабрику на основе типа документа
    static DocumentFactory GetDocumentFactory(string docType)
    {
        // Построим имя класса фабрики на основе строки docType
        string factoryClassName = $"FactoryMethod.Factories.{docType}FileFactory";

        // Получаем текущую сборку (где находятся наши классы)
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Ищем нужный тип в сборке по имени
        Type factoryType = assembly.GetType(factoryClassName);

        // Проверяем, найден ли нужный тип
        if (factoryType == null)
        {
            throw new NotSupportedException($"Factory for document type '{docType}' not found.");
        }

        // Создаем экземпляр найденного типа и приводим к типу DocumentFactory
        return (DocumentFactory)Activator.CreateInstance(factoryType);
    }
}
