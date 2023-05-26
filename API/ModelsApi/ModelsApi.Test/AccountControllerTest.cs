using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ModelsApi.Models.DTOs;
using Newtonsoft.Json;
using System.Text;
using static System.Net.HttpStatusCode;
using System.Net.Http.Headers;

namespace ModelsApi.Test
{
	internal class AccountControllerTest
	{
		private HttpClient _client = null;

		[OneTimeSetUp]
		public void Init()
		{
			var applicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
			_client = applicationFactory.CreateClient();
		}


		[Test]
		public async Task Login_ValidLogin_ReturnsToken()
		{
			var login = new Login { Email = "user2@mail.dk", Password = "Pas123" };

			var body = JsonContent.Create(login);

			var response = await _client.PostAsync("/api/account/login", body);

			response.EnsureSuccessStatusCode();

			var token = await response.Content.ReadFromJsonAsync<Token>();


			Assert.NotNull(token);
			Assert.NotNull(token.JWT);

			// Verify authentication using the obtained token, by calling a get function that needs the authentication.
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.JWT);
			var authenticatedResponse = await _client.GetAsync("/api/Annonces");

			// Assert that the authenticated request is successful
			authenticatedResponse.EnsureSuccessStatusCode();
		}

		[Test]
		public async Task Login_InvalidLogin_ReturnsBadRequest()
		{

			var login = new Login { Email = "user22@mail.dk", Password = "Pas1234" };

			var body = JsonContent.Create(login);

			var response = await _client.PostAsync("/api/account/login", body);

			
			Assert.AreEqual(BadRequest, response.StatusCode);

			
			var responseJson = await response.Content.ReadAsStringAsync();
			var responseObj = JsonConvert.DeserializeObject<dynamic>(responseJson);
			var error = responseObj.Message[0].ToString();
			Assert.AreEqual("Invalid login", error);
		}

		[Test]
		public async Task Register_ValidUser_ReturnsCreated()
		{
			var user = new RegisterUser
			{
				FirstName = "Hans",
				LastName = "Grethe",
				Birthdate = "02-02-2022",
				Email = "drd@example.com",
				Password = "password",
				ConfirmPassword = "password",
				University = "Test University",
				PhoneNumber = "12345672"
			};

			var json = JsonConvert.SerializeObject(user);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("/api/account/register", content);

			var responseBody = await response.Content.ReadAsStringAsync();

			
			Assert.AreEqual(Created, response.StatusCode);

			Assert.IsTrue(string.IsNullOrEmpty(responseBody), "Response body should be empty or null.");
		}


		[Test]
		public async Task Register_InvalidUser_ReturnsMailError()
		{
			var user = new RegisterUser
			{
				FirstName = "Hans",
				LastName = "Grethe",
				Birthdate = "02-02-2022",
				Email = "user2@mail.dk",
				Password = "password",
				ConfirmPassword = "password",
				University = "Test University",
				PhoneNumber = "12345678"
			};

			var json = JsonConvert.SerializeObject(user);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("/api/account/register", content);



			Assert.AreEqual(BadRequest, response.StatusCode);

			var responseJson = await response.Content.ReadAsStringAsync();
			dynamic responseObj = JsonConvert.DeserializeObject<dynamic>(responseJson);
			var error = responseObj.error.ToString();

			Assert.AreEqual("Email already exists", error);
		}

		[Test]
		public async Task Register_InvalidUser_ReturnsPhoneError()
		{
			var user = new RegisterUser
			{
				FirstName = "Hans",
				LastName = "Grethe",
				Birthdate = "02-02-2022",
				Email = "test@mail.dk",
				Password = "password",
				ConfirmPassword = "password",
				University = "Test University",
				PhoneNumber = "12121212"
			};

			var json = JsonConvert.SerializeObject(user);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("/api/account/register", content);

			Assert.AreEqual(BadRequest, response.StatusCode);

			var responseJson = await response.Content.ReadAsStringAsync();
			dynamic responseObj = JsonConvert.DeserializeObject<dynamic>(responseJson);
			var error = responseObj.error.ToString();

			Assert.AreEqual("Phonenumber already exists", error);
		}
	}
}
