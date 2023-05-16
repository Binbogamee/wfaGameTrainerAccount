using System;

namespace wfaGameTrainerAccount
{
    internal class Game
    {
        //свойства с большой буквы, поля с маленькой
        public int CountCorrect { get; private set; }
        public int CountWrong { get; private set; }
        public string CodeText { get; private set; }
        public int Level {  get; private set; }


        private bool answerCorrect;
        private int correctInRow = 0;
        private int numberRange = 20;

        public event EventHandler Change;

        public void DoReset()
        {
            CountCorrect = 0;
            CountWrong = 0;
            Level = 1;
            DoContinue();
        }

        private void DoContinue()
        {
            numberRange = Level * 20;
            Random rnd = new Random();
            int xValue1 = rnd.Next(numberRange);
            int xValue2 = rnd.Next(numberRange);
            int xResult = xValue1 + xValue2;
            string sign = "+";
            switch (rnd.Next(1, Level+1))
            {
                case 1:
                    xResult = xValue1 + xValue2;
                    sign = "+";
                    break;
                case 2:
                    xResult = xValue1 - xValue2;
                    sign = "-";
                    break;
                case 3:
                    xResult = xValue1 * xValue2;
                    sign = "*";
                    break;
                case 4:
                    xResult = xValue1 / xValue2;
                    sign = "/";
                    break;
                default:
                    break;
            }
            int xResultNew = xResult; // то что увидит пользователь
            if (rnd.Next(2) == 1)
            {
                xResultNew +=rnd.Next(1,10) * (rnd.Next(2) == 1 ? 1 : -1);
            }
            CodeText = $"{xValue1} {sign} {xValue2} = {xResultNew}";
            answerCorrect = (xResult == xResultNew);
            Change?.Invoke(this, EventArgs.Empty); 
        }

        public void DoAnswer(bool v)
        {
            if (v == answerCorrect)
            {
                CountCorrect++;
                correctInRow++;
                if (correctInRow == 3 && Level < 4)
                {
                    Level++;
                    correctInRow = 0;
                }
            }
            else
            {
                CountWrong++;
                correctInRow = 0;
                if (Level > 1)
                {
                    Level--;
                }
            }
            DoContinue();
        }

        public void DoSkip()
        {
            CountWrong++;
            DoContinue();
        }
    }
}