using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaGameTrainerAccount
{
    public partial class Form1 : Form
    {
        private Game g;

        public Form1()
        {
            //Дз
            // + уровень сложности: более сложные выражения до 20, до 40, до 60... (переменная с макс числом в рандоме чисел)
            // + повышать уровень сложности от количества правильных ответов (н-р подряд 3 правильных)
            // + показать уровень на форме
            // + усложнить выражения (+, -, *, :, ...)
            // + добавить кнопку начать сначала
            // + добавить кнопку пропустить ( <=> неправильный ответ)
            // ...

            InitializeComponent();

            g = new Game();
            g.Change += G_Change;
            g.DoReset();

            buYes.Click += (s, e) => g.DoAnswer(true);
            buNo.Click += (s, e) => g.DoAnswer(false);
            buReset.Click += (s, e) => g.DoReset();
            buSkip.Click += (s, e) => g.DoSkip();
        }

        private void G_Change(object? sender, EventArgs e)
        {
            laCorrect.Text = $"Верно = {g.CountCorrect}";
            laWrong.Text = $"Неверно = {g.CountWrong}";
            laCode.Text = g.CodeText;
            switch (g.Level) { 
                case 1:
                    laLevel.Text = "Уровень сложности: простой";
                    break;
                case 2:
                    laLevel.Text = "Уровень сложности: средний";
                    break;
                case 3:
                    laLevel.Text = "Уровень сложности: сложный";
                    break;
                case 4:
                    laLevel.Text = "Уровень сложности: эксперт";
                    break;
                default:
                    break;
            }
        }
    }
}
