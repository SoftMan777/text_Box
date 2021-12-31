using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace Блокнот
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

        private void MenuOpen(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы | *.txt";
            var result = dialog.ShowDialog();
            if (result == true)
                Texbox.Text = File.ReadAllText(dialog.FileName);
        }
        private void MenuCreate(object sender, RoutedEventArgs e)
        {
            string textMess = "Вы действительно хотите обновить файл?\n" + "Все веденные данные будут удалены!";
            string caption = "Предупреждение";
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(textMess,caption,button,icon);
            if (result == MessageBoxResult.Yes)
                Texbox.Text = null;
        }
        private void MenuSave(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Текстовые файлы | *.txt";
            var result = dialog.ShowDialog();
            if (result == true)
                File.WriteAllText(dialog.FileName, Texbox.Text);
        }
        private void MSave(object sender, RoutedEventArgs e)

        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Текстовые файлы | *.txt";
            var result = dialog.ShowDialog();
            if (result == true)
                File.WriteAllText(dialog.FileName, Texbox.Text);
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MenuUndo_Click(object sender, RoutedEventArgs e)
        {
            Texbox.Undo();
        }
        private void MenuRedo_Click(object sender, RoutedEventArgs e)
        {
            Texbox.Redo();
        }
        private void MenuAbout_Click(object sender, RoutedEventArgs e)

        {
            var about = new Window1();
            about.Show();

        }
    }
}
