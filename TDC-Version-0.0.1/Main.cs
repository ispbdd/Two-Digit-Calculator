using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TDC_Version_0._0._1
{
    public partial class Main : MaterialForm
    {
        public string MainAction;                // Основное действие
        public string PlaceholderText = "Число"; // Текст заполнителя
        public string PlaceholderText2 = "0";    // Второй текст заполнителя
        public int OperatorCount = 0;            // Количество операторов
        public bool FlagForAction;               // Флаг для действия
        public bool CountForInputNumber;         // Подсчет для ввода числа
        public double OldNumber;                 // Старое число 1

        public Main()
        {
            FlagForAction = false;
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            tb_InputLine.Text = PlaceholderText;
            tb_PreviewArea.Text = PlaceholderText2;
        }

        /// Переключатель тем
        MaterialSkinManager Thememanager = MaterialSkinManager.Instance;

        /// Флаг для отслеживания первого нажатия
        private bool isFirstClick = true;

        /// <summary>
        /// Обрабатывает событие нажатия кнопки для расчета квадрата числа. Принимает ввод от пользователя, возводит число в квадрат и выводит результат обратно в текстовое поле.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
        private void btn_ActDegree_Click(object sender, EventArgs e)
        {
            double num, result;
            num = Convert.ToDouble(tb_InputLine.Text);
            result = Math.Pow(num, 2);
            tb_InputLine.Text = result.ToString();
        }

        /// <summary>
        /// Обрабатывает событие нажатия числовых кнопок. Определяет, является ли это первое нажатие, очищает текстовое поле ввода и добавляет в него символы, соответствующие нажатой кнопке.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
        private void btn_Numb_Click(object sender, EventArgs e)
        {
            if (tb_InputLine.Text == PlaceholderText) 
            {
                tb_InputLine.Text = "";
            }

            if (isFirstClick)
            {
                tb_InputLine.Clear();
                isFirstClick = false;
            }

            Button B = (Button)sender;

            if (FlagForAction)
            {
                FlagForAction = false;
                tb_InputLine.Text = PlaceholderText2;
            }

            // Button B = (Button)sender;

            if (tb_InputLine.Text == "0")
            {
                tb_InputLine.Text = B.Text;
            }

            else
            {
                tb_InputLine.Text += B.Text;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку действия.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btn_Action_Click(object sender, EventArgs e)
        {
            // Проверяем, является ли операторный счетчик равным нулю.
            if (OperatorCount == 0)
            {
                Button B = (Button)sender;

                // Проверяем, что в поле ввода не пустая строка.
                if (!string.IsNullOrEmpty(tb_InputLine.Text))
                {
                    // Преобразуем введенное значение в число и сохраняем его.
                    OldNumber = Convert.ToDouble(tb_InputLine.Text);
                }

                MainAction = B.Text;   // Записываем текст кнопки в переменную MainAction.
                FlagForAction = true;  // Устанавливаем флаг для выполнения действия.
                OperatorCount++;       // Увеличиваем счетчик операторов.
            }

            // Отображаем сохраненное число в поле ввода.
            tb_PreviewArea.Text = OldNumber.ToString();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку запятой.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btn_Comma_Click(object sender, EventArgs e)
        {
            // Приводим объект-отправитель к типу Button
            Button b = (Button)sender;

            // Проверяем, если текст кнопки равен запятой и поле ввода уже содержит запятую.
            if (b.Text == "," && tb_InputLine.Text.Contains(","))
            {
                // Ничего не делаем, так как запятая уже присутствует в поле ввода.
            }
            else
            {
                // Добавляем текст кнопки к содержимому поля ввода.
                tb_InputLine.Text += b.Text;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку очистки.
        /// Сбрасывает поле ввода и счетчик операторов, а также обновляет область предпросмотра.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_InputLine.Text = PlaceholderText; // Сбрасываем содержимое поля ввода на "0".
            OperatorCount = 0;                   // Сбрасываем счетчик операторов.
            tb_PreviewArea.Text = "0";           // Устанавливаем содержимое области предпросмотра на "0".
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку очистки последнего введенного символа.
        /// Удаляет последний символ из поля ввода, если это цифра.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btn_ClearEntry_Click(object sender, EventArgs e)
        {
            // Проверяем, что длина поля ввода больше нуля и все символы являются цифрами.
            if (tb_InputLine.Text.Length > 0 && tb_InputLine.Text.All(Char.IsDigit))
            {
                // Удаляем последний символ из поля ввода.
                tb_InputLine.Text = tb_InputLine.Text.Remove(tb_InputLine.Text.Length - 1);
            }

            // Проверяем, что поле ввода не пустое
            if (string.IsNullOrEmpty(tb_InputLine.Text))
            {
                tb_InputLine.Text = PlaceholderText;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку равно.
        /// Выполняет расчет операции в зависимости от предыдущего выбранного действия и выводит результат в поле ввода.
        /// Если при делении второе число равно нулю, выводит сообщение об ошибке.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btn_EqualSign_Click(object sender, EventArgs e)
        {
            try
            {
                double num2, result;                        // Объявляем переменные для второго числа, результата.
                num2 = Convert.ToDouble(tb_InputLine.Text); // Преобразуем содержимое поля ввода в число.

                // Выполняем операцию в зависимости от MainAction.
                switch (MainAction)
                {
                    case "+":
                        result = OldNumber + num2;
                        break;

                    case "-":
                        result = OldNumber - num2;
                        break;

                    case "*":
                        result = OldNumber * num2;
                        break;

                    case "/":
                        if (num2 != 0)
                        {
                            result = OldNumber / num2;
                        }
                        else
                        {
                            MessageBox.Show("На ноль делить нельзя!");
                            return;
                        }
                        break;

                    case "%":
                        result = OldNumber / 100 * num2;
                        break;

                    default:
                        result = num2;
                        break;
                }

                // Выводим результат операции в поле ввода.
                tb_InputLine.Text = Convert.ToString(result);

                // Присваиваем значение результата переменной OldNumber и сбрасываем счетчик операторов.
                OldNumber = result;
                OperatorCount = 0;
            }

            // Обрабатываем исключения, выводим сообщение об ошибке.
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события, возникающий при входе курсора в поле ввода.
        /// Очищает поле ввода, если оно содержит текст-заменитель.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void tbInput_Enter(object sender, EventArgs e)
        {
            // Если содержимое поля ввода равно тексту-заменителю, очищаем его.
            if (tb_InputLine.Text == PlaceholderText)
            {
                tb_InputLine.Text = "";
            }
        }

        /// <summary>
        /// Обработчик события, возникающий при выходе курсора из поля ввода.
        /// Если поле ввода пустое, устанавливает в нем текст-заменитель.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void tbInput_Leave(object sender, EventArgs e)
        {
            // Если поле ввода пустое, устанавливаем в нем текст-заменитель.
            if (tb_InputLine.Text == "")
            {
                tb_InputLine.Text = PlaceholderText;
            }
        }
    }
}