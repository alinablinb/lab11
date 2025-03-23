using System.Collections;
using ClassLibrary;

class Program
{
    static void Main(string[] args)
    {
        // 1. Создаем неуниверсальную коллекцию SortedList
        SortedList sortedList = new SortedList();

        Console.WriteLine("Создаем коллекцию SortedList и добавляем случайные элементы:");

        // 2. Добавляем объекты из иерархии классов в коллекцию SortedList с использованием RandomInit()
        for (int i = 1; i <= 5; i++)
        {
            ControlElement element = CreateRandomControlElement();

            // Проверяем, есть ли уже такой ключ в коллекции
            if (!sortedList.ContainsKey(i))
            {
                sortedList.Add(i, element);
                Console.WriteLine($"Добавлен элемент с ключом {i}: {element}");
            }
            else
            {
                Console.WriteLine($"Ключ {i} уже существует в коллекции.");
                i--;
            }
        }

        // 3. Реализуем добавление и удаление объектов коллекции SortedList
        Console.WriteLine("\nДобавляем новый элемент в коллекцию SortedList:");
        var newElement = new TextField();
        newElement.RandomInit();

        // Проверяем, есть ли уже такой ключ в коллекции
        if (!sortedList.ContainsKey(6))
        {
            sortedList.Add(6, newElement);
            Console.WriteLine($"Добавлен элемент с ключом 6: {newElement}");
        }
        else
        {
            Console.WriteLine($"Ключ 6 уже существует в коллекции, пропускаем.");
        }

        Console.WriteLine("\nУдаляем элемент с ключом 2 из SortedList:");
        if (sortedList.ContainsKey(2))
        {
            Console.WriteLine($"Удален элемент с ключом 2: {sortedList[2]}");
            sortedList.Remove(2);
        }
        else
        {
            Console.WriteLine("Элемент с ключом 2 не найден.");
        }

        // 4. Разрабатываем и реализуем три запроса для SortedList
        int buttonCount = CountButtons(sortedList);
        Console.WriteLine($"\nКоличество кнопок: {buttonCount}");

        Console.WriteLine("\nТексты текстовых полей с подсказкой:");
        PrintTextFieldTextsWithHint(sortedList);

        Console.WriteLine("\nЭлементы управления на координате X = 500:");
        PrintControlElementsAtX500(sortedList);

        // 5. Перебор элементов коллекции SortedList с помощью foreach
        Console.WriteLine("\nВсе элементы коллекции SortedList:");
        PrintSortedList(sortedList);

        // 6. Клонирование коллекции SortedList 
        SortedList clonedSortedList = DeepCloneSortedList(sortedList);

        // Вывод клонированной коллекции SortedList
        Console.WriteLine("\nСодержимое клонированной коллекции SortedList:");
        PrintSortedList(clonedSortedList);

        // 7. Поиск заданного элемента в коллекции SortedList
        Console.WriteLine("\nИщем случайный элемент в коллекции SortedList:");
        var searchElement = new TextField();
        searchElement.RandomInit();
        Console.WriteLine($"Ищем элемент: {searchElement}");

        if (sortedList.ContainsValue(searchElement))
        {
            Console.WriteLine("Элемент найден в коллекции SortedList.");
        }
        else
        {
            Console.WriteLine("Элемент не найден в коллекции SortedList.");
        }

        // 8. Создаем обобщенную коллекцию Dictionary<int, ControlElement>
        Dictionary<int, ControlElement> dictionary = new Dictionary<int, ControlElement>();

        Console.WriteLine("\nСоздаем коллекцию Dictionary и добавляем случайные элементы:");

        // 9. Добавляем объекты из иерархии классов в коллекцию Dictionary с использованием RandomInit()
        for (int i = 1; i <= 5; i++)
        {
            ControlElement element = CreateRandomControlElement();

            if (!dictionary.ContainsKey(i))
            {
                dictionary.Add(i, element);
                Console.WriteLine($"Добавлен элемент с ключом {i}: {element}");
            }
            else
            {
                Console.WriteLine($"Ключ {i} уже существует в коллекции.");
                i--;
            }
        }

        // 10. Реализуем добавление и удаление объектов коллекции Dictionary
        Console.WriteLine("\nДобавляем новый элемент в коллекцию Dictionary:");
        var newElementDict = new TextField();
        newElementDict.RandomInit();

        int newKey = dictionary.Count + 1;
        if (!dictionary.ContainsKey(newKey))
        {
            dictionary.Add(newKey, newElementDict);
            Console.WriteLine($"Добавлен элемент с ключом {newKey}: {newElementDict}");
        }
        else
        {
            Console.WriteLine($"Ключ {newKey} уже существует в коллекции.");
        }

        Console.WriteLine("\nУдаляем элемент с ключом 2 из Dictionary:");
        if (dictionary.ContainsKey(2))
        {
            Console.WriteLine($"Удален элемент с ключом 2: {dictionary[2]}");
            dictionary.Remove(2);
        }
        else
        {
            Console.WriteLine("Элемент с ключом 2 не найден.");
        }

        // 11. Разрабатываем и реализуем три запроса для Dictionary
        int buttonCountDict = CountButtons(dictionary);
        Console.WriteLine($"\nКоличество кнопок: {buttonCountDict}");

        Console.WriteLine("\nТексты текстовых полей с подсказкой:");
        PrintTextFieldTextsWithHint(dictionary);

        Console.WriteLine("\nЭлементы управления на координате X = 500:");
        PrintControlElementsAtX500(dictionary);

        // 12. Перебор элементов коллекции Dictionary с помощью foreach
        Console.WriteLine("\nВсе элементы коллекции Dictionary:");
        PrintDictionary(dictionary);

        // 13. Клонирование коллекции Dictionary
        Dictionary<int, ControlElement> clonedDictionary = DeepCloneDictionary(dictionary);

        // Вывод клонированной коллекции Dictionary
        Console.WriteLine("\nСодержимое клонированной коллекции Dictionary:");
        PrintDictionary(clonedDictionary);

        // 14. Поиск заданного элемента в коллекции Dictionary с помощью ContainsValue
        Console.WriteLine("\nИщем случайный элемент в коллекции Dictionary с помощью ContainsValue:");
        var searchElementDict = new TextField();
        searchElementDict.RandomInit();
        Console.WriteLine($"Ищем элемент: {searchElementDict}");

        if (dictionary.ContainsValue(searchElementDict))
        {
            Console.WriteLine("Элемент найден в коллекции Dictionary.\n");
        }
        else
        {
            Console.WriteLine("Элемент не найден в коллекции Dictionary.\n");
        }

        // Создаем объект TestCollections с 1000 элементами
        TestCollections testCollections = new TestCollections(1000);

        // Используем запомненные элементы для тестирования
        MeasureAndPrint("Первый элемент", testCollections.firstElement, testCollections);
        MeasureAndPrint("Центральный элемент", testCollections.middleElement, testCollections);
        MeasureAndPrint("Последний элемент", testCollections.lastElement, testCollections);
        MeasureAndPrint("Несуществующий элемент", testCollections.nonexistentElement, testCollections);
    }
    private static void MeasureAndPrint(string description, TextField element, TestCollections testCollections)
    {
        const int iterations = 50; // Количество итераций для усреднения
        long totalStackTicks = 0, totalStackStringTicks = 0, totalSortedDictTicks = 0, totalSortedDictStringTicks = 0;
        int foundStackCount = 0, foundStackStringCount = 0, foundSortedDictCount = 0, foundSortedDictStringCount = 0;

        for (int i = 0; i < iterations; i++)
        {
            var (stackTicks, foundStack, stackStringTicks, foundStackString,
                 sortedDictTicks, foundSortedDict, sortedDictStringTicks, foundSortedDictString) = testCollections.MeasureSearchTime(element);

            // Суммируем время
            totalStackTicks += stackTicks;
            totalStackStringTicks += stackStringTicks;
            totalSortedDictTicks += sortedDictTicks;
            totalSortedDictStringTicks += sortedDictStringTicks;

            // Подсчитываем количество успешных поисков
            if (foundStack) foundStackCount++;
            if (foundStackString) foundStackStringCount++;
            if (foundSortedDict) foundSortedDictCount++;
            if (foundSortedDictString) foundSortedDictStringCount++;
        }

        // Вычисляем среднее время в тиках
        long avgStackTicks = totalStackTicks / iterations;
        long avgStackStringTicks = totalStackStringTicks / iterations;
        long avgSortedDictTicks = totalSortedDictTicks / iterations;
        long avgSortedDictStringTicks = totalSortedDictStringTicks / iterations;

        // Вывод среднего времени и информации о том, найден элемент или нет
        Console.WriteLine($"{description} в коллекции Stack<TextField>: {(foundStackCount > 0 ? "найден" : "не найден")} за {avgStackTicks} тиков");
        Console.WriteLine($"{description} в коллекции Stack<string>: {(foundStackStringCount > 0 ? "найден" : "не найден")} за {avgStackStringTicks} тиков");
        Console.WriteLine($"{description} в коллекции SortedDictionary<ControlElement, TextField>: {(foundSortedDictCount > 0 ? "найден" : "не найден")} за {avgSortedDictTicks} тиков");
        Console.WriteLine($"{description} в коллекции SortedDictionary<string, TextField>: {(foundSortedDictStringCount > 0 ? "найден" : "не найден")} за {avgSortedDictStringTicks} тиков");
        Console.WriteLine();
    }

