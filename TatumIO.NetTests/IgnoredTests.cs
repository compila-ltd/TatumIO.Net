using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TatumIO.Net;
using TatumIO.Net.Objects.GasPump;
using TatumIO.Net.Objects.GasPump.Payload;
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
			var address = response.GetResult<VirtualAccountAddress>();
			Assert.IsNotNull(address);
			Assert.IsNotNull(address.Address);
		}

		[TestMethod()]
		public void AssignNewAddressTest()
		{
			var response = Client.VirtualAccount.AssignNewAddress(GenerateAccountId, "0x0").Result;
			Assert.IsTrue(response.Success);
			var address = response.GetResult<VirtualAccountAddress>();
			Assert.IsNotNull(address);
			Assert.IsNotNull(address.Address);
		}

		[TestMethod()]
		public void PrecalculateAddressTest()
		{
			var payload = new PrecalculateAddressesPayload
			{
				Chain = "MATIC",
				Owner = Configuration["Tatum:Gas-Pump:MATIC:Owner"] ?? "0x0",
				From = 0,
				To = 49
			};
			var response = Client.GasPump.PrecalculateAddresses(payload).Result;
			Assert.IsTrue(response.Success);
			var addressesList = response.GetResult<List<string>>();
			Assert.IsNotNull(addressesList);
			Assert.AreEqual(50, addressesList.Count);
			Assert.AreEqual(Configuration["Tatum:Gas-Pump:MATIC:Pre-Calculated"], addressesList[0]);
		}

		[TestMethod()]
		public void AddressIsAsignedTest()
		{
			var response = Client.VirtualAccount.AddressIsAssigned(Configuration["Tatum:Virtual-Accounts:MATIC:Address"], "MATIC").Result;
			Assert.IsTrue(response.Success);
			var account = response.GetResult<VirtualAccountInfo>();
			var isAssigned = account.Id?.Equals(Configuration["Tatum:Virtual-Accounts:MATIC:Id"]);
			Assert.IsTrue(isAssigned);
		}

		[TestMethod()]
		public void AddressIsActivated()
		{
			var response = Client.GasPump.AddressIsActivated("MATIC", Configuration["Tatum:Gas-Pump:MATIC:Owner"], 0).Result;
			Assert.IsTrue(response.Success);
			var activatedAddress = response.GetResult<AddressIsActivated>();
			var isActivated = activatedAddress.Activated;
			Assert.IsTrue(isActivated);
		}

		[TestMethod()]
		public void ActivateGasPumpKMS()
		{
			var response = Client.GasPump.ActivateAddresses(new ActivateAddressesKMSPayload
			{
				Chain = "MATIC",
				Owner = Configuration["Tatum:Gas-Pump:MATIC:Owner"],
				From = 14,
				To = 15,
				SignatureId = Configuration["Tatum:Gas-Pump:MATIC:SignatureId"]
			}).Result;

			Assert.IsTrue(response.Success);
			var signatureId = response.GetResult<ActivateAddresses>().SignatureId;
			Assert.IsNotNull(signatureId);
		}
	}
}
