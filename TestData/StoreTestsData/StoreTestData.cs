using PetstoreTests.Models;
using PetstoreTests.Helpers;

namespace PetstoreTests.TestData
{
    public static class StoreTestData
    {
        /// <summary>
        /// Основные методы для получения пути к JSON файлам с тестовыми данными и десериализации их в объекты для выполнения тестов
        /// <returns></returns>
        private static string GetJsonFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
        }
        public static IEnumerable<Order> GetOrderJsonBody
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("orders.json"));
                return JsonHelper.Deserialize<List<Order>>(json);
            }
        }
        public static IEnumerable<long> GetOrderIds
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("ordersID.json"));
                return JsonHelper.Deserialize<List<long>>(json);
            }
            
        }
        public static IEnumerable<string> GetInvalidOrdersId
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("ordersID_InvalidIDs.json"));
                return JsonHelper.Deserialize<List<string>>(json);
            }
        }
        public static IEnumerable<long> GetUnexistedOrdersId
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("ordersID_UnexistedIDs.json"));
                return JsonHelper.Deserialize<List<long>>(json);
            }
        }
    }

}