using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /// <summary>
    /// Класс, реализующий операции над дробями
    /// </summary>
    class Drobi
    {
       
        int chislitel;
        int znaminatel;
        /// <summary>
        /// создание дробей
        /// </summary>
        /// <param name="chisl">числитель</param>
        /// <param name="znam">знаменатель</param>
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
        /// <summary>
        /// приведение дроби к десятичному виду
        /// </summary>
        /// <returns>возвращает десятичный вариант дроби</returns>
        public double ToDouble()
        {
            return (double)(chislitel) / znaminatel;
        }
        /// <summary>
        /// простейшие операции над дробями
        /// </summary>
        /// <param name="odin">первая дробь</param>
        /// <param name="dva">вторая дробь</param>
        /// <returns>результат операции</returns>
        public static Drobi operator *(Drobi odin, Drobi dva)
        {
            return new Drobi(odin.chislitel * dva.chislitel, odin.znaminatel * dva.znaminatel);

        }
        public static Drobi operator +(Drobi odin, Drobi dva)
        {
            
            return new Drobi(odin.chislitel*dva.znaminatel + dva.chislitel*odin.znaminatel, odin.znaminatel*dva.znaminatel);

        }
        public static Drobi operator -(Drobi odin, Drobi dva)
        {
            
            return new Drobi(odin.chislitel * dva.znaminatel - dva.chislitel * odin.znaminatel, odin.znaminatel * dva.znaminatel);

        }
        public static Drobi operator /(Drobi odin, Drobi dva)
        {
            return new Drobi(odin.chislitel *dva.znaminatel, odin.znaminatel * dva.chislitel);

        }
        /// <summary>
        /// полуечние знака дроби (get -действия, выполняемы при получении значения свойства; set - при установке значения свойства)
        /// </summary>
        public bool Znak
        {
            get
            {
                bool a = chislitel >= 0;
                bool b = znaminatel >= 0;
                return a == b;

            }
        }
        /// <summary>
        /// замена числителя и знаменателя
        /// </summary>
        /// <param name="a">дробь</param>
        /// <param name="b">число</param>
        public delegate void Changed(Drobi a, int b);
        
        public event Changed EventChangerCh;
        public event Changed EventChangerZn;
        /// <summary>
        /// замена числителя
        /// </summary>
        public int Ch
        {
            get { return chislitel; }
            set
            {
                EventChangerCh(this, value);
                chislitel = value;
            }
        }
        /// <summary>
        /// заменя знаменателя
        /// </summary>
        public int Zn
        {
            get { return znaminatel; }
            set
            {
                EventChangerZn(this, value);
                znaminatel = value;
            }
        }
        /// <summary>
        /// получение числителя или знаменателя по индексу(в скобках присваиваются индексы числителю и знаменятелю(но это не точно))
        /// </summary>
        /// <param name="index">индекс числителя(0) или знаменателя(1)</param>
        /// <returns>если 0 - числитель, если 1 - знаменатель</returns>
        public int this[int index]
        {
            get { return (index == 0) ? chislitel : znaminatel; }
        }
    }
    /// <summary>
    /// класс, реализующий метод замены числителя или знаменателя
    /// </summary>
    class Method
    {
        /// <summary>
        /// изменение числителя
        /// </summary>
        /// <param name="a">дробь, в которой изменяем числитель</param>
        /// <param name="x">число для замены</param>
        public static void MyMethodCh(Drobi a, int x)
        {
            Console.WriteLine("Числитель изменён");
        }
        /// <summary>
        /// изменение знаменателя
        /// </summary>
        /// <param name="a">дробь, в которой заменяем знаменатель</param>
        /// <param name="x">число для замены</param>
        public static void MyMethodZn(Drobi a, int x)
        {
            Console.WriteLine("Знаменатель изменён");
        }
    }

}
    
