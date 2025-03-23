using ClassLibrary;
using System.Diagnostics;

public class TestCollections
{
    // Коллекции
    public Stack<TextField> Col1 { get; set; }
    public Stack<string> Col2 { get; set; }
    public SortedDictionary<ControlElement, TextField> Col3 { get; set; }
    public SortedDictionary<string, TextField> Col4 { get; set; }

    // Элементы для тестирования
    public readonly TextField firstElement; // Первый элемент
    public readonly TextField middleElement; // Центральный элемент
    public readonly TextField lastElement; // Последний элемент
    public readonly TextField nonexistentElement; // Несуществующий элемент

    // Конструктор
    public TestCollections(int count)
    {
        Col1 = new Stack<TextField>();
        Col2 = new Stack<string>();
        Col3 = new SortedDictionary<ControlElement, TextField>();
        Col4 = new SortedDictionary<string, TextField>();

        // Генерация элементов
        for (int i = 0; i < count; i++)
        {
            TextField textField = new TextField();
            textField.RandomInit();

            // Проверка на дубликат
            while (Col3.ContainsKey(textField.GetBase))
                textField.RandomInit();

            // Добавление в коллекции
            Col1.Push(textField);
            Col2.Push(textField.ToString());
            Col3[textField.GetBase] = textField;

            string key = textField.ToString();
            if (!Col4.ContainsKey(key))
            {
                Col4[key] = textField;
            }
            else
            {
                Console.WriteLine($"Duplicate key found: {key}");
            }

            // Запоминаем первый, средний и последний элементы
            if (i == 0)
                firstElement = (TextField)textField.Clone();
            if (i == count / 2)
                middleElement = (TextField)textField.Clone();
            if (i == count - 1)
                lastElement = (TextField)textField.Clone();
        }

        // Создание несуществующего элемента
        nonexistentElement = new TextField(123, 123, 123, 123, "lil", "lol");
    }

    // Метод для измерения времени поиска
    public (long stackTicks, bool foundStack, long stackStringTicks, bool foundStackString,
            long sortedDictTicks, bool foundSortedDict, long sortedDictStringTicks, bool foundSortedDictString)
        MeasureSearchTime(TextField element)
    {
        Stopwatch stopwatch = new Stopwatch();

        // Поиск в Col1 (Stack<TextField>)
        stopwatch.Start();
        bool foundStack = Col1.Contains(element);
        stopwatch.Stop();
        long stackTicks = stopwatch.ElapsedTicks;

        // Поиск в Col2 (Stack<string>)
        stopwatch.Restart();
        bool foundStackString = Col2.Contains(element.ToString());
        stopwatch.Stop();
        long stackStringTicks = stopwatch.ElapsedTicks;

        // Поиск в Col3 (SortedDictionary<ControlElement, TextField>)
        stopwatch.Restart();
        bool foundSortedDict = Col3.ContainsKey(element.GetBase);
        stopwatch.Stop();
        long sortedDictTicks = stopwatch.ElapsedTicks;

        // Поиск в Col4 (SortedDictionary<string, TextField>)
        stopwatch.Restart();
        bool foundSortedDictString = Col4.ContainsKey(element.ToString());
        stopwatch.Stop();
        long sortedDictStringTicks = stopwatch.ElapsedTicks;

        // Возвращаем время в тиках и результаты поиска
        return (stackTicks, foundStack, stackStringTicks, foundStackString,
                sortedDictTicks, foundSortedDict, sortedDictStringTicks, foundSortedDictString);
    }
}