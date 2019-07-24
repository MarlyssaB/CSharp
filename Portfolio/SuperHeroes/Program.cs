using System;

namespace SuperHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            person p = new person("William", "Bill");
            person q = new person("Kathryn", "Kate");
            person r = new person("Alexandria", "Lexi");

            SuperHero sp = new SuperHero("super strength", "Wade Turner", "Mr. Incredible");
            SuperHero hr = new SuperHero("super speed", "Alana Norton", "Nelvana of the North");
            SuperHero tv = new SuperHero("super bravery", "John Aman", "Amazing-Man");
            
            Villain v = new Villain("Batman", "The Joker");
            Villain a = new Villain("The Doctor", "The Master");
            Villain b = new Villain("Sherlock Holmes","Professor Moriarty");

            p.PrintGreeting();
            q.PrintGreeting();
            r.PrintGreeting();
            Console.WriteLine();
            sp.PrintGreeting();
            hr.PrintGreeting();
            tv.PrintGreeting();
            Console.WriteLine();
            v.PrintGreeting();
            a.PrintGreeting();
            b.PrintGreeting();

            Console.Read();
        }

    public class person
        {
            public string Name { get; set; }
            public string NickName { get; set; }
           
            public person(string name, string nickName)
            {
                Name = name;
                NickName = nickName;
            }


            public void PrintGreeting()
            {
                Console.WriteLine("{0} : Hi! My name is {0}, but you can call me {1}.", Name, NickName);
            }
            
        }
    public class SuperHero : person
        {
            public string SuperPower { get; set; }
            public string RealName { get; set; }

            public SuperHero(string superPower, string realName, string name): base(name, null)
            {
                SuperPower = superPower;
                RealName = realName;
            }

            public new void PrintGreeting()
            {
              
                Console.WriteLine("{0} : I am {1}. When I am {0}, my power is {2}!", Name, RealName, SuperPower);

            }
        }
    public class Villain : person
        {
            public string Nemesis { get; set; }

            public Villain(string nemesis, string name) : base(name, null)
            {
                Nemesis = nemesis;
            }

            public new void PrintGreeting()
            {
               
                Console.WriteLine("{0} : I am {0}! Have you seen {1}?", Name, Nemesis);
            }
        }
    }
}
