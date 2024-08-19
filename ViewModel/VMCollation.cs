using Creating_Invoices.Model;
using Creating_Invoices.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Creating_Invoices.ViewModel
{
    internal class VMCollation : Base.ViewModel
    {
        private string _title = "Редактор накладных: детальная сверка| Версия " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }
        private ObservableCollection<string> dateTimes;
        public ObservableCollection<string> DateTimes
        {
            get { return dateTimes; }
            set { dateTimes = value; OnPropertyChanged(nameof(DateTimes)); }
        }
        private string selectedDateTime;
        public string SelectedDateTime
        {
            get => selectedDateTime;
            set
            {
                selectedDateTime = value;
                OnPropertyChanged(nameof(SelectedDateTime));
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
        private ObservableCollection<bool> selectInvoices = new ObservableCollection<bool> { false, false };
        public ObservableCollection<bool> SelectInvoices
        {
            get { return selectInvoices; }
            set { selectInvoices = value; OnPropertyChanged(nameof(SelectInvoices));}
        }
        private ObservableCollection<Shop> shops = new ObservableCollection<Shop>() { new Shop(), new Shop(), new Shop(), new Shop(), new Shop() };
        public ObservableCollection<Shop> Shops
        {
            get { return shops; }
            set { shops = value; OnPropertyChanged(nameof(Shops)); }
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


        private void GetDate()
        {
            for (int i = 0; i < IsSelectTabControl.Count; i++)
            {
                if (IsSelectTabControl[i])
                {
                    int k = 0;
                    for (int j = 0; j < Shops[i].namePropBuy.Length + Shops[i].namePropSell.Length + 4; j++)
                    {
                        if (k < Shops[i].namePropSell.Length)
                        {
                            Shops[i].GetType().GetProperty(Shops[i].namePropBuy[k]).SetValue(Shops[i], 0m);
                            j++;
                            Shops[i].GetType().GetProperty(Shops[i].namePropSell[k]).SetValue(Shops[i], 0m);
                            k++;
                        }
                        else if (k < Shops[i].namePropBuy.Length)
                        {
                            Shops[i].GetType().GetProperty(Shops[i].namePropBuy[k]).SetValue(Shops[i], 0m);
                            k++;
                        }
                        else if (j == Shops[i].namePropBuy.Length + Shops[i].namePropSell.Length)
                        {
                            Shops[i].RevaluationMinus = 0m;
                        }
                        else if (j == Shops[i].namePropBuy.Length + Shops[i].namePropSell.Length +1)
                        {
                            Shops[i].WriteDowns = 0m;
                        }
                        else if (j == Shops[i].namePropBuy.Length + Shops[i].namePropSell.Length +2)
                        {
                            Shops[i].TotalAmountBuy = 0m;
                        }
                        else if (j == Shops[i].namePropBuy.Length + Shops[i].namePropSell.Length +3)
                        {
                            Shops[i].TotalAmountSell = 0m;
                        }
                    }
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
                    ObservableCollection<decimal> decimals = WorkingToDB.GetDateInvoices(nameDateBase, SelectedDateTime);
                    k = 0;
                    for (int j = 0; j < decimals.Count; j++)
                    {
                        if (k < Shops[i].namePropSell.Length)
                        {
                            Shops[i].GetType().GetProperty(Shops[i].namePropBuy[k]).SetValue(Shops[i], decimals[j]);
                            //Shops[i].dateEntranceBuy[k] = decimals[j];
                            //OnPropertyChanged(Shops[i].namePropBuy[k]);
                            j++;
                            Shops[i].GetType().GetProperty(Shops[i].namePropSell[k]).SetValue(Shops[i], decimals[j]);
                            //Shops[i].dateEntranceSell[k] = decimals[j];
                            //OnPropertyChanged(Shops[i].namePropSell[k]);
                            k++;
                        }
                        else if (k < Shops[i].namePropBuy.Length)
                        {
                            Shops[i].GetType().GetProperty(Shops[i].namePropBuy[k]).SetValue(Shops[i], decimals[j]);
                            k++;
                        }
                        else if (j == decimals.Count - 4)
                        {
                            Shops[i].RevaluationMinus = decimals[j];
                        }
                        else if (j == decimals.Count - 3)
                        {
                            Shops[i].WriteDowns = decimals[j];
                        }
                        else if (j == decimals.Count - 2)
                        {
                            Shops[i].TotalAmountBuy = decimals[j];
                        }
                        else if (j == decimals.Count -1)
                        {
                            Shops[i].TotalAmountSell = decimals[j];
                        }
                    }
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
                    ObservableCollection<decimal> decimals = WorkingToDB.GetDateInvoices(nameDateBase, SelectedDateTime);
                    for (int j = 0; j < decimals.Count; j++)
                    {
                        Shops[i].GetType().GetProperty(Shops[i].namePropExpenditure[j]).SetValue(Shops[i], decimals[j]);
                    }
                }
            }
        }

        public VMCollation()
        {
        }
    }
}
