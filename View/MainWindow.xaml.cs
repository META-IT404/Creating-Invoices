using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Creating_Invoices.Model;
using MahApps;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Creating_Invoices
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            StaticViewClass.Message += StaticViewClass_Message;
        }

        private void StaticViewClass_Message()
        {
            this.ShowMessageAsync("Ошибка",StaticViewClass._mess);
        }
    }
}