    // Метод для создания случайного элемента управления
    static ControlElement CreateRandomControlElement()
    {
        Random random = new Random();
        int randomType = random.Next(0, 3);

        ControlElement element;
        switch (randomType)
        {
            case 0:
                element = new TextField();
                break;
            case 1:
                element = new Button();
                break;
            case 2:
                element = new CheckboxButton();
                break;
            default:
                throw new InvalidOperationException("Неизвестный тип элемента");
        }

        element.RandomInit();
        return element;
    }

    // Метод для вывода содержимого SortedList
    static void PrintSortedList(SortedList sortedList)
    {
        foreach (DictionaryEntry entry in sortedList)
        {
            Console.WriteLine($"Ключ: {entry.Key}, Значение: {entry.Value}");
        }
    }

    // Метод для вывода содержимого Dictionary
    static void PrintDictionary(Dictionary<int, ControlElement> dictionary)
    {
        foreach (var entry in dictionary)
        {
            Console.WriteLine($"Ключ: {entry.Key}, Значение: {entry.Value}");
        }
    }

    // Метод для подсчета количества кнопок (Button и CheckboxButton)
    static int CountButtons(SortedList sortedList)
    {
        int count = 0;
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value is Button || entry.Value is CheckboxButton)
                count++;
        }
        return count;
    }

    // Перегрузка метода для Dictionary
    static int CountButtons(Dictionary<int, ControlElement> dictionary)
    {
        int count = 0;
        foreach (var entry in dictionary)
        {
            if (entry.Value is Button || entry.Value is CheckboxButton)
                count++;
        }
        return count;
    }

    static void PrintTextFieldTextsWithHint(SortedList sortedList)
    {
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value is TextField textField)
            {
                Console.WriteLine($"Подсказка: {textField.Hint}, Текст: {textField.Text}");
            }
        }
    }

    // Перегрузка метода для Dictionary
    static void PrintTextFieldTextsWithHint(Dictionary<int, ControlElement> dictionary)
    {
        foreach (var entry in dictionary)
        {
            if (entry.Value is TextField textField)
            {
                Console.WriteLine($"Подсказка: {textField.Hint}, Текст: {textField.Text}");
            }
        }
    }

    static void PrintControlElementsAtX500(SortedList sortedList)
    {
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value is ControlElement controlElement && controlElement.X == 500.0)
            {
                Console.WriteLine(controlElement);
            }
        }
    }

    // Перегрузка метода для Dictionary
    static void PrintControlElementsAtX500(Dictionary<int, ControlElement> dictionary)
    {
        foreach (var entry in dictionary)
        {
            if (entry.Value is ControlElement controlElement && controlElement.X == 500.0)
            {
                Console.WriteLine(controlElement);
            }
        }
    }

    // Метод для клонирования SortedList
    static SortedList DeepCloneSortedList(SortedList sortedList)
    {
        SortedList clonedSortedList = new SortedList();

        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value is ICloneable cloneable)
            {
                clonedSortedList.Add(entry.Key, cloneable.Clone());
            }
            else
            {
                clonedSortedList.Add(entry.Key, entry.Value);
            }
        }

        return clonedSortedList;
    }

    // Метод для клонирования Dictionary
    static Dictionary<int, ControlElement> DeepCloneDictionary(Dictionary<int, ControlElement> dictionary)
    {
        Dictionary<int, ControlElement> clonedDictionary = new Dictionary<int, ControlElement>();

        foreach (var entry in dictionary)
        {
            if (entry.Value is ICloneable cloneable)
            {
                clonedDictionary.Add(entry.Key, (ControlElement)cloneable.Clone());
            }
            else
            {
                clonedDictionary.Add(entry.Key, entry.Value);
            }
        }

        return clonedDictionary;
    }
}