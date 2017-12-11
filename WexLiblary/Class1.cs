using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WexLiblary
{
    public class WexCurrency
    {
        #region Field

        public string TickerUrl { get; } = @"https://wex.nz/api/3/ticker/";

        public string AllPairInfo { get; } = @"https://wex.nz/api/3/info/";

        public WebClient Client { get; } = new WebClient();

        public string Trades { get; } = @"https://wex.nz/api/3/trades/";

        public string Depth { get; } = @"https://wex.nz/api/3/depth/";
        public JToken[] AllPairsInfo { get; set; } = null;
        public string Response { get; set; } = null;

        #endregion

        #region Ticker
        public string GetBuy(string currencyPair)
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

        public string TickerGetSell(string currencyPair)
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

        public string TickerGetHighPair(string currencyPair)
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

        public string TickerGetLowPair(string currencyPair)
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

        public string TickerGetAvgPair(string currencyPair)
        {
            string outPairAvg = null;
            try
            {
                Response = Client.DownloadString(TickerUrl + currencyPair);
                var pairInfo = JObject.Parse(Response)[currencyPair].ToArray();
                foreach (var realTime in pairInfo)
                {
                    outPairAvg = realTime.Parent["high"].ToString();
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
        public string TickerGetFirstVolume(string currencyPair)
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

        public string TickerGetSecondValuePair(string currencyPair)
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

        public string TickerGetLastPrice(string currencyPair)
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

        #endregion

        #region Info
        public JToken[] InfoGetAllPairInfo()
        {
            Response = Client.DownloadString(AllPairInfo);
            var pairsInfo = JObject.Parse(Response)["pairs"].ToArray();
            AllPairsInfo = pairsInfo;
            return pairsInfo;
        }
        public string InfoGetFee(string currencyPair)
        {
            try
            {
                var fee = "";
                foreach (var z in AllPairsInfo)
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
        }

        public string InfoGetDecimalPlaces(string currencyPair)
        {
            try
            {
                var decimalPlaces = "";
                foreach (var z in AllPairsInfo)
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
                foreach (var z in AllPairsInfo)
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
                foreach (var z in AllPairsInfo)
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
                foreach (var z in AllPairsInfo)
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
                foreach (var z in AllPairsInfo)
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

        #region Depth

        public JToken[] DepthGetAllPairs(string currencyPair)
        {
            try
            {
                var depthPair = Client.DownloadString(Depth);
                var respArray = JObject.Parse(depthPair)[currencyPair].ToArray();
                return respArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetAllPairs(string currencyPair, string limit)
        {
            try
            {
                var depthPair = Client.DownloadString(Depth + "?limit=" + limit);
                var respArray = JObject.Parse(depthPair)[currencyPair].ToArray();
                return respArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetAsks(string currencyPair)
        {
            try
            {
                var depthAsksPair = Client.DownloadString(Depth);
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
                var depthAskPair = Client.DownloadString(Depth + "?limit=" + limit);
                var respAsksArray = JObject.Parse(depthAskPair)[currencyPair]["asks"].ToArray();
                return respAsksArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetBids(string currencyPair)
        {
            try
            {
                var depthBidsPair = Client.DownloadString(Depth);
                var respDibsArray = JObject.Parse(depthBidsPair)[currencyPair]["bids"].ToArray();
                return respDibsArray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public JToken[] DepthGetBids(string currencyPair, string limit)
        {
            try
            {
                var depthBidsPair = Client.DownloadString(Depth + "?limit=" + limit);
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

        #region Trades

        public JToken[] GetTrades(string currencyPair)
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

        public JToken[] GetTrades(string currencyPair, string limit)
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
