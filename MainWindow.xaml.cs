using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mdk_lab9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        static string Encoding(string зашифрованноеСлово, Dictionary<char, char> словарь)
        {
            string recoded = "";
            foreach (char буква in зашифрованноеСлово)
            {
                if (словарь.ContainsKey(буква))
                {
                    recoded += словарь[буква];
                }
                else
                {
                    recoded += буква; // Если буквы нет в словаре, оставляем ее как есть.
                }
            }
            return recoded;
        }
        Dictionary<char, char> dic1 = new Dictionary<char, char>()
{
};

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = "";
            string codedstring = codedtxt.Text;
            codedtxt.Text = "";
            //string encoded = Encoding(codedstring, dic1);
            //ResultText.Text = encoded;
            int n=int.Parse(countletter.Text);
            ResultText.Text = chastota.Text;
            string[] mas = chastota.Text.Split("\r\n");
            Dictionary<char, int> alfa = new Dictionary<char, int>();
            for(int i = 0; i < n; i++)
            {
                string[] strings = mas[i].Split(':');
                char c = char.Parse(strings[0]);
                int d=int.Parse(strings[1]);
                alfa.Add(c, d);
            }
            SortedSet<char> chars = new SortedSet<char>();
            Dictionary<char, int> beta = new Dictionary<char, int>();
            for (int i = 0;i < codedstring.Length; i++)
            {
                if (!chars.Contains(codedstring[i]))
                {
                    chars.Add(codedstring[i]);
                    int count = 1;
                    for(int j = i+1;j< codedstring.Length;j++)
                    {
                        if (codedstring[j]==codedstring[i]) count++;
                    }
                    beta.Add(codedstring[i], count);
                }
            }
            foreach (var c in alfa)
            {
                if (beta.ContainsValue(c.Value))
                {
                    char key =' ';
                    foreach(var d in beta) if(d.Value.Equals(c.Value)) { key = d.Key; break;}
                    codedstring=codedstring.Replace(key,c.Key);
                }
            }
            ResultText.Text=codedstring;
        }
    }
}