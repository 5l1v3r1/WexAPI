# WexPublicLibrary
WexLibrary Easy way to use the Wex.nz Public API.

Their site https://wex.nz/

Public API Documentation https://wex.nz/api/3/docs

If you want to use this library in your project, you will need use this library https://www.newtonsoft.com/json.

## Examples:

```c#
var wx = new WexCurrency();
string btcBuy = wx.Ticker.GetBuy("btc_usd"); // pyrchase price btc
------------------------------
var wx = new WexCurrency();
string btcMin = wx.InfoGetMinPrice("btc_usd"); // min price btc
-------------------------------
var wx = new WexCurrency();
var pairArray = wx.DepthGetAllPairs("btc_rur") // get 150 activity orders. You can set limit orders, but limit <=5000
```
### and etc.

### If you find errors or you have suggestions, please write to me at the e-mail : falweek@gmail.com
