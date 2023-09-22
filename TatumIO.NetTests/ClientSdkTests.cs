using System.Reflection;

using Compila.Net.Utils;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TatumIO.Net.Objects.VirtualAccounts;

namespace TatumIO.Net.Tests
{
	[TestClass()]
	[TestCategory("Execute")]
	public class ClientSdkTests
	{
		private readonly ClientSdk Client;
		private readonly string ApiKey;
		private readonly string InfoAccountId;
		private readonly IConfiguration Configuration;


		public ClientSdkTests()
		{
			var builder = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).AddEnvironmentVariables();
			Configuration = builder.Build();

			ApiKey = Configuration["Tatum:ApiKey"] ?? "";
			InfoAccountId = Configuration["Tatum:InfoAccountId"] ?? "";

			Client = new ClientSdk(ApiKey);
		}

		[TestMethod()]
		public void GetAccountInfoTest()
		{
			var response = Client.VirtualAccount.GetAccountInfo(InfoAccountId).Result;
			Assert.IsTrue(response.Success);
			var info = response.GetResult<VirtualAccountInfo>();
			Assert.IsNotNull(info);
			Assert.AreEqual(InfoAccountId, info.Id);
		}
	}
}