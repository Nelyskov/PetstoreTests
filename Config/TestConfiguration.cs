namespace PetstoreTests.Config
{
    public class TestConfiguration
    {
        /// <summary>
        /// URL адрес на песочница для тестирования API
        /// Можно заменить на любой URL адрес хоста или IP адрес с указанием порта
        /// </summary>
        public string BaseUrl { get; set; } = "https://petstore.swagger.io/v2";
    }
}