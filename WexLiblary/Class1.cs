using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WexLiblary
{
    public class WexCurrency
    {
        #region Field

        private string TickerUrl { get; } = @"https://wex.nz/api/3/ticker/"; //url for ticket method

        private string AllPairInfo { get; } = @"https://wex.nz/api/3/info/"; //url for info method

        private WebClient Client { get; } = new WebClient();

        private string Trades { get; } = @"https://wex.nz/api/3/trades/"; //url for trades method

        private string Depth { get; } = @"https://wex.nz/api/3/depth/"; //url for Depth method
        private string Response { get; set; } = null;

        #endregion
        //region ticker method
        #region Ticker
        public string TickerGetBuy(string currencyPair) //get pyrchase price
        {
            string outPairBuy = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairBuy = realTime.Parent["buy"].ToString();
                    break;
                }
                return outPairBuy;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string TickerGetSell(string currencyPair) //get selling price
        {
            string outPairSell = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairSell = realTime.Parent["sell"].ToString();
                    break;
                }
                return outPairSell;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string TickerGetHighPair(string currencyPair) //get max price
        {
            string outPairHigh = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairHigh = realTime.Parent["high"].ToString();
                    break;
                }
                return outPairHigh;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string TickerGetLowPair(string currencyPair)//get low price
        {
            string outPairLow = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairLow = realTime.Parent["low"].ToString();
                    break;
                }
                return outPairLow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string TickerGetAvgPair(string currencyPair)// get avg price
        {
            string outPairAvg = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairAvg = realTime.Parent["avg"].ToString();
                    break;
                }
                return outPairAvg;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public string TickerGetFirstVolume(string currencyPair)// example : btc/uds. First is btc
        {
            string outPairFirstVolume = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairFirstVolume = realTime.Parent["vol_cur"].ToString();
                    break;
                }
                return outPairFirstVolume;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string TickerGetSecondValuePair(string currencyPair)//example : btc/usd. Second is usd
        {
            string outPairSecondValuePair = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairSecondValuePair = realTime.Parent["vol"].ToString();
                    break;
                }
                return outPairSecondValuePair;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public string TickerGetLastPrice(string currencyPair) // get price last deal
        {
            string outLastPrice = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outLastPrice = realTime.Parent["last"].ToString();
                    break;
                }
                return outLastPrice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion // region Ticker method
        //region info method
        #region Info
        public JToken[] InfoGetAllPairInfo() //get array information about Pairs
        {
            Response = Client.DownloadString(AllPairInfo);
            var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
            return pairsInfo;
        }
        public string InfoGetFee(string currencyPair)
        {
            try
            {
                var fee = "";
                Response = Client.DownloadString(AllPairInfo);
                var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
                foreach (var z in pairsInfo)
                {
                    fee = z.Parent[currencyPair]["fee"].ToString();
                    return fee;
                }
                return fee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }//

        public string InfoGetDecimalPlaces(string currencyPair)
        {
            try
            {
                var decimalPlaces = "";
                Response = Client.DownloadString(AllPairInfo);
                var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
                foreach (var z in pairsInfo)
                {
                    decimalPlaces = z.Parent[currencyPair]["decimal_places"].ToString();
                    return decimalPlaces;
                }
                return decimalPlaces;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string InfoGetMinPrice(string currencyPair)
        {
            try
            {
                var minPrice = "";
                Response = Client.DownloadString(AllPairInfo);
                var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
                foreach (var z in pairsInfo)
                {
                    minPrice = z.Parent[currencyPair]["min_price"].ToString();
                    return minPrice;
                }
                return minPrice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string InfoGetMaxPrice(string currencyPair)
        {
            try
            {
                var maxPrice = "";
                Response = Client.DownloadString(AllPairInfo);
                var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
                foreach (var z in pairsInfo)
                {
                    maxPrice = z.Parent[currencyPair]["max_price"].ToString();
                    return maxPrice;
                }
                return maxPrice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string InfoGetMinAmount(string currencyPair)
        {
            try
            {
                var MinAmount = "";
                Response = Client.DownloadString(AllPairInfo);
                var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
                foreach (var z in pairsInfo)
                {
                    MinAmount = z.Parent[currencyPair]["min_amount"].ToString();
                    return MinAmount;
                }
                return MinAmount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool InfoHidden(string currencyPair)
        {
            try
            {
                var hidden = "";
                var isHidden = false;
                var count = 0;
                Response = Client.DownloadString(AllPairInfo);
                var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
                foreach (var z in pairsInfo)
                {
                    hidden = z.Parent[currencyPair]["hidden"].ToString();
                    count = int.Parse(hidden);
                    if (count == 1)
                        isHidden = true;

                }
                return isHidden;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
        //region depth method
        #region Depth

        public JToken[] DepthGetAllPairs(string currencyPair) //get 150 activity orders
        {
            try
            {
                var depthPair = Client.DownloadString(Depth + currencyPair);
                var respArray = JObject.Parse(depthPair)[currencyPair].ToArray();
                return respArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetAllPairs(string currencyPair, string limit) //limit cant not be more than 5000
        {
            try
            {
                if (Convert.ToInt32(limit) >= 5000)
                    limit = "5000";
                var depthPair = Client.DownloadString(Depth + currencyPair + "?limit=" + limit);
                var respArray = JObject.Parse(depthPair)[currencyPair].ToArray();
                return respArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetAsks(string currencyPair) //get asks order (order for sale)
        {
            try
            {
                var depthAsksPair = Client.DownloadString(Depth + currencyPair);
                var respAsksArray = JObject.Parse(depthAsksPair)[currencyPair]["asks"].ToArray();
                return respAsksArray;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public JToken[] DepthGetAsks(string currencyPair, string limit)
        {
            try
            {
                if (Convert.ToInt32(limit) >= 5000)
                    limit = "5000";
                var depthAskPair = Client.DownloadString(Depth + currencyPair + "?limit=" + limit);
                var respAsksArray = JObject.Parse(depthAskPair)[currencyPair]["asks"].ToArray();
                return respAsksArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }//limit cant not be more than 5000

        public JToken[] DepthGetBids(string currencyPair)//get bids order(order for purchase)
        {
            try
            {
                var depthBidsPair = Client.DownloadString(Depth + currencyPair);
                var respDibsArray = JObject.Parse(depthBidsPair)[currencyPair]["bids"].ToArray();
                return respDibsArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetBids(string currencyPair, string limit)//limit cant not be more than 5000
        {
            try
            {
                if (Convert.ToInt32(limit) >= 5000)
                    limit = "5000";
                var depthBidsPair = Client.DownloadString(Depth + currencyPair + "?limit=" + limit);
                var respDibsArray = JObject.Parse(depthBidsPair)[currencyPair]["bids"].ToArray();
                return respDibsArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        #endregion
        //region trades method
        #region Trades

        public JToken[] GetTrades(string currencyPair) // info about last deal
        {
            try
            {
                var getTrades = Client.DownloadString(Trades + currencyPair);
                var tradesArray = JObject.Parse(getTrades)[currencyPair].ToArray();
                return tradesArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] GetTrades(string currencyPair, string limit)//limit cant not be more than 5000
        {
            try
            {
                var getTrades = Client.DownloadString(Trades + currencyPair + "?limit=" + limit);
                var tradesArray = JObject.Parse(getTrades)[currencyPair].ToArray();
                return tradesArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        #endregion
    }
}
