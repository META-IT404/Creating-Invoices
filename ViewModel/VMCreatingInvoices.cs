using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Input;
using Creating_Invoices.Model;
using Creating_Invoices.ViewModel.Base;
using static Creating_Invoices.Model.WorkingToDB;

namespace Creating_Invoices.ViewModel
{
    internal class VMCreatingInvoices : Base.ViewModel
    {
        private List<CollationWindow> collationWindows = new List<CollationWindow>();
        private List<CollationWindowRange> collationWindowsRange = new List<CollationWindowRange>();
        private List<CollationWindowRangeShop> collationWindowsRangeShop = new List<CollationWindowRangeShop>();
        private string _title = "Редактор накладных: создание| Версия " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }
        private bool _isEnebled = false;
        public bool IsEnebled
        {
            get { return _isEnebled; }
            set { _isEnebled = value; OnPropertyChanged(nameof(IsEnebled)); }
        }

        private string _selectInvoicesName;
        public string SelectInvoicesName
        {
            get => _selectInvoicesName;
            set
            {
                _selectInvoicesName = value;
                OnPropertyChanged(nameof(SelectInvoicesName));
            }
        }

        private ObservableCollection<bool> _isSelectTabControl = new ObservableCollection<bool>() { false, false, false, false, false };
        public ObservableCollection<bool> IsSelectTabControl
        {
            get { return _isSelectTabControl; }
            set
            {
                _isSelectTabControl = value;
                OnPropertyChanged(nameof(IsSelectTabControl));
            }
        }
        private ObservableCollection<bool> _isSelectTabControlExpenditure = new ObservableCollection<bool>() { false, false, false, false, false };
        public ObservableCollection<bool> IsSelectTabControlExpenditure
        {
            get { return _isSelectTabControl; }
            set
            {
                _isSelectTabControl = value;
                OnPropertyChanged(nameof(IsSelectTabControlExpenditure));
            }
        }
        private ObservableCollection<Shop> shops = new ObservableCollection<Shop>() { new Shop(), new Shop(), new Shop(), new Shop(), new Shop() };
        public ObservableCollection<Shop> Shops
        {
            get { return shops; }
            set { shops = value; OnPropertyChanged(nameof(Shops)); }
        }
        #region Команды

