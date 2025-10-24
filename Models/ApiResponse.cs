namespace PetstoreTests.Models
{
    public class ApiResponse
    {
        /// <summary>
        /// Телор API ответа
        /// </summary>
        public int Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}