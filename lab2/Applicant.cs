using System;

namespace lab_2
{
    public struct Applicant
    {
        private string _lastName;
        private int _mathScore;
        private int _russianLanguageScore;
        private int _englishLanguageScore;
        private int _sumScore;

        public const string DEFAULT_LASTNAME = "No name";
        public const int DEFAULT_SCORE = 0;

        public const int MAX_SCORE = 100;
        public const int MIN_SCORE = 0;

        public Applicant(string lastName, int mathScore, int russianLanguageScore, int englishLanguageScore, int sumScore)
        {
            _lastName = lastName;
            _mathScore = mathScore;
            _russianLanguageScore = russianLanguageScore;
            _englishLanguageScore = englishLanguageScore;
            _sumScore = sumScore;
        }

        //проверка фамилии
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                string testString = value;
                bool isRightString = true;
                if (testString != null)
                {
                    char convertLetter = Convert.ToChar(testString[0]);
                    if ((convertLetter >= 'А' && convertLetter <= 'Я') || (convertLetter >= 'A' &&
                         convertLetter <= 'Z')) //первая буква должна быть заглавная
                    {
                        for (int i = 1; i < testString.Length; i++)
                        {
                            convertLetter = Convert.ToChar(testString[i]);
                            if (!((convertLetter >= 'a' && convertLetter <= 'z') || (convertLetter >= 'а' &&
                                 convertLetter <= 'я'))) //остальные строчные
                            {
                                _lastName = DEFAULT_LASTNAME;
                                isRightString = false;
                                break;
                            }
                        }

                        if (isRightString)
                        {
                            _lastName = value;
                        }

                    }
                    else
                    {
                        _lastName = DEFAULT_LASTNAME;
                    }
                }
                else
                {
                    _lastName = DEFAULT_LASTNAME;
                }
            }
        }

        public int MathScore
        {
            get => _mathScore;
            set
            {
                _mathScore = (value >= MIN_SCORE && value <= MAX_SCORE) ? value : DEFAULT_SCORE;
            }
        }



        public int RussianLanguageScore
        {
            get => _russianLanguageScore;
            set
            {
                _russianLanguageScore = (value >= MIN_SCORE && value <= MAX_SCORE) ? value : DEFAULT_SCORE;
            }
        }

        public int EnglishLanguageScore
        {
            get => _englishLanguageScore;
            set
            {
                _englishLanguageScore = (value >= MIN_SCORE && value <= MAX_SCORE) ? value : DEFAULT_SCORE;
            }
        }

        public int SumScore
        {
            get => _sumScore;
            set
            {
                _sumScore = value;
            }
        }

        public override string ToString()
        {
            return String.Format("| {0,-20}|\t{1,3:N0}\t|\t{2,3:N0}\t|\t{3,3:N0}\t|\t{4,3:N0}\t|", _lastName, _mathScore, _russianLanguageScore, _englishLanguageScore, _sumScore);
        }
    }
}





