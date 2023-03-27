namespace skinet2.Errors
{
	public class ApiResponse
	{
        public ApiResponse(int statusCode, string message = null)
        {
            Status = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(Status);
        }

		private string GetDefaultMessageForStatusCode(int status)
		{
			return status switch
			{
				400 => "A bad request, you have made",
				401 => "Authorized, you are not",
				404 => "Resource found, it was not",
				500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
				_ => null,
			};
		}

		public int Status { get; set; }

        public string Message { get; set; }
    }
}
