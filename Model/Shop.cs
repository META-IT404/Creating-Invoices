using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Creating_Invoices.ViewModel.Base;

namespace Creating_Invoices.Model
{
    internal class Shop : ViewModel.Base.ViewModel
    {
        #region Поля создания накладной прихода
        public ObservableCollection<decimal> dateEntranceBuy = new ObservableCollection<decimal>(new decimal[32]);
        public ObservableCollection<decimal> dateEntranceSell = new ObservableCollection<decimal>(new decimal[28]);
        public ObservableCollection<decimal> dateEntrancePercent = new ObservableCollection<decimal>(new decimal[28]);
        public string[] namePropBuy =
            { "NevholodBuy", "PyatigorskBuy", 
            "AbdurahmanovBuy", "AbdurahmanovBuy2", 
             "AvozinBuy",  "VarduminBuy", 
             "MariyBuy",  "MelconynBuy", "MelconynBuy2",  "KolydaBuy",  "FatimaBuy", 
             "IminovBuy",  "HlebodarBuy", "TeckeevBuy",  "TeckeevBuy2",  "TokovBuy", 
             "TichenkoBuy", "FarheBuy",  "KormaBuy", 
             "KormaBuy2",  "LulyBuy",  "LavinaBreadBuy", 
            "LulyGrigorynBuy",  "LavachGrigorynBuy", 
             "CityNSKBreadFactorBuy", "CityNSKBreadFactorBuy2",  "AysanovBuy", "IneyBuy",
            "Base1", "Base2", "Base3", "RevaluationPlus"
        };
        public string[] namePropSell =
            {  "NevholodSell",  "PyatigorskSell",
             "AbdurahmanovSell", 
            "AbdurahmanovSell2",  "AvozinSell", 
            "VarduminSell",  "MariySell",  "MelconynSell",
             "MelconynSell2", "KolydaSell", 
            "FatimaSell", "IminovSell", "HlebodarSell",
            "TeckeevSell",  "TeckeevSell2",
            "TokovSell", "TichenkoSell", "FarheSell", 
            "KormaSell",  "KormaSell2", "LulySell", 
            "LavinaBreadSell",  "LulyGrigorynSell", 
            "LavachGrigorynSell", "CityNSKBreadFactorSell",
             "CityNSKBreadFactorSell2", 
            "AysanovSell", "IneySell"
        };
        public string[] namePropPercent =
            { nameof(NevholodPercent),  nameof(PyatigorskPercent),
             nameof(AbdurahmanovPercent),
            nameof(AbdurahmanovPercent2),  nameof(AvozinPercent),
            nameof(VarduminPercent),  nameof(MariyPercent),  nameof(MelconynPercent),
             nameof(MelconynPercent2), nameof(KolydaPercent),
            nameof(FatimaPercent), nameof(IminovPercent), nameof(HlebodarPercent),
            nameof(TeckeevPercent),  nameof(TeckeevPercent2),
            nameof(TokovPercent), nameof(TichenkoPercent), nameof(FarhePercent),
            nameof(KormaPercent),  nameof(KormaPercent2), nameof(LulyPercent),
            nameof(LavinaBreadPercent),  nameof(LulyGrigorynPercent),
            nameof(LavachGrigorynPercent), nameof(CityNSKBreadFactorPercent),
             nameof(CityNSKBreadFactorPercent2),
            nameof(AysanovPercent), nameof(IneyPercent)
        };
        private string _date;
        private decimal _totalAmountBuy;
        private decimal _totalAmountSell;
        private decimal _revaluationMinus;
        private decimal _writeDowns;
        #region Без наценки
        public decimal NevholodBuy
        {
            get { return dateEntranceBuy[0]; }
            set { dateEntranceBuy[0] = value; OnPropertyChanged(nameof(NevholodBuy)); }
        }
        public decimal PyatigorskBuy
        {
            get { return dateEntranceBuy[1]; }
            set { dateEntranceBuy[1] = value; OnPropertyChanged(nameof(PyatigorskBuy)); }
        }
        public decimal AbdurahmanovBuy
        {
            get => dateEntranceBuy[2];
            set { dateEntranceBuy[2] = value; OnPropertyChanged(nameof(AbdurahmanovBuy)); }
        }
        public decimal AbdurahmanovBuy2
        {
            get => dateEntranceBuy[3];
            set { dateEntranceBuy[3] = value; OnPropertyChanged(nameof(AbdurahmanovBuy2)); }
        }
        public decimal AvozinBuy
        {
            get => dateEntranceBuy[4];
            set { dateEntranceBuy[4] = value; OnPropertyChanged(nameof(AvozinBuy)); }
        }
        public decimal VarduminBuy
        {
            get { return dateEntranceBuy[5]; }
            set { dateEntranceBuy[5] = value; OnPropertyChanged(nameof(VarduminBuy)); }
        }
        public decimal MariyBuy
        {
            get { return dateEntranceBuy[6]; }
            set { dateEntranceBuy[6] = value; OnPropertyChanged(nameof(MariyBuy)); }
        }
        public decimal MelconynBuy
        {
            get => dateEntranceBuy[7];
            set { dateEntranceBuy[7] = value; OnPropertyChanged(nameof(MelconynBuy)); }
        }
        public decimal MelconynBuy2
        {
            get => dateEntranceBuy[8];
            set { dateEntranceBuy[8] = value; OnPropertyChanged(nameof(MelconynBuy2)); }
        }
        public decimal KolydaBuy
        {
            get { return dateEntranceBuy[9]; }
            set { dateEntranceBuy[9] = value; OnPropertyChanged(nameof(KolydaBuy)); }
        }
        public decimal FatimaBuy
        {
            get { return dateEntranceBuy[10]; }
            set { dateEntranceBuy[10] = value; OnPropertyChanged(nameof(FatimaBuy)); }
        }
        public decimal IminovBuy
        {
            get
            {
                return dateEntranceBuy[11];
            }
            set { dateEntranceBuy[11] = value; OnPropertyChanged(nameof(IminovBuy)); }
        }
        public decimal HlebodarBuy
        {
            get { return dateEntranceBuy[12]; }
            set { dateEntranceBuy[12] = value; OnPropertyChanged(nameof(HlebodarBuy)); }
        }
        public decimal TeckeevBuy
        {
            get { return dateEntranceBuy[13]; }
            set { dateEntranceBuy[13] = value; OnPropertyChanged(nameof(TeckeevBuy)); }
        }
        public decimal TeckeevBuy2
        {
            get { return dateEntranceBuy[14]; }
            set { dateEntranceBuy[14] = value; OnPropertyChanged(nameof(TeckeevBuy2)); }
        }
        public decimal TokovBuy
        {
            get { return dateEntranceBuy[15]; }
            set { dateEntranceBuy[15] = value; OnPropertyChanged(nameof(TokovBuy)); }
        }
        public decimal TichenkoBuy
        {
            get { return dateEntranceBuy[16]; }
            set { dateEntranceBuy[16] = value; OnPropertyChanged(nameof(TichenkoBuy)); }
        }
        public decimal FarheBuy
        {
            get { return dateEntranceBuy[17]; }
            set { dateEntranceBuy[17] = value; OnPropertyChanged(nameof(FarheBuy)); }
        }
        public decimal KormaBuy
        {
            get { return dateEntranceBuy[18]; }
            set { dateEntranceBuy[18] = value; OnPropertyChanged(nameof(KormaBuy)); }
        }
        public decimal KormaBuy2
        {
            get { return dateEntranceBuy[19]; }
            set { dateEntranceBuy[19] = value; OnPropertyChanged(nameof(KormaBuy2)); }
        }
        public decimal LulyBuy
        {
            get { return dateEntranceBuy[20]; }
            set { dateEntranceBuy[20] = value; OnPropertyChanged(nameof(LulyBuy)); }
        }
        public decimal LavinaBreadBuy
        {
            get { return dateEntranceBuy[21]; }
            set { dateEntranceBuy[21] = value; OnPropertyChanged(nameof(LavinaBreadBuy)); }
        }
        public decimal LulyGrigorynBuy
        {
            get { return dateEntranceBuy[22]; }
            set { dateEntranceBuy[22] = value; OnPropertyChanged(nameof(LulyGrigorynBuy)); }
        }
        public decimal LavachGrigorynBuy
        {
            get { return dateEntranceBuy[23]; }
            set { dateEntranceBuy[23] = value; OnPropertyChanged(nameof(LavachGrigorynBuy)); }
        }
        public decimal CityNSKBreadFactorBuy
        {
            get { return dateEntranceBuy[24]; }
            set { dateEntranceBuy[24] = value; OnPropertyChanged(nameof(CityNSKBreadFactorBuy)); }
        }
        public decimal CityNSKBreadFactorBuy2
        {
            get { return dateEntranceBuy[25]; }
            set { dateEntranceBuy[25] = value; OnPropertyChanged(nameof(CityNSKBreadFactorBuy2)); }
        }
        public decimal AysanovBuy
        {
            get { return dateEntranceBuy[26]; }
            set { dateEntranceBuy[26] = value; OnPropertyChanged(nameof(AysanovBuy)); }
        }
        public decimal IneyBuy
        {
            get { return dateEntranceBuy[27]; }
            set { dateEntranceBuy[27] = value; OnPropertyChanged(nameof(IneyBuy));}
        }
        public decimal Base1
        {
            get { return dateEntranceBuy[dateEntranceBuy.Count - 4]; }
            set { dateEntranceBuy[dateEntranceBuy.Count - 4] = value; OnPropertyChanged(nameof(Base1)); }
        }
        public decimal Base2
        {
            get { return dateEntranceBuy[dateEntranceBuy.Count - 3]; }
            set { dateEntranceBuy[dateEntranceBuy.Count - 3] = value; OnPropertyChanged(nameof(Base2)); }
        }
        public decimal Base3
        {
            get { return dateEntranceBuy[dateEntranceBuy.Count - 2]; }
            set { dateEntranceBuy[dateEntranceBuy.Count - 2] = value; OnPropertyChanged(nameof(Base3)); }
        }