        public ICommand StartCollation { get; }
        private void OnStartCollation(object par)
        {
            collationWindows.Add(new CollationWindow());
            collationWindows[collationWindows.Count - 1].Show();
        }
        public ICommand CreatingReceiptInvoice { get; }
        private void OnCreatingReceiptInvoice(object par)
        {
            try
            {
                for (int i = 0; i < IsSelectTabControl.Count; i++)
                {
                    if (IsSelectTabControl[i])
                    {
                        string nameDateBase;
                        switch (i)
                        {
                            case 0:
                                nameDateBase = "ReceiptOfGoodsMendeleeva42";
                                break;
                            case 1:
                                nameDateBase = "ReceiptOfGoodsMendeleeva5";
                                break;
                            case 2:
                                nameDateBase = "ReceiptOfGoodsMaykovskogo4";
                                break;
                            case 3:
                                nameDateBase = "ReceiptOfGoodsDostoevskogo11a";
                                break;
                            case 4:
                                nameDateBase = "ReceiptOfGoodsVodoprovodnay358";
                                break;
                            default:
                                StaticViewClass.Mess("Обратитесь к разработчику\nПеречисление не нашло имя таблицы");
                                return;
                        }
                        AddToDBEntrance(nameDateBase, Shops[i]);
                        for (int j = 0; j < Shops[i].namePropBuy.Length; j++)
                        {
                            Shops[i].GetType().GetProperty(Shops[i].namePropBuy[j]).SetValue(Shops[i], 0m);
                            if (j < Shops[i].namePropSell.Length)
                            {
                                Shops[i].GetType().GetProperty(Shops[i].namePropSell[j]).SetValue(Shops[i], 0m);
                                Shops[i].GetType().GetProperty(Shops[i].namePropPercent[j]).SetValue(Shops[i], 25m);
                            }
                        }
                        Shops[i].TotalAmountBuy = 0;
                        Shops[i].TotalAmountSell = 0;
                        Shops[i].RevaluationMinus = 0;
                        Shops[i].WriteDowns = 0;
                        Shops[i].Date = null;
                    }
                }

            }
            catch (Exception ex)
            {
                StaticViewClass.Mess($"Ошибка базы данных, отправьте фото ошибки разработчику\n{ex.Message}");
            }
        }
        public ICommand CreatingOverheadExpense { get; }
        private void OnCreatingOverheadExpense(object par)
        {
            try
            {
                for (int i = 0; i < IsSelectTabControlExpenditure.Count; i++)
                {
                    if (IsSelectTabControlExpenditure[i])
                    {
                        string nameDateBase;
                        switch (i)
                        {
                            case 0:
                                nameDateBase = "ConsumptionOfGoodsMendeleeva42";
                                break;
                            case 1:
                                nameDateBase = "ConsumptionOfGoodsMendeleeva5";
                                break;
                            case 2:
                                nameDateBase = "ConsumptionOfGoodsMaykovskogo4";
                                break;
                            case 3:
                                nameDateBase = "ConsumptionOfGoodsDostoevskogo11a";
                                break;
                            case 4:
                                nameDateBase = "ConsumptionOfGoodsVodoprovodnay358";
                                break;
                            default:
                                StaticViewClass.Mess("Обратитесь к разработчику\nПеречисление не нашло имя таблицы");
                                return;
                        }
                        AddToDBExpenditure(nameDateBase, Shops[i].DateExpenditure, Shops[i].dateExpenditure, Shops[i].TotalAmountExpenditure);
                        for (int j = 0; j < Shops[i].dateExpenditure.Count; j++)
                        {
                            Shops[i].GetType().GetProperty(Shops[i].namePropExpenditure[j]).SetValue(Shops[i], 0m);
                            Shops[i].DateExpenditure = null;
                            Shops[i].TotalAmountExpenditure = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                StaticViewClass.Mess($"Ошибка базы данных, отправьте фото ошибки разработчику\n{ex.Message}");
            }

        }
        public ICommand StartCollationRange { get; }
        private void OnStartCollationRange(object par)
        {
            collationWindowsRange.Add(new CollationWindowRange());
            collationWindowsRange[collationWindowsRange.Count - 1].Show();
        }
        public ICommand StartCollationRangeProvider { get; }
        private void OnStartCollationRangeProvider(object par)
        {
            collationWindowsRangeShop.Add(new CollationWindowRangeShop());
            collationWindowsRangeShop[collationWindowsRangeShop.Count - 1].Show();
        }
        public ICommand ClouseThread { get; }
        private void OnClouseThread(object par)
        {
            threadCalculationAmountBuy.Abort();
            threadCalculationAmountSell.Abort();
            for (int i = 0; i < collationWindows.Count; i++)
            {
                collationWindows[i]?.Close();
            }
            collationWindows?.Clear();
            collationWindowsRange?.Clear();
            App.Current.Shutdown();
            throw new Exception();
        }
        #endregion
        Thread threadCalculationAmountBuy;
        Thread threadCalculationAmountSell;
        Thread threadCalculationAmountExpenditure;
        Thread threadCalculationSell;
        public VMCreatingInvoices()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DBCreate";
            if (!File.Exists(path + "\\DatabaseInvoices.mdf"))
            {
                Directory.CreateDirectory(path);
                File.Copy(Directory.GetCurrentDirectory() + "\\Resources\\DatabaseInvoices.mdf", path + "\\DatabaseInvoices.mdf");
            }
            for (int i = 0; i < Shops.Count; i++)
            {
                for (int j = 0; j < Shops[i].namePropPercent.Length; j++)
                {
                    Shops[i].GetType().GetProperty(Shops[i].namePropPercent[j]).SetValue(Shops[i], 25m);
                }
            }
            //RequestToDB = new LamdaCommand(OnRequestToDB, CanRequestToDB);
            ClouseThread = new LamdaCommand(OnClouseThread);
            CreatingReceiptInvoice = new LamdaCommand(OnCreatingReceiptInvoice);
            CreatingOverheadExpense = new LamdaCommand(OnCreatingOverheadExpense);
            StartCollation = new LamdaCommand(OnStartCollation);
            StartCollationRange = new LamdaCommand(OnStartCollationRange);
            StartCollationRangeProvider = new LamdaCommand(OnStartCollationRangeProvider);

            threadCalculationAmountBuy = new Thread(CalculationAmountBuy);
            threadCalculationAmountSell = new Thread(CalculationAmountSell);
            threadCalculationAmountExpenditure = new Thread(CalculationTotalAmountExpenditure);
            threadCalculationSell = new Thread(CalculationSell);
            threadCalculationSell.Start();
            threadCalculationAmountBuy.Start();
            threadCalculationAmountSell.Start();
            threadCalculationAmountExpenditure.Start();
        }
        #region Расчёт при создании накладной прихода
        private void CalculationAmountBuy()
        {
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < Shops.Count; i++)
                {
                    Shops[i].TotalAmountBuy = Shops[i].dateEntranceBuy.Sum();
                    Shops[i].TotalAmountBuy = Shops[i].TotalAmountBuy - (Shops[i].RevaluationMinus + Shops[i].WriteDowns);
                }
            }
        }

        private void CalculationAmountSell()
        {
            while (true)
            {
                Thread.Sleep(100);

                for (int i = 0; i < Shops.Count; i++)
                {
                    decimal currentDecemal = 0;
                    for (int j = 0; j < Shops[i].dateEntranceSell.Count; j++)
                    {
                        currentDecemal += Shops[i].dateEntranceSell[j];
                    }
                    currentDecemal = currentDecemal + Shops[i].Base1 + Shops[i].Base2 + Shops[i].Base3 + 
                        Shops[i].RevaluationPlus - (Shops[i].RevaluationMinus + Shops[i].WriteDowns);
                    Shops[i].TotalAmountSell = currentDecemal;
                }
            }
        }
        #endregion
        #region Расчет накладной расхода
        private void CalculationTotalAmountExpenditure()
        {
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < Shops.Count; i++)
                {
                    decimal totalDecemal = 0;
                    for (int j = 0; j < Shops[i].dateExpenditure.Count; j++)
                    {
                        totalDecemal += Shops[i].dateExpenditure[j];
                    }
                    Shops[i].TotalAmountExpenditure = totalDecemal;
                }
            }
        }
        #endregion
        public void CalculationSell()
        {

            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < Shops.Count; i++)
                {
                    for (int j = 0; j < Shops[i].namePropSell.Length; j++)
                    {
                        decimal dec = Shops[i].dateEntrancePercent[j] * 0.01M * Shops[i].dateEntranceBuy[j] + Shops[i].dateEntranceBuy[j];
                        Shops[i].GetType().GetProperty(Shops[i].namePropSell[j]).SetValue(Shops[i], dec);
                        //Shops[i].dateEntranceSell[j] = Shops[i].dateEntrancePercent[j] * 0.01M * Shops[i].dateEntranceBuy[j] + Shops[i].dateEntranceBuy[j];
                        //OnPropertyChanged(Shops[i].namePropSell[j]);
                    }
                }
            }
        }
    }
}
