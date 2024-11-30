using System;

class T2D
{
    protected int a11, a12, a13, a21, a22, a23;

    public virtual void SetNumbers(int a11, int a12, int a13, int a21, int a22, int a23)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.a13 = a13;
        this.a21 = a21;
        this.a22 = a22;
        this.a23 = a23;
    }

    public virtual void Math(int x, int y, int z = 0)
    {
        int tempx = a11 * x + a12 * y + a13;
        int tempy = a21 * x + a22 * y + a23;
        Console.WriteLine($"Результат 2D: x = {tempx}, y = {tempy}");
    }
}

class T3D : T2D
{
    private int a14, a24, a31, a32, a33, a34;

    // Перевантаження SetNumbers для 2D
    public void SetNumbers2D(int a11, int a12, int a13, int a21, int a22, int a23)
    {
        base.SetNumbers(a11, a12, a13, a21, a22, a23);
    }

    // Перевантаження SetNumbers для 3D
    public void SetNumbers3D(int a14, int a24, int a31, int a32, int a33, int a34)
    {
        this.a14 = a14;
        this.a24 = a24;
        this.a31 = a31;
        this.a32 = a32;
        this.a33 = a33;
        this.a34 = a34;
    }

    // Перевизначення Math для 3D
    public override void Math(int x, int y, int z = 0)
    {
        if (z == 0)
        {
            base.Math(x, y); // Викликаємо базовий 2D метод
        }
        else
        {
            int tempx = a11 * x + a12 * y + a13 * z + a14;
            int tempy = a21 * x + a22 * y + a23 * z + a24;
            int tempz = a31 * x + a32 * y + a33 * z + a34;
            Console.WriteLine($"Результат 3D: x = {tempx}, y = {tempy}, z = {tempz}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        T2D transformation;

        Console.WriteLine("Оберіть тип трансформації (2D або 3D): ");
        string choice = Console.ReadLine();

        if (choice == "2D")
        {
            transformation = new T2D();
            transformation.SetNumbers(1, 2, 3, 4, 5, 6);
        }
        else if (choice == "3D")
        {
            T3D t3d = new T3D();
            t3d.SetNumbers2D(1, 2, 3, 4, 5, 6);  // Викликаємо метод SetNumbers для 2D
            t3d.SetNumbers3D(7, 8, 9, 10, 11, 12);  // Викликаємо метод SetNumbers для 3D
            transformation = t3d;
        }
        else
        {
            Console.WriteLine("Неправильний вибір!");
            return;
        }

        Console.WriteLine("Введіть координати:");
        try
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if (transformation is T3D)
            {
                int z = int.Parse(Console.ReadLine());
                transformation.Math(x, y, z); // Виклик для 3D
            }
            else
            {
                transformation.Math(x, y); // Виклик для 2D
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка вводу! Введіть числа.");
        }
    }
}
