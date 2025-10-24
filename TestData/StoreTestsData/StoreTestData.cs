using PetstoreTests.Models;
using PetstoreTests.Helpers;

namespace PetstoreTests.TestData
{
    public static class StoreTestData
    {
        public static IEnumerable<Order> GetOrderJsonBody
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("orders.json"));
                return JsonHelper.Deserialize<List<Order>>(json);
            }
        }
    }

}