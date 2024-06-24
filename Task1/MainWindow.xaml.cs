using System.IO;
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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();      
        }

        public void GetFilesAllInfo()
        {
            DirectoryInfo directory = new DirectoryInfo("X://");
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            var result = files
                .Where(file => file.Name.Contains(UserInputTextBox.Text))
                .Select(file => new { file.Name, file.Extension, file.FullName, file.Length, file.CreationTime, file.LastWriteTime })
                .ToList();

            FilesDataGrid.ItemsSource = result;
        }

        private void UserInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetFilesAllInfo();
        }
    }
}