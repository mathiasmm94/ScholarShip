using Microsoft.AspNetCore.Mvc.Testing;
using ModelsApi.Models.DTOs;
using ModelsApi.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Test
{
	internal class ManagersControllerTests
	{
		private HttpClient _client = null;

		[OneTimeSetUp]
		public void Init()
		{
			var token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1c2VyQG1haWwuZGsiLCJOYW1lIjoiVXNlciIsIm5iZiI6IjE2ODQ4NjAyMDQiLCJleHAiOiIxNjg0OTQ2NjA0IiwiRWZNYW5hZ2VySWQiOiIxIn0.A-BMGcb3uzD4y4wC9QgRJP5_muUl04elqwFjEMOgaPM";

			var applicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
			_client = applicationFactory.CreateClient();
			_client.BaseAddress = new Uri("https://localhost:7181");
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}
		[Test]
		public async Task GetManagers_ReturnsListOfManagers()
		{
			// Act
			var response = await _client.GetAsync("/api/managers");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			var managers = JsonConvert.DeserializeObject<List<EfManager>>(await response.Content.ReadAsStringAsync());
			
			Assert.NotNull(managers.ToList());

		}

		[Test]
		public async Task GetManager_ReturnsManagerById()
		{
			// Arrange
			var managerId = 3;

			// Act
			var response = await _client.GetAsync($"/api/managers/{managerId}");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			var manager = JsonConvert.DeserializeObject<EfManager>(await response.Content.ReadAsStringAsync());
			Assert.NotNull(manager);
			Assert.AreEqual(managerId, manager.EfManagerId);
		}


		[Test]
		public async Task GetManager_ReturnsNotFoundForInvalidId()
		{
			// Arrange
			var invalidManagerId = 999;

			// Act
			var response = await _client.GetAsync($"/api/managers/{invalidManagerId}");

			// Assert
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}

		[Test]
		public async Task PutManager_UpdatesManager()
		{
			// Arrange
			var managerId = 3;
			var managerDto = new UpdateManagerDTO
			{
				FirstName = "Jan",
				LastName = "Dan",
				Email = "asd@emple.com",
				PhoneNumber = "12345670",
				Birthdate = "02-02-2023",
				University = "Example Uni"
			};

			var jsonContent = JsonConvert.SerializeObject(managerDto);
			var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

			// Act
			var response = await _client.PutAsync($"/api/managers/{managerId}", content);

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Expected status code {HttpStatusCode.OK}, but received {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");

			var updatedManager = JsonConvert.DeserializeObject<EfManager>(await response.Content.ReadAsStringAsync());

			Console.WriteLine(updatedManager.FirstName);
			Assert.NotNull(updatedManager);
			Assert.AreEqual(managerId, updatedManager.EfManagerId);
			Assert.AreEqual(managerDto.FirstName, updatedManager.FirstName);
			Assert.AreEqual(managerDto.LastName, updatedManager.LastName);
			Assert.AreEqual(managerDto.Email, updatedManager.Email);
			Assert.AreEqual(managerDto.PhoneNumber, updatedManager.PhoneNumber);
			Assert.AreEqual(managerDto.Birthdate, updatedManager.Birthdate);
			Assert.AreEqual(managerDto.University, updatedManager.University);
			
		}

		[Test]
		public async Task PutManager_ReturnsBadRequestForInvalidId()
		{
			// Arrange
			var invalidManagerId = 999;
			var managerDto = new UpdateManagerDTO
			{
				FirstName = "Jan",
				LastName = "Dan",
				Email = "janDan@example.com",
				PhoneNumber = "12345678",
				Birthdate = "02-02-2023",
				University = "Example Uni"
			};

			var jsonContent = JsonConvert.SerializeObject(managerDto);
			var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

			// Act
			var response = await _client.PutAsync($"/api/managers/{invalidManagerId}", content);

			// Assert
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}



	}
}
