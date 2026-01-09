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

namespace WpfApp_DI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TestClass _testclass;
        public MainWindow(TestClass testClass)
        {
            InitializeComponent();
            _testclass = testClass;
            this.Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            lblMessage.Content = _testclass.Message;
        }
    }
}