using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_laba_3_level
{
    internal class Program
    {
        public abstract class Team 
        {
            protected string nameOfTeam; 
            protected int raiting;
            protected int pointsScored;// забитые очки 
            protected int pointsMissed;// пропущенные очки
            protected int countOfWinnings;// количество выигрышей 
            protected int countDraw;// количесвто ничья 
            protected int losses;//потери


            public Team(string _nameOfTeam, int _pointsScored, int _pointsMissed, int _countOfWinnings, int _countDraw, int _losses) 
            {
                nameOfTeam = _nameOfTeam;
                raiting = 0;
                pointsScored = _pointsScored;
                pointsMissed = _pointsMissed;
                countOfWinnings = _countOfWinnings;
                countDraw = _countDraw;
                losses = _losses;
            }
            public Team(string _nameOfTeam, int _pointsScored, int _pointsMissed) 
            {
                nameOfTeam = _nameOfTeam;
                raiting = 0;// просто заполнила поле .. в конструктор я изначально не передаю поле с рейтингом 
                pointsScored = _pointsScored;
                pointsMissed = _pointsMissed;

            }

            public string NameOfTeam
            {
                get { return nameOfTeam; } 
                private set { nameOfTeam = value; } 


            }

            public int PointsScored
            {
                get { return pointsScored; }
                private set { pointsScored = value; }
            }
            public int PointsMissed
            {
                get { return pointsMissed; }
                private set { pointsMissed = value; }
            }
            public int Raiting
            {
                get { return raiting; }
                set { raiting = value; }
            }
            public int CountOfWinnings
            {
                get { return countOfWinnings; }
                private set { countOfWinnings = value; }
            }
            public int CountDraw
            {
                get { return countDraw; }
                private set { countDraw = value; }
            }
            public int Losses
            {
                get { return losses; }
                private set { losses = value; }
            }

            public abstract void PrintInf(); // метод вывода информации о команде 

        }

        public class TeamWomen : Team
        {
            public TeamWomen(string _nameOfTeam, int _pointsScored, int _pointsMissed) : base(_nameOfTeam, _pointsScored, _pointsMissed)
            {

            }

            public override void PrintInf() 
            {
                Console.WriteLine(raiting + " " + nameOfTeam + " женская команда " + (pointsScored - pointsMissed) + " баллов");
            }
        }
        public class TeamMen : Team
        {
            public TeamMen(string _nameOfTeam, int _pointsScored, int _pointsMissed) : base(_nameOfTeam, _pointsScored, _pointsMissed)
            {
            }

            public override void PrintInf()
            {
                Console.WriteLine(raiting + " " + nameOfTeam + " мужская команда " + (pointsScored - pointsMissed) + " баллов");
            }
        }


        static void Main(string[] args)
        {
            TeamWomen[] teamW =
            {
             new TeamWomen("Мир",10,3),
             new TeamWomen("Дружба",5,6),
             new TeamWomen("Жвачка",2,7),
             new TeamWomen("Жабки", 9, 3)
            };

            TeamMen[] teamM =
            {
             new TeamMen("Адмирал",12,3),
             new TeamMen("Мох",5,1),
             new TeamMen("Hop",9,3),
             new TeamMen("Nop", 15, 5)
            };

            Team[] teams = new Team[teamM.Length + teamW.Length]; // указываем теам тип данных так как у нас в массиве будут храниться объекты классво наследников теам мен и теам вумен
            for (int i = 0; i < teamM.Length; i++)
            {
                teams[i] = teamM[i];

            }
            for (int i = teamM.Length, j = 0; i < teams.Length; i++, j++) // мы берем из женского массива с самого начала с нуля и кладем в общий список команд не  с самого начала а в середину, поэтому нам надо J)
            {
                teams[i] = teamW[j];

            }
            Sort(teams);
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i].Raiting = i + 1;
            }

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i].PrintInf(); // метод выводы данных
            }
        }
       

        public static void Sort(Team[] teams)
        {


            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = 0; j < teams.Length - 1 - i; j++)
                {
                    if (teams[j].CountOfWinnings + teams[j].CountDraw < teams[j + 1].CountOfWinnings + teams[j + 1].CountDraw) //по количеству выйгранных игр 
                    {
                        var temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
                    }
                    if (teams[j].CountOfWinnings + teams[j].CountDraw == teams[j + 1].CountOfWinnings + teams[j + 1].CountDraw) // если выйгранных игр одинаковое количсево, то сортируем по количеству пропущенных и забитых очков 
                    {
                        if (teams[j].PointsScored - teams[j].PointsMissed < teams[j + 1].PointsScored - teams[j + 1].PointsMissed) // по колтчсеву забитых и пропущенных очков 
                        {
                            var temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }

                    }
                }


            }

        }
    }
}
}
