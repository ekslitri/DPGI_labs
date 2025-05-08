using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace lab2WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, execute_Clear, canExecute_Clear));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, execute_Copy, canExecute_Copy));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, execute_Paste, canExecute_Paste));
        }

        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.Text.Trim().Length > 0;
        }

        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            File.WriteAllText("d:\\myFile.txt", inputTextBox.Text);
            MessageBox.Show("The file was saved!");
        }

        void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                inputTextBox.Text = File.ReadAllText(dialog.FileName);
            }
        }

        void canExecute_Clear(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.Text.Length > 0;
        }

        void execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Clear();
        }

        void canExecute_Copy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = inputTextBox.SelectionLength > 0;
        }

        void execute_Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(inputTextBox.SelectedText);
        }

        void canExecute_Paste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        void execute_Paste(object sender, ExecutedRoutedEventArgs e)
        {
            int caretIndex = inputTextBox.CaretIndex;
            inputTextBox.Text = inputTextBox.Text.Insert(caretIndex, Clipboard.GetText());
            inputTextBox.CaretIndex = caretIndex + Clipboard.GetText().Length;
        }
    }
}
