# Двузначный калькулятор
**Напишите программу на C# с использованием Windows Forms, которая будет представлять собой двузначный калькулятор. Программа должна иметь текстовое поле для ввода чисел и кнопки для цифр от 0 до 9, кнопки для операций сложения, вычитания, умножения и деления, а также кнопку для получения результата.**

Программа должна выполнять базовые арифметические операции над двузначными числами и отображать результат на экране. Также добавьте кнопку для очистки всех введенных данных.

*Проверьте, что программа корректно обрабатывает ввод пользователя, а также предусмотрите обработку возможных ошибок (например, деление на ноль). После завершения программы убедитесь, что пользователь может закрыть окно приложения.*

## Содержание
- [Windows Forms](https://learn.microsoft.com/ru-ru/dotnet/api/)
- [Состав](https://www.vstu.ru/university/personalii/zhdanov_aleksey_andreevich/)
  
## Использование
Может быть использована в учебных заведениях для обучения основам арифметики и работы с программами. Учащиеся могут использовать калькулятор, чтобы практиковаться в выполнении арифметических операций.

```C#
using System;
using System.Windows.Forms;

namespace TDC_Version_0._0._1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
```
![image](![image_2024-07-02_09-23-39](https://github.com/rizeshawty/Two-Digit-Calculator/assets/132708222/8f35ef88-bd10-458d-a9df-dde33861bd21)
)

### Требования
Для установки и запуска, необходим [Visual Studio](https://visualstudio.microsoft.com/).

## Deploy и CI/CD
JetBrains Rider, Visual Studio, Windows 11, Visual Studio Code, 
[еще...](https://learn.microsoft.com/dotnet/desktop/winforms/get-started/create-app-visual-studio?view=netdesktop-8.0)

## Contributing
Для улучшения кода рекомендуется обращаться через социальные сети.

### Для чего
Данный проект был разработан в рамках изучения системного программирования и выполнения предложенного задания.
