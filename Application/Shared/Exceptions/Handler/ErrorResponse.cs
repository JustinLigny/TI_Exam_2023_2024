namespace Application.Shared.Exceptions.Handler;

    public class ErrorResponse
    {
        public int Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string Path { get; set; }
        
        public Dictionary<string, string> Errors { get; set; }

        public ErrorResponse(int status, string path, Dictionary<string, string> errors)
        {
            Status = status;
            Timestamp = DateTime.UtcNow;
            Path = path;
            Errors = errors;
        }
    }