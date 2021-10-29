using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Drobi
    {
       
        int chislitel;
        int znaminatel;
        public Drobi(int chisl, int znam)
        {
            chislitel = chisl;
            znaminatel = znam;

        }
        public Drobi(int chislo)
        {
            chislitel = chislo;
            znaminatel = 1;
        }
        public Drobi(int celoe, int chislit, int znamen)
        {
            chislitel = celoe * znamen + chislit;
            znaminatel = znamen;
        }
        public double ToDouble()
        {
            return (double)(chislitel) / znaminatel;
        }
        public static Drobi operator *(Drobi odin, Drobi dva)
        {
            return new Drobi(odin.chislitel * dva.chislitel, odin.znaminatel * dva.znaminatel);

        }
        public static Drobi operator +(Drobi odin, Drobi dva)
        {
            if (odin.znaminatel!=dva.znaminatel)
            {
                odin.chislitel = odin.chislitel * dva.znaminatel;
                odin.znaminatel = odin.znaminatel * dva.znaminatel;
                dva.chislitel = dva.chislitel * odin.znaminatel;
                dva.znaminatel = dva.znaminatel * odin.znaminatel;
            }
            return new Drobi(odin.chislitel + dva.chislitel, odin.znaminatel);

        }
        public static Drobi operator -(Drobi odin, Drobi dva)
        {
            if (odin.znaminatel != dva.znaminatel)
            {
                odin.chislitel = odin.chislitel * dva.znaminatel;
                odin.znaminatel = odin.znaminatel * dva.znaminatel;
                dva.chislitel = dva.chislitel * odin.znaminatel;
                dva.znaminatel = dva.znaminatel * odin.znaminatel;
            }
            return new Drobi(odin.chislitel - dva.chislitel, odin.znaminatel);

        }
        public static Drobi operator /(Drobi odin, Drobi dva)
        {
            return new Drobi(odin.chislitel *dva.znaminatel, odin.znaminatel * dva.chislitel);

        }
        public bool Znak
        {
            get
            {
                bool a = chislitel >= 0;
                bool b = znaminatel >= 0;
                return a == b;

            }
        }
        public delegate void Changed(Drobi a, int b);

        public event Changed EventChangerCh;
        public event Changed EventChangerZn;
        public int Ch
        {
            get { return chislitel; }
            set
            {
                EventChangerCh(this, value);
                chislitel = value;
            }
        }
        public int Zn
        {
            get { return znaminatel; }
            set
            {
                EventChangerZn(this, value);
                znaminatel = value;
            }
        }
        public int this[int index]
        {
            get { return (index == 0) ? chislitel : znaminatel; }
        }
    }
    class Method
    {
        public static void MyMethodCh(Drobi a, int x)
        {
            Console.WriteLine("Числитель изменён");
        }
        public static void MyMethodZn(Drobi a, int x)
        {
            Console.WriteLine("Знаменатель изменён");
        }
    }

}
    