        public decimal RevaluationPlus
        {
            get { return dateEntranceBuy[dateEntranceBuy.Count - 1]; }
            set { dateEntranceBuy[dateEntranceBuy.Count - 1] = value; OnPropertyChanged(nameof(RevaluationPlus)); }
        }

        public decimal RevaluationMinus
        {
            get { return _revaluationMinus; }
            set { _revaluationMinus = value; OnPropertyChanged(nameof(RevaluationMinus)); }
        }

        public decimal WriteDowns
        {
            get { return _writeDowns; }
            set { _writeDowns = value; OnPropertyChanged(nameof(WriteDowns)); }
        }
        public decimal TotalAmountBuy
        {
            get { return _totalAmountBuy; }
            set { _totalAmountBuy = value; OnPropertyChanged(nameof(TotalAmountBuy)); }
        }
        #endregion
        #region С наценкой
        public decimal NevholodSell
        {
            get { return dateEntranceSell[0]; }
            set { dateEntranceSell[0] = value; OnPropertyChanged(nameof(NevholodSell)); }
        }
        public decimal PyatigorskSell
        {
            get { return dateEntranceSell[1]; }
            set { dateEntranceSell[1] = value; OnPropertyChanged(nameof(PyatigorskSell)); }
        }
        public decimal AbdurahmanovSell
        {
            get => dateEntranceSell[2];
            set { dateEntranceSell[2] = value; OnPropertyChanged(nameof(AbdurahmanovSell)); }
        }
        public decimal AbdurahmanovSell2
        {
            get => dateEntranceSell[3];
            set { dateEntranceSell[3] = value; OnPropertyChanged(nameof(AbdurahmanovSell2)); }
        }
        public decimal AvozinSell
        {
            get => dateEntranceSell[4];
            set { dateEntranceSell[4] = value; OnPropertyChanged(nameof(AvozinSell)); }
        }
        public decimal VarduminSell
        {
            get { return dateEntranceSell[5]; }
            set { dateEntranceSell[5] = value; OnPropertyChanged(nameof(VarduminSell)); }
        }
        public decimal MariySell
        {
            get { return dateEntranceSell[6]; }
            set { dateEntranceSell[6] = value; OnPropertyChanged(nameof(MariySell)); }
        }
        public decimal MelconynSell
        {
            get => dateEntranceSell[7];
            set { dateEntranceSell[7] = value; OnPropertyChanged(nameof(MelconynSell)); }
        }
        public decimal MelconynSell2
        {
            get => dateEntranceSell[8];
            set { dateEntranceSell[8] = value; OnPropertyChanged(nameof(MelconynSell2)); }
        }
        public decimal KolydaSell
        {
            get { return dateEntranceSell[9]; }
            set { dateEntranceSell[9] = value; OnPropertyChanged(nameof(KolydaSell)); }
        }
        public decimal FatimaSell
        {
            get { return dateEntranceSell[10]; }
            set { dateEntranceSell[10] = value; OnPropertyChanged(nameof(FatimaSell)); }
        }
        public decimal IminovSell
        {
            get
            {
                return dateEntranceSell[11];
            }
            set { dateEntranceSell[11] = value; OnPropertyChanged(nameof(IminovSell)); }
        }
        public decimal HlebodarSell
        {
            get { return dateEntranceSell[12]; }
            set { dateEntranceSell[12] = value; OnPropertyChanged(nameof(HlebodarSell)); }
        }
        public decimal TeckeevSell
        {
            get { return dateEntranceSell[13]; }
            set { dateEntranceSell[13] = value; OnPropertyChanged(nameof(TeckeevSell)); }
        }
        public decimal TeckeevSell2
        {
            get { return dateEntranceSell[14]; }
            set { dateEntranceSell[14] = value; OnPropertyChanged(nameof(TeckeevSell2)); }
        }
        public decimal TokovSell
        {
            get { return dateEntranceSell[15]; }
            set { dateEntranceSell[15] = value; OnPropertyChanged(nameof(TokovSell)); }
        }
        public decimal TichenkoSell
        {
            get { return dateEntranceSell[16]; }
            set { dateEntranceSell[16] = value; OnPropertyChanged(nameof(TichenkoSell)); }
        }
        public decimal FarheSell
        {
            get { return dateEntranceSell[17]; }
            set { dateEntranceSell[17] = value; OnPropertyChanged(nameof(FarheSell)); }
        }
        public decimal KormaSell
        {
            get { return dateEntranceSell[18]; }
            set { dateEntranceSell[18] = value; OnPropertyChanged(nameof(KormaSell)); }
        }
        public decimal KormaSell2
        {
            get { return dateEntranceSell[19]; }
            set { dateEntranceSell[19] = value; OnPropertyChanged(nameof(KormaSell2)); }
        }
        public decimal LulySell
        {
            get { return dateEntranceSell[20]; }
            set { dateEntranceSell[20] = value; OnPropertyChanged(nameof(LulySell)); }
        }
        public decimal LavinaBreadSell
        {
            get { return dateEntranceSell[21]; }
            set { dateEntranceSell[21] = value; OnPropertyChanged(nameof(LavinaBreadSell)); }
        }
        public decimal LulyGrigorynSell
        {
            get { return dateEntranceSell[22]; }
            set { dateEntranceSell[22] = value; OnPropertyChanged(nameof(LulyGrigorynSell)); }
        }
        public decimal LavachGrigorynSell
        {
            get { return dateEntranceSell[23]; }
            set { dateEntranceSell[23] = value; OnPropertyChanged(nameof(LavachGrigorynSell)); }
        }
        public decimal CityNSKBreadFactorSell
        {
            get { return dateEntranceSell[24]; }
            set { dateEntranceSell[24] = value; OnPropertyChanged(nameof(CityNSKBreadFactorSell)); }
        }
        public decimal CityNSKBreadFactorSell2
        {
            get { return dateEntranceSell[25]; }
            set { dateEntranceSell[25] = value; OnPropertyChanged(nameof(CityNSKBreadFactorSell2)); }
        }
        public decimal AysanovSell
        {
            get { return dateEntranceSell[26]; }
            set { dateEntranceSell[26] = value; OnPropertyChanged(nameof(AysanovSell)); }
        }
        public decimal IneySell
        {
            get { return dateEntranceSell[27]; }
            set { dateEntranceSell[27] = value; OnPropertyChanged(nameof(IneySell)); }
        }
        public decimal TotalAmountSell
        {
            get { return _totalAmountSell; }
            set { _totalAmountSell = value; OnPropertyChanged(nameof(TotalAmountSell)); }
        }
        #endregion
        #region Процент наценки
        public decimal NevholodPercent
        {
            get { return dateEntrancePercent[0]; }
            set { dateEntrancePercent[0] = value;  OnPropertyChanged(nameof(NevholodPercent)); }
        }
        public decimal PyatigorskPercent
        {
            get { return dateEntrancePercent[1]; }
            set { dateEntrancePercent[1] = value;  OnPropertyChanged(nameof(PyatigorskPercent)); }
        }
        public decimal AbdurahmanovPercent
        {
            get => dateEntrancePercent[2];
            set { dateEntrancePercent[2] = value;  OnPropertyChanged(nameof(AbdurahmanovPercent)); }
        }
        public decimal AbdurahmanovPercent2
        {
            get => dateEntrancePercent[3];
            set { dateEntrancePercent[3] = value; OnPropertyChanged(nameof(AbdurahmanovPercent2)); }
        }
        public decimal AvozinPercent
        {
            get => dateEntrancePercent[4];
            set { dateEntrancePercent[4] = value; OnPropertyChanged(nameof(AvozinPercent)); }
        }
        public decimal VarduminPercent
        {
            get { return dateEntrancePercent[5]; }
            set { dateEntrancePercent[5] = value; OnPropertyChanged(nameof(VarduminPercent)); }
        }
        public decimal MariyPercent
        {
            get { return dateEntrancePercent[6]; }
            set { dateEntrancePercent[6] = value; OnPropertyChanged(nameof(MariyPercent)); }
        }
        public decimal MelconynPercent
        {
            get => dateEntrancePercent[7];
            set { dateEntrancePercent[7] = value; OnPropertyChanged(nameof(MelconynPercent)); }
        }
        public decimal MelconynPercent2
        {
            get => dateEntrancePercent[8];
            set { dateEntrancePercent[8] = value; OnPropertyChanged(nameof(MelconynPercent2)); }
        }
        public decimal KolydaPercent
        {
            get { return dateEntrancePercent[9]; }
            set { dateEntrancePercent[9] = value; OnPropertyChanged(nameof(KolydaPercent)); }
        }
        public decimal FatimaPercent
        {
            get { return dateEntrancePercent[10]; }
            set { dateEntrancePercent[10] = value; OnPropertyChanged(nameof(FatimaPercent)); }
        }
        public decimal IminovPercent
        {
            get
            {
                return dateEntrancePercent[11];
            }
            set { dateEntrancePercent[11] = value; OnPropertyChanged(nameof(IminovPercent)); }
        }
        public decimal HlebodarPercent
        {
            get { return dateEntrancePercent[12]; }
            set { dateEntrancePercent[12] = value; OnPropertyChanged(nameof(HlebodarPercent)); }
        }
        public decimal TeckeevPercent
        {
            get { return dateEntrancePercent[13]; }
            set { dateEntrancePercent[13] = value; OnPropertyChanged(nameof(TeckeevPercent)); }
        }
        public decimal TeckeevPercent2
        {
            get { return dateEntrancePercent[14]; }
            set { dateEntrancePercent[14] = value; OnPropertyChanged(nameof(TeckeevPercent2)); }
        }
        public decimal TokovPercent
        {
            get { return dateEntrancePercent[15]; }
            set { dateEntrancePercent[15] = value; OnPropertyChanged(nameof(TokovPercent)); }
        }
        public decimal TichenkoPercent
        {
            get { return dateEntrancePercent[16]; }
            set { dateEntrancePercent[16] = value; OnPropertyChanged(nameof(TichenkoPercent)); }
        }
        public decimal FarhePercent
        {
            get { return dateEntrancePercent[17]; }
            set { dateEntrancePercent[17] = value; OnPropertyChanged(nameof(FarhePercent)); }
        }
        public decimal KormaPercent
        {
            get { return dateEntrancePercent[18]; }
            set { dateEntrancePercent[18] = value; OnPropertyChanged(nameof(KormaPercent)); }
        }
        public decimal KormaPercent2
        {
            get { return dateEntrancePercent[19]; }
            set { dateEntrancePercent[19] = value; OnPropertyChanged(nameof(KormaPercent2)); }
        }
        public decimal LulyPercent
        {
            get { return dateEntrancePercent[20]; }
            set { dateEntrancePercent[20] = value; OnPropertyChanged(nameof(LulyPercent)); }
        }
        public decimal LavinaBreadPercent
        {
            get { return dateEntrancePercent[21]; }
            set { dateEntrancePercent[21] = value; OnPropertyChanged(nameof(LavinaBreadPercent)); }
        }
        public decimal LulyGrigorynPercent
        {
            get { return dateEntrancePercent[22]; }
            set { dateEntrancePercent[22] = value; OnPropertyChanged(nameof(LulyGrigorynPercent)); }
        }
        public decimal LavachGrigorynPercent
        {
            get { return dateEntrancePercent[23]; }
            set { dateEntrancePercent[23] = value; OnPropertyChanged(nameof(LavachGrigorynPercent)); }
        }
        public decimal CityNSKBreadFactorPercent
        {
            get { return dateEntrancePercent[24]; }
            set { dateEntrancePercent[24] = value; OnPropertyChanged(nameof(CityNSKBreadFactorPercent)); }
        }
        public decimal CityNSKBreadFactorPercent2
        {
            get { return dateEntrancePercent[25]; }
            set { dateEntrancePercent[25] = value; OnPropertyChanged(nameof(CityNSKBreadFactorPercent2)); }
        }
        public decimal AysanovPercent
        {
            get { return dateEntrancePercent[26]; }
            set { dateEntrancePercent[26] = value; OnPropertyChanged(nameof(AysanovPercent)); }
        }
        public decimal IneyPercent
        {
            get { return dateEntrancePercent[27]; }
            set { dateEntrancePercent[27] = value; OnPropertyChanged(nameof(IneyPercent)); }
        }
        #endregion
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private decimal _rangeProvideBuy;
        public decimal RangeProvideBuy
        {
            get => _rangeProvideBuy;
            set
            {
                _rangeProvideBuy = value; OnPropertyChanged(nameof(RangeProvideBuy));
            }
        }
        private decimal _rangeProvideSell;
        public decimal RangeProvideSell
        {
            get => _rangeProvideSell;
            set { _rangeProvideSell = value; OnPropertyChanged(nameof(RangeProvideSell)); }
        }
        #endregion
        #region Поля создания накладной расхода
        public ObservableCollection<decimal> dateExpenditure = new ObservableCollection<decimal>(new decimal[7]);
        public string[] namePropExpenditure =
            { nameof(Nalic), nameof(Bank1), nameof(Bank2), nameof(QRcode1), nameof(QRcode2), nameof(SBP), nameof(ZP), nameof(TotalAmountExpenditure)
        };
        private string _dateExpenditure;
        public string DateExpenditure
        {
            get { return _dateExpenditure; }
            set
            {
                _dateExpenditure = value;
                OnPropertyChanged(nameof(DateExpenditure));
            }
        }
        public decimal Nalic
        {
            get { return dateExpenditure[0]; }
            set { dateExpenditure[0] = value; OnPropertyChanged(nameof(Nalic)); }
        }
        public decimal Bank1
        {
            get => dateExpenditure[1];
            set { dateExpenditure[1] = value; OnPropertyChanged(nameof(Bank1)); }
        }
        public decimal Bank2
        {
            get => dateExpenditure[2];
            set { dateExpenditure[2] = value; OnPropertyChanged(nameof(Bank2)); }
        }
        public decimal QRcode1
        {
            get => dateExpenditure[3];
            set { dateExpenditure[3] = value; OnPropertyChanged(nameof(QRcode1)); }
        }
        public decimal QRcode2
        {
            get => dateExpenditure[4];
            set { dateExpenditure[4] = value; OnPropertyChanged(nameof(QRcode2)); }
        }
        public decimal SBP
        {
            get => dateExpenditure[5];
            set { dateExpenditure[5] = value; OnPropertyChanged(nameof(SBP)); }
        }
        public decimal ZP
        {
            get => dateExpenditure[6];
            set { dateExpenditure[6] = value; OnPropertyChanged(nameof(ZP)); }
        }
        private decimal totalAmountExpenditure;
        public decimal TotalAmountExpenditure
        {
            get { return totalAmountExpenditure; }
            set { totalAmountExpenditure = value; OnPropertyChanged(nameof(TotalAmountExpenditure)); }
        }
        #endregion
        public Thread threadCalculationSell;

        public Shop()
        {
            //threadCalculationSell = new Thread(CalculationSell);
            //threadCalculationSell.Start();
        }
        public void CalculationSell()
        {


                for (int i = 0; i < namePropSell.Length; i++)
                {

                        dateEntranceSell[i] = dateEntrancePercent[i] * 0.01M * dateEntranceBuy[i] + dateEntranceBuy[i];
                        OnPropertyChanged(namePropSell[i]);
                }

        }

    }
}
