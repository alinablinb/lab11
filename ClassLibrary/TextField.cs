namespace ClassLibrary
{
    public class TextField : ControlElement, ICloneable
    {
        protected string _hint;
        protected string _text;

        // Свойство для подсказки с проверкой
        public string Hint
        {
            get => _hint;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Подсказка не может быть пустой");
                _hint = value;
            }
        }

        // Свойство для текста
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        // Конструктор по умолчанию
        public TextField() : base()
        {
            _hint = "NameLess";
            _text = "";
        }

        // Конструктор с параметрами
        public TextField(int id1, int id2, double x, double y, string hint, string text) : base(id1, id2, x, y)
        {
            Hint = hint;
            Text = text;
        }

        // Конструктор глубокого копирования
        public TextField(TextField other) : base(other)
        {
            Hint = other.Hint;
            Text = other.Text;
        }

        // Переопределение метода Show
        public new string Show()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Подсказка: {Hint}, Текст: {Text}";
        }

        // Переопределение метода ShowVirtual
        public override string ShowVirtual()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Подсказка: {Hint}, Текст: {Text}";
        }

        // Переопределение метода Init
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите подсказку:");
            Hint = Console.ReadLine();
            Console.WriteLine("Введите текст:");
            Text = Console.ReadLine();
        }

        // Переопределение метода RandomInit
        public override void RandomInit()
        {
            base.RandomInit();
            string[] hints = { "Введите имя", "Введите пароль", "Введите email" };
            Hint = hints[random.Next(hints.Length)];
            Text = random.Next(1, 100).ToString();
        }


        // Переопределение метода Clone
        public override object Clone()
        {
            return new TextField(this);
        }

        // Свойство для получения базового элемента управления
        public ControlElement GetBase => new ControlElement(ID.Id, Id, X, Y);

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is TextField))
                return false;

            TextField other = (TextField)obj;
            return base.Equals(obj) && Hint == other.Hint && Text == other.Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Hint, Text);
        }


        // Переопределение метода ToString
        public override string ToString()
        {
            return $"ID: {ID}, Id: {Id}, X: {X}, Y: {Y}, Подсказка: {Hint}, Текст: {Text}";
        }
    }
}
