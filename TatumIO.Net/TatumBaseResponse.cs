using Compila.Net.Utils.ServiceResponses;

namespace TatumIO.Net
{
	public class TatumBaseResponse
	{
		public bool Success { get; set; }

		public TatumBaseResponse(bool success)
		{
			Success = success;
		}
	}

	public static class TatumBaseResponseExtensions
	{
		public static TResultType GetResult<TResultType>(this TatumBaseResponse tatumBaseResponse)
		{
			if (tatumBaseResponse is TatumOkResponse<TResultType> okResponse)
			{
				return okResponse.Result;
			}

			throw new InvalidOperationException($"Response is not of type TatumOkResponse<{nameof(TResultType)}>");
		}
	}

	public class TatumOkResponse<T> : TatumBaseResponse
	{
		public T Result { get; set; }

		public TatumOkResponse(T result) : base(true)
		{
			Result = result;
		}

		public T GetResult()
		{
			return Result;
		}
	}

	public class TatumOkResponse : TatumBaseResponse
	{
		public TatumOkResponse() : base(true)
		{
		}
	}

	public class TatumErrorResponse : TatumBaseResponse
	{
		public string Message { get; set; }
		public TatumErrorResponse(string message) : base(false)
		{
			Message = message;
		}
	}
}
