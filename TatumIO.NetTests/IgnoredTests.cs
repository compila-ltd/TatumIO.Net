using System.Reflection;

using Compila.Net.Utils;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TatumIO.Net;
using TatumIO.Net.Objects.VirtualAccounts;

namespace TatumIO.NetTests
{
	[TestClass()]
	[TestCategory("Ignore")]
	public class IgnoredTests
	{
		private readonly ClientSdk Client;
		private readonly string ApiKey;
		private readonly string GenerateAccountId;
		private readonly IConfiguration Configuration;

		public IgnoredTests()
		{
			var builder = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).AddEnvironmentVariables();
			Configuration = builder.Build();

			ApiKey = Configuration["Tatum:ApiKey"] ?? "";
			GenerateAccountId = Configuration["Tatum:GenerateAccountId"] ?? "";

			Client = new ClientSdk(ApiKey);
		}

		[TestMethod()]
		public void CreateDepositAddressTest()
		{
			var response = Client.VirtualAccount.CreateDepositAddress(GenerateAccountId, null).Result;
			Assert.IsTrue(response.Success);
			var info = response.GetResult<VirtualAccountAddress>();
			Assert.IsNotNull(info);
			Assert.IsNotNull(info.Address);
		}
	}
}
