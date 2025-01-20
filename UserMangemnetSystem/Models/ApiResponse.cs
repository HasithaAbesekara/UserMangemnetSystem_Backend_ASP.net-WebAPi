namespace UserMangemnetSystem.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }  // Indicates success or failure
        public string Message { get; set; }  // Custom response message
        public T? Data { get; set; }  // Holds the actual data (nullable)

        public ApiResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
