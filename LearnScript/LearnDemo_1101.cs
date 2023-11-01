using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnScript
{

    public class Person
    {
        private static Random random = new Random();
        private static List<int>ids= new List<int>();
        private int id;
        private string name;
        private int age;
        private int hash;

        public int Id {
            get { return id; } 
        }
        public string Name { 
            get { return name; } 
            private set { name = value; }
        }
        public int Age {
            get { return age; }
            set { 
                if(age < 0 ) age = 0;
                age = value;
            } 
        }
        public int Hash { get { return hash; } }

        public Person():this("",0)
        {

        }
        public Person(string name) : this(name, 0)
        {

        }
        public Person(int age) : this("", age)
        {

        }

        public Person(string name, int age)
        {
            if(ids.Count==0)
            {
                this.id = 0;
                ids.Add(this.id);
            }
            else
            {
                this.id=ids.Last()+1;
                ids.Add(this.id);
            }
            this.name = name;
            this.age = age;
            hash = random.Next(1000,9999);
        }

        public override string ToString()
        {
            return "id=" + id + ",namg=" + name + ",age=" + age + ",hash=" + hash;
        }
    }

    public class LearnDemo_1101
    {

        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            for(int i=0;i<10; i++)
            {
                list.Add(new Person());
            }
            foreach(Person p in list)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadLine();
        }
    }
}
