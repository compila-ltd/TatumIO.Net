using System.Reflection;

using Compila.Net.Utils;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TatumIO.Net;
using TatumIO.Net.Objects.VirtualAccounts;
using TatumIO.Net.QueryParams.VirtualAccounts;

namespace TatumIO.NetTests.VirtualAccounts
{
	[TestClass()]
	[TestCategory("Ignore")]
	public class IgnoredDepositsTests
	{
		private readonly ClientSdk Client;
		private readonly string ApiKey;
		private readonly string DepositsAccountId;
		private readonly IConfiguration Configuration;

		public IgnoredDepositsTests()
		{
			var builder = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).AddEnvironmentVariables();
			Configuration = builder.Build();

			ApiKey = Configuration["Tatum:ApiKey"] ?? "";
			DepositsAccountId = Configuration["Tatum:DepositsAccountId"] ?? "";

			Client = new ClientSdk(ApiKey);
		}

		[TestMethod]
		public void ListAllDepositsTest()
		{
			var response = Client.VirtualAccount.GetDepositsForProduct(new DepositsQueryParams
			{
				AccountId = DepositsAccountId,
			}).Result;

			Assert.IsTrue(response.Success);
			var deposits = response.GetResult<VirtualAccountDepositsList>();
			Assert.IsNotNull(deposits);
			Assert.IsTrue(deposits.Count > 0);
		}

		[TestMethod]
		public void ListAllDepositsWithPagingTest()
		{
			var response = Client.VirtualAccount.GetDepositsForProduct(new DepositsQueryParams
			{
				AccountId = DepositsAccountId,
				PageSize = 1,
			}).Result;
			Assert.IsTrue(response.Success);
			var deposits = response.GetResult<VirtualAccountDepositsList>();
			Assert.IsNotNull(deposits);
			Assert.IsTrue(deposits.Count == 1);
		}

		[TestMethod]
		public void GetCountOfDepositsTest()
		{
			var response = Client.VirtualAccount.GetDepositsCountForProduct(new DepositsQueryParams
			{
				AccountId = DepositsAccountId,
			}).Result;
			Assert.IsTrue(response.Success);
			var count = response.GetResult<VirtualAccountDepositsCount>();
			Assert.IsTrue(count.Total > 0);
		}
	}
}
