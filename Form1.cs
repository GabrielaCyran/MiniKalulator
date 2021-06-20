using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projektMiniKalk
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Zmienna o nazwie "calkowitawartosc1" typu string potrzebna do przechowywania ciągu znaków wpisanych przez użytkownika
        /// </summary>     
        string calkowitawartosc1 = "";

        ///<summary> Funkcja  programu o nazwie Spliter zwracająca typ int</summary>
        public int Spliter()
        {
            ///  <summary>zmienna <c>lenghtOfTotalValue </c> przechowujaca nam dlugosc ciagu znaków wpisanych przez uzytkownika</summary>
            ///  <summary>Lista typu char <c>List<char> operators = new List<char>()</c> która 
            ///  przechowuje  operatory
            ///  </summary>
            ///  <summary><c> List<int> myNumbers = new List<int>();</c>Lista typu int 
            ///  która przechowuje liczby </summary>
            ///  <summary>
            ///  <c>sum</c> Zmienna która  bedzie przetrzymywac kolejno ciag znakow podczas wykonywania petli do utworzenia liczby większej niż jednocyfrowej
            /// </summary>
            /// <summary> <c> j =0</c> wartość zawsze stała i nie zmienna</summary>
            int lenghtOfTotalValue = calkowitawartosc1.Length;

            List<char> operators = new List<char>();
            List<int> myNumbers = new List<int>();
            string sum = "";
            string lastNumber = "";
            const int j = 0;



            for (int i = 0; i < lenghtOfTotalValue; i++)
            {       ///<summary>
                    ///Petla for ktora ma za zadanie rozbicie stringa na Liste liczb oraz znakow
                    ///</summary>
                    ///<summary>
                    /// jesli warunek zostanie spelniony  to do zmiennej <c>sum</c> dodajemy  kolejne znaki liczbowe.
                    /// Nastepnie z naszej zmiennej calkowitawartosc1 ktora przechowuje nam ten ciag znakow usuwamy wykorzystany elemen  
                    /// usuwamy go za pomocą funkcji Substring. Jesli nie spelnia nam warunku oznacza to ze jest to operator.
                    /// Wtedy  wykonuje operacje dodania do Listy ktora przechowuje liczbe sumy z jej zawartoscia dodajac zmienną sum
                    /// nastepnie czysci nam zmienna sum ( dzieki czemu zwalnia nam  miejsce na przechowywanie kolejnego ciagu znakow liczbowych) 
                    /// a do Listy operatorow dodaje "operator"
                    ///Ponownie Usuwa ze zmiennej calkowitej  element przez wykorzystanie funkcji Substring.
                    ///</summary>


                if (calkowitawartosc1[j] == '1' || calkowitawartosc1[j] == '2' || calkowitawartosc1[j] == '3' ||
                    calkowitawartosc1[j] == '4' || calkowitawartosc1[j] == '5' || calkowitawartosc1[j] == '6' ||
                    calkowitawartosc1[j] == '7' || calkowitawartosc1[j] == '8' || calkowitawartosc1[j] == '9' ||
                    calkowitawartosc1[j] == '0') 
                {
                    sum += calkowitawartosc1[j];
                    calkowitawartosc1 = calkowitawartosc1.Substring(1);
                }
                else
                {
                    myNumbers.Add(Int32.Parse(sum));
                    sum = "";
                    operators.Add(calkowitawartosc1[j]);
                    calkowitawartosc1 = calkowitawartosc1.Substring(1);
                }
            }

            myNumbers.Add(Int32.Parse(sum));

            //w pierwszej kolejności * oraz /

            ///<summary>Po wykonaniu pierwszej pętli for następnie sprawdzamy czy byl to operator * lub / . Mają one "pierwszeństwo "
            ///  Przed nami są 2 pętle for, w pierwszej sprawdzamy operatory, które są wykonywane w pierwszej kolejności, jak mnnożenie
            ///  czy dzielenie, dodawanie i odejmowanie jest później.
            ///  Pętle przechodzą przez każdy operator ze stosu i sprawdzają czym jest. W zależności od tego jaki to operator wykonują 
            ///  odpowiadającą mu operację na liczbie w liście o tym samym numerze oraz liczbie o numerze o jeden większym.
            ///  W każdym działaniu matematycznym liczb jest zawsze o 1 więcej niż operatorów, dzięki temu ten algorytm ma prawo działać.
            ///  Tak samo jak wyżej, element, który jest sprawdzony, a tym samym "użyty" zostaje wyrzucony z całego zbioru i nie będzie
            ///  już brany pod uwagę.
            ///</summary>
            for (int i = 0; i < operators.Count; i++) // i =0 operator. count (liczba operatorów w polu tekstowym )
            {

                if (operators[i] == '*')
                {
                    myNumbers[i] *= myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
                else if (operators[i] == '/')
                {
                    myNumbers[i] /= myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            //następnie + oraz -
            for (int i = 0; i < operators.Count; i++)
            {

                if (operators[i] == '+')
                {
                    myNumbers[i] += myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
                else if (operators[i] == '-')
                {
                    myNumbers[i] -= myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            return myNumbers[0]; // jako wynik zwracamy wartość indeksu 0 czyli nasz wynik.

        }


        /// <summary>
        /// Funkcja  o nazwie spliterTest zawierająca to samo ciało co funkcja Spliter. Używana do
        /// testów jednostkowych
        /// </summary>
        /// <param name="totalValue"> Zmienna która  pobiera ciąg znaków </param>
        /// <returns> </returns>
        public int SpliterTest(string totalValue)
        {
            //miejsca na zmienne
            int lenghtOfTotalValue = totalValue.Length;//5
            List<char> operators = new List<char>();//+*
            List<int> myNumbers = new List<int>();//231 2 2
            string sum = "";//2
            string lastNumber = "";
            const int j = 0;

            //rozbija string na listę liczb oraz na listę operatorów
            for (int i = 0; i < lenghtOfTotalValue; i++)
            {
                if (totalValue[j] == '1' || totalValue[j] == '2' || totalValue[j] == '3' ||
                    totalValue[j] == '4' || totalValue[j] == '5' || totalValue[j] == '6' ||
                    totalValue[j] == '7' || totalValue[j] == '8' || totalValue[j] == '9' ||
                    totalValue[j] == '0')
                {
                    sum += totalValue[j];
                    totalValue = totalValue.Substring(1);
                }
                else
                {
                    myNumbers.Add(Int32.Parse(sum));
                    sum = "";//100
                    operators.Add(totalValue[j]);
                    totalValue = totalValue.Substring(1);
                }
            }
            myNumbers.Add(Int32.Parse(sum));

            //w pierwszej kolejności * oraz /
            for (int i = 0; i < operators.Count; i++)
            {

                if (operators[i] == '*')
                {
                    myNumbers[i] *= myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
                else if (operators[i] == '/')
                {
                    myNumbers[i] /= myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            //następnie + oraz -
            for (int i = 0; i < operators.Count; i++)
            {

                if (operators[i] == '+')
                {
                    myNumbers[i] += myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
                else if (operators[i] == '-')
                {
                    myNumbers[i] -= myNumbers[i + 1];
                    myNumbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            return myNumbers[0];
        }

        /// <summary>
        /// Konstruktor  klasy Form1
        /// </summary>
        public Form1()
        {

            InitializeComponent();
        }
        /// <summary>
        ///Zdarzenie dla kontrolki zero. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void zero_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "0";
            textBox1.Text = calkowitawartosc1;


        }
        /// <summary>
        ///Zdarzenie dla kontrolki nine. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void nine_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "9";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki eight. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void eight_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "8";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki seven. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void seven_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "7";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki six. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void six_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "6";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki five. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void five_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "5";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki four. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void four_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "4";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki three. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void three_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "3";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki two. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void two_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "2";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki one. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void one_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "1";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki Equals. Po naciśnięciu kontrolki do pola tekstowego umieszczona jest 
        ///wartość zwrócona z naszej funkcji Spliter. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            textBox1.Text = Spliter().ToString();
        }
        /// <summary>
        ///Zdarzenie dla kontrolki buttonMultiply. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "*";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki buttonDivide. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "/";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki buttonMinus. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "-";
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki buttonPlus. Po naciśnięciu kontrolki  wartość która jest przechowywana
        ///w zmiennej calkowitawartosc1 zostaje umieszczona w polu tekstowym 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            calkowitawartosc1 += "+";
            textBox1.Text = calkowitawartosc1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        


        /// <summary>
        ///Zdarzenie dla kontrolki button2. Po naciśnięciu kontrolki  ciąg znaków znajdujący sie w polu tekstowym zostaje wyczyszczony 
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click_1(object sender, EventArgs e)
        {
            calkowitawartosc1 = "";
            textBox1.Text = calkowitawartosc1;
        }

        /// <summary>
        ///Zdarzenie dla kontrolki button3. Po naciśnięciu  wyskakuje powiadomienie "Do zobaczenia" i aplikacja zamyka się
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Do zobaczenia!");
            Close();
        }

        /// <summary>
        ///Zdarzenie dla kontrolki button1. Po naciśnięciu kontrolki  zmniejszamy długość ciągu znaków w polu tekstowym o 1 </summary>

        private void button1_Click_1(object sender, EventArgs e)
        {
            calkowitawartosc1 = calkowitawartosc1.Remove(calkowitawartosc1.Length - 1, 1);
            textBox1.Text = calkowitawartosc1;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki radiobutton1. Po zaznaczeniu  kontrolki  zmieniamy kolor  kontrolek oraz pola tekstowego na lazurowy
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttCofnij.BackColor = Color.Azure;
            button3.BackColor = Color.Azure;
            button2.BackColor = Color.Azure;
            buttonDivide.BackColor = Color.Azure;
            buttonMinus.BackColor = Color.Azure;
            siedem.BackColor = Color.Azure;
            szesc.BackColor = Color.Azure;
            pięć.BackColor = Color.Azure;
            dziewiec.BackColor = Color.Azure;
            jeden.BackColor = Color.Azure;
            osiem.BackColor = Color.Azure;
            buttonPlus.BackColor = Color.Azure;
            buttonMultiply.BackColor = Color.Azure;
            cztery.BackColor = Color.Azure;
            buttonEquals.BackColor = Color.Azure;
            dwa.BackColor = Color.Azure;
            zero.BackColor = Color.Azure;
            trzy.BackColor = Color.Azure;
            textBox1.BackColor = Color.Azure;
        }
        /// <summary>
        ///Zdarzenie dla kontrolki radiobutton2. Po zaznaczeniu  kontrolki  zmieniamy kolor  kontrolek oraz pola tekstowego na różowy 
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            buttCofnij.BackColor = Color.DeepPink;
            button3.BackColor = Color.DeepPink;
            button2.BackColor = Color.DeepPink;
            buttonDivide.BackColor = Color.DeepPink;
            buttonMinus.BackColor = Color.DeepPink;
            siedem.BackColor = Color.DeepPink;
            szesc.BackColor = Color.DeepPink;
            pięć.BackColor = Color.DeepPink;
            dziewiec.BackColor = Color.DeepPink;
            jeden.BackColor = Color.DeepPink;
            osiem.BackColor = Color.DeepPink;
            buttonPlus.BackColor = Color.DeepPink;
            buttonMultiply.BackColor = Color.DeepPink;
            cztery.BackColor = Color.DeepPink;
            buttonEquals.BackColor = Color.DeepPink;
            dwa.BackColor = Color.DeepPink;
            zero.BackColor = Color.DeepPink;
            trzy.BackColor = Color.DeepPink;
            textBox1.BackColor = Color.DeepPink;
        }

    
    }
}
