using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace pratik01
{
    #region constructor sıralaması
    public class x
    {
        int a;
        public x() { Console.WriteLine(" parametresiz x"); }

        static x() { Console.WriteLine("staric x"); }

        public x(int a)
        {
            this.a = a;
            Console.WriteLine(" 1 parametreli x");
        }

    }//x

    public class y : x
    {
        int a;
        public y() { Console.WriteLine(" parametresiz y"); }



        public y(int a)
        {
            this.a = a;
            Console.WriteLine("1 parametreli y");
        }

    }//y

    public class z : y
    {
        int a;
        int b;
        public z() { Console.WriteLine("parametresiz z"); }

        public z(int a) { Console.WriteLine(" 1 parametreli z"); }

        static z() { Console.WriteLine("static z"); }


        public z(int a, int b)
        {
            this.a = a;
            this.b = b;

            Console.WriteLine("2 parametreli z");
        }

    }//z
    #endregion

    #region absract ve interface
    abstract class A
    {
        public A() { Console.WriteLine("absract classın içi"); }
        public abstract int topla(int a);

        public abstract int yas { get; set; }

        // public abstract int yas2;   // yas2 altı kızardı çünkü propertisi olmalı
        // aynı şekilde interface içinde geçerli
        public string isim { get; set; }

        // public abstract int topla(int a)  {   return a + a;  } //abstract metodun içi doldurulamaz sadece metodun adı yazılır ve kalıtım verdiği sınıfta override edilmesi şarttır 
        // "public absract"  olmalı "private absract" olamaz erişilebilir olmalı
    }

    class B : A
    {
        public override int yas { get; set; }
        public B() { Console.WriteLine("b classın içi"); }
        public override int topla(int a)   //belirtildiği gibi kalıtım aldığı sınıfın absract metodunu kullanıyor !zorunda 
        {                                  // consturtor olabilir abstact sınıfta property yapabilirisin fakat kalıtım verdiğin sınıfta değer veremiyorsun
            return a + a;
        }
        public string isim { get; set; } //eğer interface olsaydı bunun olması şarttır interfacede tanımlanan her şey kullanılıyor
                                         // fakat absract classında metot override edilemli property yazılsada olur yazılmasada olur
    }

    interface IC
    {
        void selamver();  //interface sınıfında metodlara public private yazamazsın
        int Property { get; set; }

        // public IC() { Console.WriteLine("interface içi"); } constructor tanımlayamazsın

    }
    class C : A, IC
    {
        public override int yas { get; set; }
        public C() { Console.WriteLine("c clasın içi"); }
        public int Property { get; set; } //kalıtım aldığı sınıfın adıyla aynı olmalı Ic de tanımlandığı için classada yazılmalı
        public void selamver() { Console.WriteLine("selam verildi"); } //public olması şarttır



        public override int topla(int a) { return a + a; }

    }
    #endregion 

    #region absract class örnek
    abstract class çalışan
    {
        public string isim { get; set; }
        public abstract int maaş(int maaş);
    }

    class standart : çalışan
    {
        public override int maaş(int maaş)
        {
            return maaş * 2;
        }
    }

    class muhasebeci : çalışan
    {
        public int fazlaMesaigünü;
        public muhasebeci(int fazlaMesaigünü)
        {
            this.fazlaMesaigünü = fazlaMesaigünü;
        }
        public override int maaş(int maaş)
        {
            return (maaş * 2) + ((maaş / 21) * fazlaMesaigünü);
        }
    }

    class satıçcı : çalışan
    {

        int Aylıktoplamsatış;
        public satıçcı(int Aylıktoplamsatış)
        {
            this.Aylıktoplamsatış = Aylıktoplamsatış;
        }
        public override int maaş(int maaş)
        {
            return maaş * 2 + (Aylıktoplamsatış * 10 / 100);
        }
    }
    #endregion

    #region .Net Interface
    public class MyCollection : IEnumerable<int>
    {
        private int[] öge = new int[] { 1, 2, 3, 4, 5 };

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.öge.Length; i++)
            {
                yield return this.öge[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            return this.Age.CompareTo(other.Age);
        }
    }
    #endregion

    #region sealed
    public sealed class muhurlu
    {
        public muhurlu() { Console.WriteLine("mühürlü class"); }

    }
    // public kullan:muhurlu kalıtım vermez sealed sınıf olduğu için

    public class sınıf
    {
        public virtual void metot() { Console.WriteLine("mühürsüzdür"); }

    }
    public class sealedİçerdeKullan : sınıf
    {
        public sealed override void metot() { Console.WriteLine("mühürlendi"); }

    }
    public class sealedolmuş : sealedİçerdeKullan
    {
        // public sealed override void metot() { Console.WriteLine("mühürlendi"); } //kalıtım aldığı sınıf sealed yaptığı için override edilemez

    }
    #endregion

    #region static metotlar
    class statik
    {

                  public void metoto() { Console.WriteLine("normal"); }
                  public static void metot1() { Console.WriteLine("statik 1"); }
                  public static void metot2() { Console.WriteLine("statik 2"); }

    }
    class statik2:statik
    {

        public void met() { Console.WriteLine("normal.1"); }
        public static void met1() { Console.WriteLine("statik 1.1"); }
        public static void met2() { Console.WriteLine("statik 2.1"); }

    }
    /*
     statik.metot1(); //static metotlar bu şekilde çağrılır

             statik s = new statik();
     s.metoto();// normal metotlar nesne oluşturulup çağrılır
    */

    #endregion


    #region struct
    public struct yapılar
    {
        public int yaş;
        public string isim;

        public yapılar(int yaş,string isim)
        {
            this.yaş = yaş;                 //classla arasındaki birinci fark tanımladığın her şeyi constructor içinde değer vermelisin
            this.isim = isim;
        }
        public void metot() { Console.WriteLine("metot1"); }
    }
    public class yapılar2
    {
        public int yaş;
        public string isim;

        public yapılar2(int yaş)
        {
            this.yaş = yaş;
        }
    }
    /*
    yapılar y = new yapılar(3, "s");
    yapılar y1 = new yapılar();

    //yapılar2 y = new yapılar2();//ikinci fark struccta parametresiz oluşturabilirken burada oluşturamazsın
    */
    #endregion


    public class Program
    {

        static void Main(string[] args)
        {

     
             

            Console.ReadKey();

            #region stack kuyruk
            /* 
            //stackle ters çevirme işlemi
            Stack<string> yıgın = new Stack<string>();
            yıgın.Push("giresun");
            yıgın.Push("ordu");
            yıgın.Push("trabzon");

            while (yıgın.Count > 0)
            {
                Console.WriteLine(yıgın.Pop());
            }

            Console.WriteLine("----------------------------------------------");
           
            //kuyruğa ekleme ve çıkarma işlemi
            Queue<string> kuyruk = new Queue<string>();
            kuyruk.Enqueue("giresun");
            kuyruk.Enqueue("ordu");
            kuyruk.Enqueue("trabzon");

            while (kuyruk.Count > 0)
            {
                Console.WriteLine(kuyruk.Dequeue());
            }
            */
            #endregion
            #region .Net interface run
            /*
            
          MyCollection myCollection = new MyCollection();
      foreach (var item in myCollection)
      {
          Console.WriteLine(item);
      }

          Console.WriteLine("-----------------------------------------------------------------------");

          Person[] people = {
          new Person { Name = "Alice", Age = 30 },
          new Person { Name = "Bob", Age = 25 },
          new Person { Name = "Charlie", Age = 35 }
      };

          Array.Sort(people);

          foreach (var person in people)
          {
              Console.WriteLine($"{person.Name}, Age {person.Age}");
          }
            */
            #endregion

        }


    }
}
