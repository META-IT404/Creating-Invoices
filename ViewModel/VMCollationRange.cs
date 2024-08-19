using Creating_Invoices.Model;
using Creating_Invoices.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Creating_Invoices.ViewModel
{
    internal class VMCollationRange : Base.ViewModel
    {
        private string _title = "Редактор накладных: сверка по диапозону| Версия " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }
        private decimal _precent;
        private decimal _precentZP;
        public decimal Precent
        {
            get => _precent;
            set { _precent = value; CalculationPrecentZP(); OnPropertyChanged(nameof(Precent)); }
        }
        public decimal PrecentZP
        {
            get => _precentZP;
            set { _precentZP = value;  OnPropertyChanged(nameof(PrecentZP)); }
        }
        private ObservableCollection<Shop> shops = new ObservableCollection<Shop>();
        public ObservableCollection<Shop> Shops
        {
            get { return shops; }
            set { shops = value; OnPropertyChanged(nameof(Shops)); }
        }
        private ObservableCollection<string> dateTimes;
        public ObservableCollection<string> DateTimes
        {
            get { return dateTimes; }
            set { dateTimes = value; OnPropertyChanged(nameof(DateTimes)); }
        }
        private ObservableCollection<string> _collationData = new ObservableCollection<string>();
        public ObservableCollection<string> CollationData
        {
            get { return _collationData; }
            set { _collationData = value; OnPropertyChanged(nameof(CollationData)); }
        }
        private ObservableCollection<decimal> _collationTotalAmountBuy = new ObservableCollection<decimal>();
        public ObservableCollection<decimal> CollationTotalAmountBuy
        {
            get { return _collationTotalAmountBuy; }
            set { _collationTotalAmountBuy = value; OnPropertyChanged(nameof(CollationTotalAmountBuy)); }
        }
        private ObservableCollection<decimal> _collationTotalAmountExpenditure = new ObservableCollection<decimal>();
        public ObservableCollection<decimal> CollationTotalAmountExpenditure
        {
            get { return _collationTotalAmountExpenditure; }
            set { _collationTotalAmountExpenditure = value; OnPropertyChanged(nameof(CollationTotalAmountExpenditure)); }
        }
        private ObservableCollection<decimal> _collationTotalAmountSell = new ObservableCollection<decimal>();
        public ObservableCollection<decimal> CollationTotalAmountSell
        {
            get { return _collationTotalAmountSell; }
            set { _collationTotalAmountSell = value; OnPropertyChanged(nameof(CollationTotalAmountSell)); }
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
        private ObservableCollection<bool> selectInvoices = new ObservableCollection<bool> { false, false };
        public ObservableCollection<bool> SelectInvoices
        {
            get { return selectInvoices; }
            set { selectInvoices = value; OnPropertyChanged(nameof(SelectInvoices)); }
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
        private string[] shopName = { "НевХолод", "Пятигорск", "Абдурахманов", "Абдурахманов2", "Авозин", "Вардумян", "Мария", "Мелконян", "Мелконян2",
        "Коляда", "Фатима", "Иминов", "Хлебодар", "Текеев", "Текеев2", "Токов", "Тищенко", "Фарше", "Корма", "Корма2", "Люля", "Лаваш Григорян", "Хлебком Невинномысск",
        "Хлебком Невинномысск2", "Айсанов", "Иней", "База 1", "База 2", "База 3", "Переоценка +", "Переоценка -", "Списание", "Общая сумма"};

        public string[] ShopName
        {
            get { return shopName; }
        }

        private string selectShopName;
        public string SelectShopName
        {
            get { return selectShopName; }
            set { selectShopName = value; OnPropertyChanged(nameof(SelectShopName)); }
        }

        private string selectedDateTimeOne;
        public string SelectedDateTimeOne
        {
            get => selectedDateTimeOne;
            set
            {
                selectedDateTimeOne = value;
                OnPropertyChanged(nameof(SelectedDateTimeOne));
                if (SelectInvoices[0])
                {
                    GetDate();
                }
                else if (SelectInvoices[1])
                {
                    GetDateExpenditure();
                }
            }
        }
        private string selectedDateTimeTwo;
        public string SelectedDateTimeTwo
        {
            get => selectedDateTimeTwo;
            set
            {
                selectedDateTimeTwo = value;
                OnPropertyChanged(nameof(SelectedDateTimeTwo));
                if (SelectInvoices[0])
                {
                    GetDate();
                }
                else if (SelectInvoices[1])
                {
                    GetDateExpenditure();
                }
            }
        }
        private void GetDate()
        {
            for (int i = 0; i < IsSelectTabControl.Count; i++)
            {
                if (IsSelectTabControl[i])
                {
                    string nameDateBase;
                    string shopNameBuy;
                    string shopNameSell;
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
        //            switch(SelectShopName)
        //            {
        //                case "НевХолод":
        //                    shopNameBuy = "NevholodBuy";
        //                    shopNameSell = "NevholodSell";
        //                    break;
        //                case "Пятигорск":
        //                    shopNameBuy = "PyatigorskBuy";
        //                    shopNameSell = "PyatigorskSell";
        //                    break;
        //                case "Абдурахманов":
        //                    shopNameBuy = "AbdurahmanovBuy";
        //                    shopNameSell = "AbdurahmanovSell";
        //                    break;
        //                case "Абдурахманов2":
        //                    shopNameBuy = "AbdurahmanovBuy2";
        //                    shopNameSell = "AbdurahmanovSell2";
        //                    break;
        //                case "Авозин":
        //                    shopNameBuy = "AvozinBuy";
        //                    shopNameSell = "AvozinSell";
        //                    break;
        //                case "Вардумян":
        //                    shopNameBuy = "VarduminBuy";
        //                    shopNameSell = "VarduminSell";
        //                    break;
        //                case "Мария":
        //                    shopNameBuy = "MariyBuy";
        //                    shopNameSell = "MariySell";
        //                    break;
        //                case "Мелконян":
        //                    shopNameBuy = "MelconynBuy";
        //                    shopNameSell = "MelconynSell";
        //                    break;
        //                case "Мелконян2":
        //                    shopNameBuy = "MelconynBuy2";
        //                    shopNameSell = "MelconynSell2";
        //                    break;
        ////                case "Коляда": "Фатима", "Иминов", "Хлебодар", "Текеев", "Текеев2", "Токов", "Тищенко", "Фарше", "Корма", "Корма2", "Люля", "Лаваш Григорян", "Хлебком Невинномысск",
        ////"Хлебком Невинномысск2", "Айсанов", "Иней", "База 1", "База 2", "База 3", "Переоценка +", "Переоценка -", "Списание", "Общая сумма"
                    //}
                    Shops = WorkingToDB.GetDateInvoicesRange(nameDateBase, SelectedDateTimeOne, SelectedDateTimeTwo);
                }
            }
        }
        private void GetDateExpenditure()
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
                    Shops = WorkingToDB.GetDateExpenditureRange(nameDateBase, SelectedDateTimeOne, SelectedDateTimeTwo);
                }
            }
        }
        public ICommand Clear { get; }
        private void OnClear(object par)
        {
            Shops.Clear();
            SelectedDateTimeOne = null;
            SelectedDateTimeTwo = null;
            Precent = 0m;
            PrecentZP = 0m;
        }
        public VMCollationRange()
        {
            Clear = new LamdaCommand(OnClear);
        }

        private void CalculationPrecentZP()
        {
            decimal sum = 0m;
            for (int i = 0; i < Shops.Count; i++)
            {
                sum += Shops[i].TotalAmountExpenditure;
            }
            PrecentZP = Precent * 0.01M * sum;
        }
    }
}        
