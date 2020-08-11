using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кости
{
    public partial class Form1 : Form
    {
        decimal summ; // Количество очков
        const int vremya = 60; // Изначальное время
        int ostVrem = 60; // Количество оставшегося времени
        decimal stavka, zadumannoe_chislo; // stavka - Количество очков 

        int [] kub1 = new int [6]; // Первый массив. Числа с первого куба
        int [] kub2 = new int [6]; // Второй массив. Числа со второго куба
        Random r1 = new Random(); // Создание рандома

        private void timer1_Tick(object sender, EventArgs e) // ТАймер
        {
            ostVrem--; // вычитание времени 
            progressBar1.Value--; // уменьшение полосы времени
            label5.Text = Convert.ToString(ostVrem) + " сек."; 
            // Выводит оставшееся время на экран цифрами. 
                                                               
            // Скрыл на финальном этапе, так как нужно было только для теста
            if (ostVrem == 0) // Условие при окончании времени
            {
                textBox1.Enabled = false; // Выключает первое окно ввода
                textBox2.Enabled = false; // Выключает второе окно ввода
                button1.Enabled = false; // Выключает кнопку  "бросок кубика"
                timer1.Enabled = false; // Выключает таймер
                progressBar1.Enabled = false; // Выключает полоску времени
                MessageBox.Show("Время истекло!\nВаш результат: " + summ + " $", 
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Question);
                // Выводит результат 
                закончитьИгруToolStripMenuItem.Enabled = false;
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e) // Кнопка старт
        {
            if (timer1.Enabled == true)
            {
                if (MessageBox.Show("Вы уверены что хотите начать заново?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    summ = 100;
                    label2.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    progressBar1.Value = 60; //задает кол-во оставшегося времени на прогрессбар
                    ostVrem = 60; //задает кол-во оставшегося времени
                    textBox1.Focus(); //указывает фокус на первое окно ввода

                    
                }
            }
            else
            {
                summ = 100; // задает начальное значение суммы
                label2.Text = ""; // при запуске убирает label2
                textBox1.Enabled = true; //включает первое окно ввода
                textBox1.Text = ""; //отчищает первое окно ввода
                textBox2.Enabled = true; //включает второе окно ввода
                textBox2.Text = ""; //отчищает второе окно ввода
                button1.Enabled = true; //выключает кнопку "бросить кубики"
                timer1.Start(); //запускает таймер
                progressBar1.Enabled = true; //включает полосу оставшегося времени
                progressBar1.Value = 60; //задает кол-во оставшегося времени на прогрессбар
                ostVrem = 60; //задает кол-во оставшегося времени
            }
            label3.Text = "Ваши очки: " + summ + " $";
            стопToolStripMenuItem.Enabled = true;
            стартToolStripMenuItem.Text = "Начать заново";
            закончитьИгруToolStripMenuItem.Enabled = true;
            стопToolStripMenuItem.Text = "Стоп";
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка бросить кубики
        {
            try // оператор который не дает выйти из программы в случае ошибки 
            {
                // задается значение для первого и второго массива
                kub1[0] = kub2[0] = 1;
                kub1[1] = kub2[1] = 2;
                kub1[2] = kub2[2] = 3;
                kub1[3] = kub2[3] = 4;
                kub1[4] = kub2[4] = 5;
                kub1[5] = kub2[5] = 6;
                
                int kubik1 = kub1[r1.Next(6)], kubik2 = kub2[r1.Next(6)]; 
                // получние рандомных чисел из массивов
                int pc = kubik1 + kubik2; 
                //Получение рандомного числа с которым будет сравниваться вводимое игроком число
                if (kubik1 == kub1[0]) { pictureBox13.Image = Properties.Resources._1 as Bitmap; } 
                if (kubik1 == kub1[1]) { pictureBox13.Image = Properties.Resources._2 as Bitmap; }
                if (kubik1 == kub1[2]) { pictureBox13.Image = Properties.Resources._3 as Bitmap; }
                if (kubik1 == kub1[3]) { pictureBox13.Image = Properties.Resources._4 as Bitmap; }
                if (kubik1 == kub1[4]) { pictureBox13.Image = Properties.Resources._5 as Bitmap; }
                if (kubik1 == kub1[5]) { pictureBox13.Image = Properties.Resources._6 as Bitmap; }
                if (kubik2 == kub2[0]) { pictureBox14.Image = Properties.Resources._1 as Bitmap; }
                if (kubik2 == kub2[1]) { pictureBox14.Image = Properties.Resources._2 as Bitmap; }
                if (kubik2 == kub2[2]) { pictureBox14.Image = Properties.Resources._3 as Bitmap; }
                if (kubik2 == kub2[3]) { pictureBox14.Image = Properties.Resources._4 as Bitmap; }
                if (kubik2 == kub2[4]) { pictureBox14.Image = Properties.Resources._5 as Bitmap; }
                if (kubik2 == kub2[5]) { pictureBox14.Image = Properties.Resources._6 as Bitmap; }
                //условия позволяющие сделать видимыми нужную грань куба

                label6.Text = Convert.ToString(pc) + " - выводит сумму  с 1 и 2 куба ";
                // нужна была для теста. Позже закрылась формой. выводит значение "pc"
                label7.Text = Convert.ToString(kubik1) + " - выводит рандомные значения с 1 куба ";
                label8.Text = Convert.ToString(kubik2) + " - выводит рандомные значения с 2 куба ";
               // label9.Text = Convert.ToString(kub1[r1.Next(1, 7)]);
                 
                // сумма 2 кубиков
                stavka = Convert.ToDecimal(textBox2.Text); 
                // Конвертиреут данные из второго вводимого поля
                zadumannoe_chislo = Convert.ToDecimal(textBox1.Text); 
                // Конвертиреут данные из первого вводимого поля
                decimal dubl = zadumannoe_chislo; 
                // задается переменная которой присваевается значение zadumannoe_chislo
                if (summ == 0)  //Условие при получении 0 игроком
                {
                    timer1.Stop(); // Остановка таймера
                    MessageBox.Show("Вы проиграли!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close(); 
                    //вывод сообщение и закрытие программы
                }
                if (stavka > summ) //Условие проверяющее вводимую ставку 
                {
                    MessageBox.Show("Вы не можете поставить больше," +
                        "\nчем у вас есть!", 
                        "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //вывод сообщение с кнопкой ОК
                }
                if (zadumannoe_chislo < 2) //Условие проверяющее вводимое значение
                {
                    MessageBox.Show("Можно вводить числа от 2 до 12", "", 
                        MessageBoxButtons.OK, MessageBoxIcon.Question); 
                }
                if (zadumannoe_chislo > 12) //Условие проверяющее вводимое значение
                {
                    MessageBox.Show("Можно вводить числа от 2 до 12", "", 
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                if (stavka <= summ & dubl <= 12 & dubl >= 2) //Условие проверяющее вводимое значение
                {
                    if (pc < zadumannoe_chislo) //Условие проверяющее вводимое значение 
                    {
                        summ = summ - stavka; //вычет очков за проигрыш
                        label2.Text = "Вы проиграли " + stavka + "  $"; // выводит надпись и сумму проигрыша
                        label2.ForeColor = Color.Red; // указывает какого цвета будет надпись
                    }
                    if (pc == zadumannoe_chislo) //Условие проверяющее вводимое значение
                    {
                        summ = summ + (stavka * 4); // формула получения в 4 раза больше очков
                        label2.Text = "Вы выиграли " + (stavka*4) + " $!"; // выводит кол-во очков
                        label2.ForeColor = Color.Blue; // указывает цвет
                    }
                    if (pc > zadumannoe_chislo) //Условие проверяющее вводимое значение
                    {
                        summ = summ + (stavka * 2); // формула расчитывающая выигрыш
                        label2.Text = "Вы выиграли " + (stavka*2) + " $"; // выводит кол-во очков и сумму выигрыша
                        label2.ForeColor = Color.Green; // указывает какого цыета будет надпись
                    }
                    label3.Text = "Ваши очки: " + summ + " $"; // показывает общее кол-во очков
                }
            }
            catch // завершение try
            {
                MessageBox.Show("Проверьте вводимыее значения!" 
                    + "\nМожно вводить числа от 2 до 12 \nУдачной игры!", 
                    "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) 
            //действие для первого вводимого поля
        {
            if (e.KeyChar.Equals((char)13)) 
                // указывает какая кнопка должна быть нажата "Enter"
                textBox2.Focus(); 
            // после нажатия клавиши Enter, фокус переходит на 2 вводимое поле
        }

        private void разработчикToolStripMenuItem_Click(object sender, EventArgs e) 
            // указывает что должна сделать кнопка "разработчик"
        {
            try
            {
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                    if (MessageBox.Show("Разработал: Полчихин Андрей\nГруппа: ПИНб-21(б)\n2019 год",
                        "Информация", MessageBoxButtons.OK) == DialogResult.OK) timer1.Start();
                    // выводит окно с информацией о разработчике
                }
                else
                {
                    MessageBox.Show("Разработал: Полчихин Андрей\nГруппа: ПИНб-21(б)\n2019 год",
                        "Информация", MessageBoxButtons.OK);
                }
            }
            catch { }
        }

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e) 
            // указывает что должна сделать кнопка "Инфо"
        {
            if (timer1.Enabled == true)
            {
                timer1.Stop();
                if (MessageBox.Show("      Цель игры:\nНабрать наибольшее количество очков\n" +
                                      " за 60 секунд. \n" +
                                      "\n      Правила игры: \nВы должны угадать число рандомно" +
                                      "\nвыбранное компьютером от 2 до 12.\n" +
                                      "Вам дается одна минута на накопление очков. \n" +
                                      "\n      Условия победы: \n" +
                                      "В начале игры вам дается 100 очков.\n" +
                                      "Вы можете ставить любое количество очков, \n" +
                                      "не превышающее ваш счёт. \n" +
                                      "Вы побеждаете, если сумма на кубике \n" +
                                      "равна или больше, чем ваше число. \n" +
                                      "Если вы угадали число, то получаете в \n" +
                                      "4 раза больше чем поставили. \n" +
                                      "Если число больше чем сумма на \n" +
                                      "кубиках, то удваиваете вашу ставку. \n" +
                                      "\n      Удачной игры!", "Информация", MessageBoxButtons.OK) == DialogResult.OK) timer1.Start();
                //выводит окно с информацией
            }
            else
            {
                MessageBox.Show("      Цель игры:\nНабрать наибольшее количество очков\n" +
                                      " за 60 секунд. \n" +
                                      "\n      Правила игры: \nВы должны угадать число рандомно" +
                                      "\nвыбранное компьютером от 2 до 12.\n" +
                                      "Вам дается одна минута на накопление очков. \n" +
                                      "\n      Условия победы: \n" +
                                      "В начале игры вам дается 100 очков.\n" +
                                      "Вы можете ставить любое количество очков, \n" +
                                      "не превышающее ваш счёт. \n" +
                                      "Вы побеждаете, если сумма на кубике \n" +
                                      "равна или больше, чем ваше число. \n" +
                                      "Если вы угадали число, то получаете в \n" +
                                      "4 раза больше чем поставили. \n" +
                                      "Если число больше чем сумма на \n" +
                                      "кубиках, то удваиваете вашу ставку. \n" +
                                      "\n      Удачной игры!", "Информация", MessageBoxButtons.OK);
            }
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Stop();
                стопToolStripMenuItem.Text = "Продолжить";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                label2.Text = "Пауза!";
                //стартToolStripMenuItem.Enabled = false;
            }
            else
            {
                timer1.Start();
                стопToolStripMenuItem.Text = "Стоп";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                label2.Text = "";
               // стартToolStripMenuItem.Enabled = true;
            }
        }

        private void закончитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                if (MessageBox.Show("Вы уверены что хотите закончить игру?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (timer1.Enabled == true)
                    {
                        timer1.Stop();
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        button1.Enabled = false;
                        MessageBox.Show("Ваш результат: " + summ + " $",
                            "Результат", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        стопToolStripMenuItem.Enabled = false;
                        закончитьИгруToolStripMenuItem.Enabled = false;
                    }
                    // if (timer1.Enabled == false)
                    else
                    {
                        timer1.Stop();
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        button1.Enabled = false;
                        MessageBox.Show("Ваш результат: " + summ + " $",
                            "Результат", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        стопToolStripMenuItem.Enabled = false;
                        закончитьИгруToolStripMenuItem.Enabled = false;
                    }

                }

            }
            else { }
            
        }
        public Form1()
        {
            InitializeComponent(); // указывает, что должна сделать программа при запуске
            summ = 100; // сумма очков равна 100
            label2.Text = ""; // вводимое поле 2 отчищается
            label3.Text = "Ваши очки: " +summ + "$"; // показывает кол-во очков
            label5.Text = Convert.ToString(ostVrem) + " сек.";
            // конвертирует значение в текст. 
            textBox1.Enabled = false; // при включении первое вводимое поле не активно
            textBox2.Enabled = false; // при включении второе вводимое поле не активно
            button1.Enabled = false;  // при включении кнопка "бросить кубики" не активна
            timer1.Enabled = false; //таймер при включении выключен
            progressBar1.Maximum = vremya; //указывает максимальное кол-во времени
            progressBar1.Value = vremya;   //указывает значение кол-ва времени
            progressBar1.Step = 1; //указывает шаг на  progressBar1
            MessageBox.Show("Зайдите в МЕНЮ и выберете пункт СТАРТ", "Добро пожаловать", MessageBoxButtons.OK);
            //вывод окно с приветственным сообщением
            стопToolStripMenuItem.Enabled = false;
            закончитьИгруToolStripMenuItem.Enabled = false;
        }
    }
}
