using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Creating_Invoices.Model
{
    static internal class WorkingToDB
    {
        static public void AddToDBEntrance(string nameDateBase, Shop shop)
        {
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT * FROM {nameDateBase} WHERE Date = @Date";
                    sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = shop.Date;
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            List<decimal> list = new List<decimal>();
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                list.Add((decimal)reader[i]);
                            }
                            reader.Close();
                            sqlCommand.Parameters.Clear();
                            sqlCommand.CommandText = $"UPDATE {nameDateBase} SET NevholodBuy = @NevholodBuy, NevholodSell = @NevholodSell, " +
                                $"PyatigorskBuy = @PyatigorskBuy, PyatigorskSell = @PyatigorskSell, " +
                                $"AbdurahmanovBuy = @AbdurahmanovBuy, AbdurahmanovSell = @AbdurahmanovSell, " +
                                $"AbdurahmanovBuy2 = @AbdurahmanovBuy2, AbdurahmanovSell2 = @AbdurahmanovSell2, " +
                                $"AvozinBuy = @AvozinBuy, AvozinSell = @AvozinSell, VarduminBuy = @VarduminBuy, " +
                                $"VarduminSell = @VarduminSell, MariyBuy = @MariyBuy, MariySell = @MariySell, " +
                                $"MelconynBuy = @MelconynBuy, MelconynSell = @MelconynSell, " +
                                $"MelconynBuy2 = @MelconynBuy2, MelconynSell2 = @MelconynSell2, KolydaBuy = @KolydaBuy, " +
                                $"KolydaSell = @KolydaSell, FatimaBuy = @FatimaBuy, FatimaSell = @FatimaSell, " +
                                $"IminovBuy = @IminovBuy, IminovSell = @IminovSell, HlebodarBuy = @HlebodarBuy, " +
                                $"HlebodarSell = @HlebodarSell, TeckeevBuy = @TeckeevBuy, TeckeevSell = @TeckeevSell, " +
                                $"TeckeevBuy2 = @TeckeevBuy2, TeckeevSell2 = @TeckeevSell2, TokovBuy = @TokovBuy, " +
                                $"TokovSell = @TokovSell, TichenkoBuy = @TichenkoBuy, TichenkoSell = @TichenkoSell, " +
                                $"FarheBuy = @FarheBuy, FarheSell = @FarheSell, KormaBuy = @KormaBuy, KormaSell = @KormaSell, " +
                                $"KormaBuy2 = @KormaBuy2, KormaSell2 = @KormaSell2, LulyBuy = @LulyBuy, LulySell = @LulySell, " +
                                $"LavinaBreadBuy = @LavinaBreadBuy, LavinaBreadSell = @LavinaBreadSell, " +
                                $"LulyGrigorynBuy = @LulyGrigorynBuy, LulyGrigorynSell = @LulyGrigorynSell, " +
                                $"LavachGrigorynBuy = @LavachGrigorynBuy, LavachGrigorynSell = @LavachGrigorynSell, " +
                                $"CityNSKBreadFactorBuy = @CityNSKBreadFactorBuy, CityNSKBreadFactorSell = @CityNSKBreadFactorSell, " +
                                $"CityNSKBreadFactorBuy2 = @CityNSKBreadFactorBuy2, CityNSKBreadFactorSell2 = @CityNSKBreadFactorSell2, " +
                                $"AysanovBuy = @AysanovBuy, AysanovSell = @AysanovSell, IneyBuy = @IneyBuy, IneySell = @IneySell, Base1 = @Base1, Base2 = @Base2, Base3 = @Base3, " +
                                $"RevaluationPlus = @RevaluationPlus, RevaluationMinus  = @RevaluationMinus, WriteDowns  = @WriteDowns, " +
                                $"TotalAmountBuy = @TotalAmountBuy, TotalAmountSell = @TotalAmountSell WHERE Date = @Date";
                            sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Convert.ToDateTime(shop.Date);
                            //sqlCommand.Parameters.Add("@NevholodBuy", SqlDbType.Decimal).Value = list[1] == buy[0] ? list[1] : buy[0];
                            //sqlCommand.Parameters.Add("@NevholodSell", SqlDbType.Decimal).Value = list[2] == sell[0] ? list[2] : sell[0];
                            //sqlCommand.Parameters.Add("@PyatigorskBuy", SqlDbType.Decimal).Value = list[3] == buy[1] ? list[3] : buy[1];
                            //sqlCommand.Parameters.Add("@PyatigorskSell", SqlDbType.Decimal).Value = list[4] == sell[1] ? list[4] : sell[1];
                            //sqlCommand.Parameters.Add("@AbdurahmanovBuy", SqlDbType.Decimal).Value = list[5] == buy[2] ? list[5] : buy[2];
                            //sqlCommand.Parameters.Add("@AbdurahmanovSell", SqlDbType.Decimal).Value = list[6] == sell[2] ? list[6] : sell[2];
                            //sqlCommand.Parameters.Add("@VarduminBuy", SqlDbType.Decimal).Value = list[7] == buy[3] ? list[7] : buy[3];
                            //sqlCommand.Parameters.Add("@VarduminSell", SqlDbType.Decimal).Value = list[8] == sell[3] ? list[8] : sell[3];
                            //sqlCommand.Parameters.Add("@MariyBuy", SqlDbType.Decimal).Value = list[9] == buy[4] ? list[9] : buy[4];
                            //sqlCommand.Parameters.Add("@MariySell", SqlDbType.Decimal).Value = list[10] == sell[4] ? list[10] : sell[4];
                            //sqlCommand.Parameters.Add("@MelconynBuy", SqlDbType.Decimal).Value = list[11] == buy[5] ? list[11] : buy[5];
                            //sqlCommand.Parameters.Add("@MelconynSell", SqlDbType.Decimal).Value = list[12] == sell[5] ? list[12] : sell[5];
                            //sqlCommand.Parameters.Add("@KolydaBuy", SqlDbType.Decimal).Value = list[13] == buy[6] ? list[13] : buy[6];
                            //sqlCommand.Parameters.Add("@KolydaSell", SqlDbType.Decimal).Value = list[14] == sell[6] ? list[14] : sell[6];
                            //sqlCommand.Parameters.Add("@IminovBuy", SqlDbType.Decimal).Value = list[15] == buy[7] ? list[15] : buy[7];
                            //sqlCommand.Parameters.Add("@IminovSell", SqlDbType.Decimal).Value = list[16] == sell[7] ? list[16] : sell[7];
                            //sqlCommand.Parameters.Add("@HlebodarBuy", SqlDbType.Decimal).Value = list[17] == buy[8] ? list[17] : buy[8];
                            //sqlCommand.Parameters.Add("@HlebodarSell", SqlDbType.Decimal).Value = list[18] == sell[8] ? list[18] : sell[8];
                            //sqlCommand.Parameters.Add("@TeckeevBuy", SqlDbType.Decimal).Value = list[19] == buy[9] ? list[19] : buy[9];
                            //sqlCommand.Parameters.Add("@TeckeevSell", SqlDbType.Decimal).Value = list[20] == sell[9] ? list[20] : sell[9];
                            //sqlCommand.Parameters.Add("@TokovBuy", SqlDbType.Decimal).Value = list[21] == buy[10] ? list[21] : buy[10];
                            //sqlCommand.Parameters.Add("@TokovSell", SqlDbType.Decimal).Value = list[22] == sell[10] ? list[22] : sell[10];
                            //sqlCommand.Parameters.Add("@TichenkoBuy", SqlDbType.Decimal).Value = list[23] == buy[11] ? list[23] : buy[11];
                            //sqlCommand.Parameters.Add("@TichenkoSell", SqlDbType.Decimal).Value = list[24] == sell[11] ? list[24] : sell[11];
                            //sqlCommand.Parameters.Add("@FarheBuy", SqlDbType.Decimal).Value = list[25] == buy[12] ? list[25] : buy[12];
                            //sqlCommand.Parameters.Add("@FarheSell", SqlDbType.Decimal).Value = list[26] == sell[12] ? list[26] : sell[12];
                            //sqlCommand.Parameters.Add("@KormaBuy", SqlDbType.Decimal).Value = list[27] == buy[13] ? list[27] : buy[13];
                            //sqlCommand.Parameters.Add("@KormaSell", SqlDbType.Decimal).Value = list[28] == sell[13] ? list[28] : sell[13];
                            //sqlCommand.Parameters.Add("@LulyBuy", SqlDbType.Decimal).Value = list[29] == buy[14] ? list[29] : buy[14];
                            //sqlCommand.Parameters.Add("@LulySell", SqlDbType.Decimal).Value = list[30] == sell[14] ? list[30] : sell[14]; 
                            //sqlCommand.Parameters.Add("@LavinaBreadBuy", SqlDbType.Decimal).Value = list[31] == buy[15] ? list[31] : buy[15];
                            //sqlCommand.Parameters.Add("@LavinaBreadSell", SqlDbType.Decimal).Value = list[32] == sell[15] ? list[32] : sell[15]; 
                            //sqlCommand.Parameters.Add("@LavachGrigorynBuy", SqlDbType.Decimal).Value = list[33] == buy[16] ? list[33] : buy[16]; 
                            //sqlCommand.Parameters.Add("@LavachGrigorynSell", SqlDbType.Decimal).Value = list[34] == sell[16] ? list[34] : sell[16]; 
                            //sqlCommand.Parameters.Add("@CityNSKBreadFactorBuy", SqlDbType.Decimal).Value = list[35] == buy[17] ? list[35] : buy[17]; 
                            //sqlCommand.Parameters.Add("@CityNSKBreadFactorSell", SqlDbType.Decimal).Value = list[36] == sell[17] ? list[36] : sell[17]; 
                            //sqlCommand.Parameters.Add("@AysanovBuy", SqlDbType.Decimal).Value = list[37] == buy[18] ? list[37] : buy[18]; 
                            //sqlCommand.Parameters.Add("@AysanovSell", SqlDbType.Decimal).Value = list[38] == sell[18] ? list[38] : sell[18]; 
                            int k = 0;
                            int j = 0;
                            for (int i = 0; i < shop.namePropSell.Length; i++)
                            {
                                if (k > 0)
                                {
                                    k++;
                                }
                                sqlCommand.Parameters.Add($"@{shop.namePropBuy[i]}", SqlDbType.Decimal).Value = shop.dateEntranceBuy[i] == 0 || list[k] == shop.dateEntranceBuy[i] ? list[k] : shop.dateEntranceBuy[i];
                                k++;
                                j++;
                                sqlCommand.Parameters.Add($"@{shop.namePropSell[i]}", SqlDbType.Decimal).Value = shop.dateEntranceSell[i] == 0 || list[j] == shop.dateEntranceSell[i] ? list[j] : shop.dateEntranceSell[i];
                                j++;
                            }
                            sqlCommand.Parameters.Add("@Base1", SqlDbType.Decimal).Value = shop.Base1 == 0 || list[list.Count - 8] == shop.Base1 ? list[list.Count - 8] : shop.Base1;
                            sqlCommand.Parameters.Add("@Base2", SqlDbType.Decimal).Value = shop.Base2 == 0 || list[list.Count - 7] == shop.Base2 ? list[list.Count - 7] : shop.Base2;
                            sqlCommand.Parameters.Add("@Base3", SqlDbType.Decimal).Value = shop.Base3 == 0 || list[list.Count - 6] == shop.Base3 ? list[list.Count - 6] : shop.Base3;
                            sqlCommand.Parameters.Add("@RevaluationPlus", SqlDbType.Decimal).Value = shop.RevaluationPlus == 0 || list[list.Count - 5] == shop.RevaluationPlus ? list[list.Count - 5] : shop.RevaluationPlus;
                            sqlCommand.Parameters.Add("@RevaluationMinus", SqlDbType.Decimal).Value = shop.RevaluationMinus == 0 || list[list.Count - 4] == shop.RevaluationMinus ? list[list.Count - 4] : shop.RevaluationMinus;
                            sqlCommand.Parameters.Add("@WriteDowns", SqlDbType.Decimal).Value = shop.WriteDowns == 0 || list[list.Count - 3] == shop.WriteDowns ? list[list.Count - 3] : shop.WriteDowns;
                            sqlCommand.Parameters.Add("@TotalAmountBuy", SqlDbType.Decimal).Value = shop.TotalAmountBuy == 0 || list[list.Count - 2] == shop.TotalAmountBuy ? list[list.Count - 2] : shop.TotalAmountBuy;
                            sqlCommand.Parameters.Add("@TotalAmountSell", SqlDbType.Decimal).Value = shop.TotalAmountSell == 0 || list[list.Count - 1] == shop.TotalAmountSell ? list[list.Count - 1] : shop.TotalAmountSell;
                            sqlCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            reader.Close();
                            sqlCommand.Parameters.Clear();
                            sqlCommand.CommandText = $"INSERT {nameDateBase} (Date, NevholodBuy, NevholodSell, PyatigorskBuy, PyatigorskSell, AbdurahmanovBuy, " +
                                $"AbdurahmanovSell, AbdurahmanovBuy2, AbdurahmanovSell2, AvozinBuy, AvozinSell, VarduminBuy, VarduminSell, " +
                                $"MariyBuy, MariySell, MelconynBuy, MelconynSell, MelconynBuy2, MelconynSell2, KolydaBuy, KolydaSell, " +
                                $"FatimaBuy, FatimaSell, IminovBuy, IminovSell, HlebodarBuy, HlebodarSell, TeckeevBuy, TeckeevSell, TeckeevBuy2, " +
                                $"TeckeevSell2, TokovBuy, TokovSell, TichenkoBuy, TichenkoSell, FarheBuy, FarheSell, KormaBuy, KormaSell, KormaBuy2, " +
                                $"KormaSell2, LulyBuy, LulySell, LavinaBreadBuy, LavinaBreadSell, LulyGrigorynBuy, LulyGrigorynSell, LavachGrigorynBuy, " +
                                $"LavachGrigorynSell, CityNSKBreadFactorBuy, CityNSKBreadFactorSell, CityNSKBreadFactorBuy2, CityNSKBreadFactorSell2, AysanovBuy, " +
                                $"AysanovSell, IneyBuy, IneySell, Base1, Base2, Base3, RevaluationPlus, RevaluationMinus, WriteDowns, TotalAmountBuy, TotalAmountSell) " +
                                    $"VALUES(@Date, @NevholodBuy, @NevholodSell, @PyatigorskBuy, @PyatigorskSell, @AbdurahmanovBuy, " +
                                $"@AbdurahmanovSell, @AbdurahmanovBuy2, @AbdurahmanovSell2, @AvozinBuy, @AvozinSell, @VarduminBuy, " +
                                $"@VarduminSell, @MariyBuy, @MariySell, @MelconynBuy, @MelconynSell, @MelconynBuy2, @MelconynSell2, " +
                                $"@KolydaBuy, @KolydaSell, @FatimaBuy, @FatimaSell, @IminovBuy, @IminovSell, @HlebodarBuy, @HlebodarSell, " +
                                $"@TeckeevBuy, @TeckeevSell, @TeckeevBuy2, @TeckeevSell2, @TokovBuy, @TokovSell, @TichenkoBuy, @TichenkoSell, " +
                                $"@FarheBuy, @FarheSell, @KormaBuy, @KormaSell, @KormaBuy2, @KormaSell2, @LulyBuy, @LulySell, @LavinaBreadBuy, " +
                                $"@LavinaBreadSell, @LulyGrigorynBuy, @LulyGrigorynSell, @LavachGrigorynBuy, @LavachGrigorynSell, @CityNSKBreadFactorBuy, " +
                                $"@CityNSKBreadFactorSell, @CityNSKBreadFactorBuy2, @CityNSKBreadFactorSell2, @AysanovBuy, @AysanovSell, @IneyBuy, @IneySell, @Base1, @Base2, " +
                                $"@Base3, @RevaluationPlus, @RevaluationMinus, @WriteDowns, @TotalAmountBuy, @TotalAmountSell" +
                        ")";
                            sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Convert.ToDateTime(shop.Date);
                            for (int i = 0; i < shop.namePropBuy.Length; i++)
                            {
                                sqlCommand.Parameters.Add($"@{shop.namePropBuy[i]}", SqlDbType.Decimal).Value = shop.dateEntranceBuy[i];
                            }
                            for (int i = 0; i < shop.namePropSell.Length; i++)
                            {
                                sqlCommand.Parameters.Add($"@{shop.namePropSell[i]}", SqlDbType.Decimal).Value = shop.dateEntranceSell[i];
                            }
                            //sqlCommand.Parameters.Add("@NevholodBuy", SqlDbType.Decimal).Value = buy[0];
                            //sqlCommand.Parameters.Add("@NevholodSell", SqlDbType.Decimal).Value = sell[0];
                            //sqlCommand.Parameters.Add("@PyatigorskBuy", SqlDbType.Decimal).Value = buy[1];
                            //sqlCommand.Parameters.Add("@PyatigorskSell", SqlDbType.Decimal).Value = sell[1];
                            //sqlCommand.Parameters.Add("@AbdurahmanovBuy", SqlDbType.Decimal).Value = buy[2];
                            //sqlCommand.Parameters.Add("@AbdurahmanovSell", SqlDbType.Decimal).Value = sell[2];
                            //sqlCommand.Parameters.Add("@VarduminBuy", SqlDbType.Decimal).Value = buy[3];
                            //sqlCommand.Parameters.Add("@VarduminSell", SqlDbType.Decimal).Value = sell[3];
                            //sqlCommand.Parameters.Add("@MariyBuy", SqlDbType.Decimal).Value = buy[4];
                            //sqlCommand.Parameters.Add("@MariySell", SqlDbType.Decimal).Value = sell[4];
                            //sqlCommand.Parameters.Add("@MelconynBuy", SqlDbType.Decimal).Value = buy[5];
                            //sqlCommand.Parameters.Add("@MelconynSell", SqlDbType.Decimal).Value = sell[5];
                            //sqlCommand.Parameters.Add("@KolydaBuy", SqlDbType.Decimal).Value = buy[6];
                            //sqlCommand.Parameters.Add("@KolydaSell", SqlDbType.Decimal).Value = sell[6];
                            //sqlCommand.Parameters.Add("@IminovBuy", SqlDbType.Decimal).Value = buy[7];
                            //sqlCommand.Parameters.Add("@IminovSell", SqlDbType.Decimal).Value = sell[7];
                            //sqlCommand.Parameters.Add("@HlebodarBuy", SqlDbType.Decimal).Value = buy[8];
                            //sqlCommand.Parameters.Add("@HlebodarSell", SqlDbType.Decimal).Value = sell[8];
                            //sqlCommand.Parameters.Add("@TeckeevBuy", SqlDbType.Decimal).Value = buy[9];
                            //sqlCommand.Parameters.Add("@TeckeevSell", SqlDbType.Decimal).Value = sell[9];
                            //sqlCommand.Parameters.Add("@TokovBuy", SqlDbType.Decimal).Value = buy[10];
                            //sqlCommand.Parameters.Add("@TokovSell", SqlDbType.Decimal).Value = sell[10];
                            //sqlCommand.Parameters.Add("@TichenkoBuy", SqlDbType.Decimal).Value = buy[11];
                            //sqlCommand.Parameters.Add("@TichenkoSell", SqlDbType.Decimal).Value = sell[11];
                            //sqlCommand.Parameters.Add("@FarheBuy", SqlDbType.Decimal).Value = buy[12];
                            //sqlCommand.Parameters.Add("@FarheSell", SqlDbType.Decimal).Value = sell[12];
                            //sqlCommand.Parameters.Add("@KormaBuy", SqlDbType.Decimal).Value = buy[13];
                            //sqlCommand.Parameters.Add("@KormaSell", SqlDbType.Decimal).Value = sell[13];
                            //sqlCommand.Parameters.Add("@LulyBuy", SqlDbType.Decimal).Value = buy[14];
                            //sqlCommand.Parameters.Add("@LulySell", SqlDbType.Decimal).Value = sell[14];
                            //sqlCommand.Parameters.Add("@LavinaBreadBuy", SqlDbType.Decimal).Value = buy[15];
                            //sqlCommand.Parameters.Add("@LavinaBreadSell", SqlDbType.Decimal).Value = sell[15];
                            //sqlCommand.Parameters.Add("@LavachGrigorynBuy", SqlDbType.Decimal).Value = buy[16];
                            //sqlCommand.Parameters.Add("@LavachGrigorynSell", SqlDbType.Decimal).Value = sell[16];
                            //sqlCommand.Parameters.Add("@CityNSKBreadFactorBuy", SqlDbType.Decimal).Value = buy[17];
                            //sqlCommand.Parameters.Add("@CityNSKBreadFactorSell", SqlDbType.Decimal).Value = sell[17];
                            //sqlCommand.Parameters.Add("@AysanovBuy", SqlDbType.Decimal).Value = buy[18];
                            //sqlCommand.Parameters.Add("@AysanovSell", SqlDbType.Decimal).Value = sell[18];
                            //sqlCommand.Parameters.Add("@Base1", SqlDbType.Decimal).Value = buy[19];
                            //sqlCommand.Parameters.Add("@Base2", SqlDbType.Decimal ).Value = buy[20];
                            //sqlCommand.Parameters.Add("@Base3", SqlDbType.Decimal).Value= buy[21];
                            //sqlCommand.Parameters.Add("@RevaluationPlus", SqlDbType.Decimal).Value = buy[22];
                            sqlCommand.Parameters.Add("@RevaluationMinus", SqlDbType.Decimal).Value = shop.RevaluationMinus;
                            sqlCommand.Parameters.Add("@WriteDowns", SqlDbType.Decimal).Value = shop.WriteDowns;
                            sqlCommand.Parameters.Add("@TotalAmountBuy", SqlDbType.Decimal).Value = shop.TotalAmountBuy;
                            sqlCommand.Parameters.Add("@TotalAmountSell", SqlDbType.Decimal).Value = shop.TotalAmountSell;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        static public void AddToDBExpenditure(string nameDateBase, string data, ObservableCollection<decimal> dateExpenditure, decimal TotalAmount)
        {
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT * FROM {nameDateBase} WHERE Date = @Date";
                    sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = data;
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            List<decimal> list = new List<decimal>();
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                list.Add((decimal)reader[i]);
                            }
                            reader.Close();
                            sqlCommand.Parameters.Clear();
                            sqlCommand.CommandText = $"UPDATE {nameDateBase} SET Nalic = @Nalic, Bank1 = @Bank1, Bank2 = @Bank2, QRcode1 = @QRcode1, " +
                                $"QRcode2 = @QRcode2, SBP = @SBP, ZP = @ZP, TotalAmount = @TotalAmount WHERE Date = @Date";
                            sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Convert.ToDateTime(data);
                            string[] strings = { "Nalic", "Bank1", "Bank2", "QRcode1", "QRcode2", "SBP", "ZP" };
                            for (int i = 0; i < dateExpenditure.Count; i++)
                            {
                                if (dateExpenditure[i] != 0 && dateExpenditure[i] != list[i])
                                {
                                    sqlCommand.Parameters.Add($"@{strings[i]}", SqlDbType.Decimal).Value = dateExpenditure[i];
                                }
                                else
                                {
                                    sqlCommand.Parameters.Add($"@{strings[i]}", SqlDbType.Decimal).Value = list[i];
                                }
                            }
                            sqlCommand.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = list[list.Count - 1] == TotalAmount ? list[list.Count - 1] : TotalAmount;
                            sqlCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            reader.Close();
                            sqlCommand.Parameters.Clear();
                            sqlCommand.CommandText = $"INSERT {nameDateBase} (Date, Nalic, Bank1, Bank2, QRcode1, QRcode2, SBP, ZP, TotalAmount) VALUES (@Date, @Nalic, @Bank1, @Bank2, @QRcode1," +
                       " @QRcode2, @SBP, @ZP, @TotalAmount)";
                            sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Convert.ToDateTime(data);
                            sqlCommand.Parameters.Add("@Nalic", SqlDbType.Decimal).Value = dateExpenditure[0];
                            sqlCommand.Parameters.Add("@Bank1", SqlDbType.Decimal).Value = dateExpenditure[1];
                            sqlCommand.Parameters.Add("@Bank2", SqlDbType.Decimal).Value = dateExpenditure[2];
                            sqlCommand.Parameters.Add("@QRcode1", SqlDbType.Decimal).Value = dateExpenditure[3];
                            sqlCommand.Parameters.Add("@QRcode2", SqlDbType.Decimal).Value = dateExpenditure[4];
                            sqlCommand.Parameters.Add("@SBP", SqlDbType.Decimal).Value = dateExpenditure[5];
                            sqlCommand.Parameters.Add("@ZP", SqlDbType.Decimal).Value = dateExpenditure[6];
                            sqlCommand.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = TotalAmount;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        static public ObservableCollection<decimal> GetDateInvoices(string nameDataBase, string dataTime)
        {
            ObservableCollection<decimal> dates = new ObservableCollection<decimal>();
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT * FROM {nameDataBase} WHERE Date = @Date";
                    sqlCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Convert.ToDateTime(dataTime);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                {
                                    dates.Add((decimal)reader[i]);
                                }
                            }
                        }
                    }
                }
            }
            return dates;
        }
        static public ObservableCollection<Shop> GetDateInvoicesRange(string nameDataBase, string dataTimeOne, string dataTimeTwo)
        {
            ObservableCollection<Shop> shops = new ObservableCollection<Shop>();
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT Date, TotalAmountBuy, TotalAmountSell FROM {nameDataBase} WHERE Date BETWEEN @DateOne AND @DateTwo";
                    sqlCommand.Parameters.Add("@DateOne", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeOne);
                    sqlCommand.Parameters.Add("@DateTwo", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeTwo);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shops.Add(new Shop() { Date = reader[0].ToString().Remove(10), TotalAmountBuy = (decimal)reader[1], TotalAmountSell = (decimal)reader[2] });
                        }
                    }
                }
            }
            return shops;
        }
        static public ObservableCollection<Shop> GetDateInvoicesRangeShop(string nameShopBuy, string nameShopSell, string dataTimeOne, string dataTimeTwo)
        {
            ObservableCollection<ObservableCollection<Shop>> shops = new ObservableCollection<ObservableCollection<Shop>>();
            string[] nameShop = { "ReceiptOfGoodsDostoevskogo11a", "ReceiptOfGoodsMaykovskogo4", "ReceiptOfGoodsMendeleeva42", "ReceiptOfGoodsMendeleeva5", "ReceiptOfGoodsVodoprovodnay358" };
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                for (int i = 0; i < nameShop.Length; i++)
                {
                    shops.Add(new ObservableCollection<Shop>());
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = $"SELECT Date, {nameShopBuy}, {nameShopSell} FROM {nameShop[i]} WHERE Date BETWEEN @DateOne AND @DateTwo";
                        sqlCommand.Parameters.Add("@DateOne", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeOne);
                        sqlCommand.Parameters.Add("@DateTwo", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeTwo);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            int j = 0;
                            while (reader.Read())
                            {
                                shops[i].Add(new Shop() { Date = reader[0].ToString().Remove(10) });
                                shops[i][j].GetType().GetProperty(nameShopBuy).SetValue(shops[i][j], (decimal)reader[1]);
                                shops[i][j].GetType().GetProperty(nameShopSell).SetValue(shops[i][j], (decimal)reader[2]);
                                j++;
                            }
                        }
                    }
                }
            }
            ObservableCollection<Shop> resultShop = new ObservableCollection<Shop>();
            int countWrite = shops[0].Count;
            for (int i = 1; i < shops.Count; i++)
            {
                if (countWrite < shops[i].Count)
                {
                    countWrite = shops[i].Count;
                }
            }
            if(countWrite == 0)
            {
                return new ObservableCollection<Shop>();
            }
            string date = shops[0][0].Date;
            for (int i = 1; i < shops.Count; i++)
            {
                for (int k = 0; k < shops[i].Count; k++)
                {
                    var s  = shops[i][k].Date.Split('.');
                    if (Convert.ToInt32(date.Split('.')[0]) >= Convert.ToInt32(s[0]) && Convert.ToInt32(date.Split('.')[1]) >= Convert.ToInt32(s[1]) 
                        && Convert.ToInt32(date.Split('.')[2]) >= Convert.ToInt32(s[2]))
                    {
                        date = shops[i][k].Date;
                    }
                }
            }
            for (int i = 0; i <= countWrite; i++)
            {
                resultShop.Add(new Shop());
                if (date != null)
                {
                    resultShop[i].Date = date;
                    date = null;
                }
                for (int k = 0; k < shops.Count; k++)
                {
                    for (int j = 0; j < shops[k].Count; j++)
                    {
                        if (j < shops[k].Count)
                        {
                            if (resultShop[i].Date == null && shops[k][j].Date != null)
                            {
                                resultShop[i].Date = shops[k][j].Date;
                            }
                            if (String.Equals(resultShop[i].Date, shops[k][j].Date) && resultShop[i].Date != null)
                            {
                                resultShop[i].RangeProvideBuy += (decimal)shops[k][j].GetType().GetProperty(nameShopBuy).GetValue(shops[k][j]);
                                resultShop[i].RangeProvideSell += (decimal)shops[k][j].GetType().GetProperty(nameShopSell).GetValue(shops[k][j]);
                                shops[k][j].Date = null;
                            }
                        }
                    }
                }
            }
            return resultShop;
        }
        static public ObservableCollection<Shop> GetDateInvoicesRangeShop(string nameField, string dataTimeOne, string dataTimeTwo)
        {
            ObservableCollection<ObservableCollection<Shop>> shops = new ObservableCollection<ObservableCollection<Shop>>();
            string[] nameShop = { "ReceiptOfGoodsDostoevskogo11a", "ReceiptOfGoodsMaykovskogo4", "ReceiptOfGoodsMendeleeva42", "ReceiptOfGoodsMendeleeva5", "ReceiptOfGoodsVodoprovodnay358" };
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                for (int i = 0; i < nameShop.Length; i++)
                {
                    shops.Add(new ObservableCollection<Shop>());
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = $"SELECT Date, {nameField} FROM {nameShop[i]} WHERE Date BETWEEN @DateOne AND @DateTwo";
                        sqlCommand.Parameters.Add("@DateOne", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeOne);
                        sqlCommand.Parameters.Add("@DateTwo", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeTwo);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            int j = 0;
                            while (reader.Read())
                            {
                                shops[i].Add(new Shop() { Date = reader[0].ToString().Remove(10) });
                                shops[i][j].GetType().GetProperty(nameField).SetValue(shops[i][j], (decimal)reader[1]);
                                j++;
                            }
                        }
                    }
                }
            }
            ObservableCollection<Shop> resultShop = new ObservableCollection<Shop>();
            int countWrite = shops[0].Count;
            for (int i = 1; i < shops.Count; i++)
            {
                if (countWrite < shops[i].Count)
                {
                    countWrite = shops[i].Count;
                }
            }
            if (countWrite == 0)
            {
                return new ObservableCollection<Shop>();
            }
            string date = shops[0][0].Date;
            for (int i = 1; i < shops.Count; i++)
            {
                for (int k = 0; k < shops[i].Count; k++)
                {
                    var s = shops[i][k].Date.Split('.');
                    if (Convert.ToInt32(date.Split('.')[0]) >= Convert.ToInt32(s[0]) && Convert.ToInt32(date.Split('.')[1]) >= Convert.ToInt32(s[1])
                        && Convert.ToInt32(date.Split('.')[2]) >= Convert.ToInt32(s[2]))
                    {
                        date = shops[i][k].Date;
                    }
                }
            }
            for (int i = 0; i <= countWrite; i++)
            {
                resultShop.Add(new Shop());
                if (date != null)
                {
                    resultShop[i].Date = date;
                    date = null;
                }
                for (int k = 0; k < shops.Count; k++)
                {
                    for (int j = 0; j < shops[k].Count; j++)
                    {
                        if (j < shops[k].Count)
                        {
                            if (resultShop[i].Date == null && shops[k][j].Date != null)
                            {
                                resultShop[i].Date = shops[k][j].Date;
                            }
                            if (String.Equals(resultShop[i].Date, shops[k][j].Date) && resultShop[i].Date != null)
                            {
                                resultShop[i].RangeProvideBuy += (decimal)shops[k][j].GetType().GetProperty(nameField).GetValue(shops[k][j]);
                                resultShop[i].RangeProvideSell += (decimal)shops[k][j].GetType().GetProperty(nameField).GetValue(shops[k][j]);
                                shops[k][j].Date = null;
                            }
                        }
                    }
                }
            }
            return resultShop;
        }
        static public ObservableCollection<Shop> GetDateExpenditureRange(string nameDataBase, string dataTimeOne, string dataTimeTwo)
        {
            ObservableCollection<Shop> shops = new ObservableCollection<Shop>();
            using (SqlConnection sqlConnection = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\DBCreate\\DatabaseInvoices.mdf;Integrated Security=True"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT Date, TotalAmount FROM {nameDataBase} WHERE Date BETWEEN @DateOne AND @DateTwo";
                    sqlCommand.Parameters.Add("@DateOne", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeOne);
                    sqlCommand.Parameters.Add("@DateTwo", SqlDbType.Date).Value = Convert.ToDateTime(dataTimeTwo);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shops.Add(new Shop() { DateExpenditure = reader[0].ToString().Remove(10), TotalAmountExpenditure = (decimal)reader[1] });
                        }
                    }
                }
            }
            return shops;
        }
    }
}
