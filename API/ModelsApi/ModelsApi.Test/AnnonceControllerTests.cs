using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ModelsApi.Models.DTOs;
using Newtonsoft.Json;
using System.Text;
using static System.Net.HttpStatusCode;
using System.Net;
using System.Net.Http.Headers;
using ModelsApi.Models;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace ModelsApi.Test
{
	public class AnnonceControllerTests
	{
		private HttpClient _client = null;
		private HttpClient _httpClient = null;

		[OneTimeSetUp]
		public void Init()
		{
			var token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1c2VyQG1haWwuZGsiLCJOYW1lIjoiVXNlciIsIm5iZiI6IjE2ODQ4NjAyMDQiLCJleHAiOiIxNjg0OTQ2NjA0IiwiRWZNYW5hZ2VySWQiOiIxIn0.A-BMGcb3uzD4y4wC9QgRJP5_muUl04elqwFjEMOgaPM";

			var applicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
			_client = applicationFactory.CreateClient();
			_client.BaseAddress = new Uri("https://localhost:7181");
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			_httpClient = applicationFactory.CreateClient();
			_httpClient.BaseAddress = new Uri("https://localhost:7181");
		}

		
		[Test]
		public async Task GetAnnonces_ReturnsOk()
		{
			// Act
			var response = await _client.GetAsync("/api/Annonces");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public async Task GetAnnonces_returnNotAuth()
		{

			var response = await _httpClient.GetAsync("/api/Annonces");

			// Assert
			Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);

		}

		[Test]
		public async Task GetAnnoncesWithCheckBoxValue_ReturnsOk()
		{
			// Arrange
			var checkBoxValue = true;

			// Act
			var response = await _client.GetAsync($"/api/Annonces/CheckBoxValue?checkBoxValue={checkBoxValue}");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public async Task GetAnnonce_ExistingId_ReturnsOk()
		{
			
			// Arrange
			var id = 1;

			// Act
			var response = await _client.GetAsync($"/api/Annonces/{id}");

		

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}

		[Test]
		public async Task GetAnnonce_NonExistingId_ReturnsNotFound()
		{
			
			// Arrange
			var id = 100;

			// Act
			var response = await _client.GetAsync($"/api/Annonces/{id}");

			// Assert
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}

		[Test]
		public async Task PutAnnonce_ExistingId_ReturnsNoContent()
		{
			// Arrange
				var id = 1;
				var annonceForPut = new AnnonceDTO
				{
					AnnonceId = id,
					Titel = "The Book of Eve",
					Price = 200,
					Kategori = "Bog",
					Beskrivelse = "Det er en flot bog",
					Studieretning = "SW",
					BilledeSti = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSehNExO7Os6_qM7ZpPmqGhgLK84E6pnPvaPQ&usqp=CAU",
					EfManagerId = 3,
					Stand = "Som ny",
					CheckBoxValue = true,
					NumberOfWeeks = 2
				};

				var content = new StringContent(JsonSerializer.Serialize(annonceForPut), Encoding.UTF8, "application/json");

				// Get the info before the update
				var beforeUpdateResponse = await _client.GetAsync($"/api/Annonces/{id}");
				beforeUpdateResponse.EnsureSuccessStatusCode();
				var beforeUpdateAnnonce = await beforeUpdateResponse.Content.ReadFromJsonAsync<AnnonceDTO>();

				// Act
				var response = await _client.PutAsync($"/api/Annonces/{id}", content);
				response.EnsureSuccessStatusCode();

				// Get the after after the update
				var afterUpdateResponse = await _client.GetAsync($"/api/Annonces/{id}");
				afterUpdateResponse.EnsureSuccessStatusCode();
				var afterUpdateAnnonce = await afterUpdateResponse.Content.ReadFromJsonAsync<AnnonceDTO>();
				// Assert
				Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
				
				Assert.AreEqual(annonceForPut.AnnonceId, afterUpdateAnnonce.AnnonceId);
				Assert.AreEqual(annonceForPut.Titel, afterUpdateAnnonce.Titel);
				Assert.AreEqual(annonceForPut.Price, afterUpdateAnnonce.Price);
				Assert.AreEqual(annonceForPut.Kategori, afterUpdateAnnonce.Kategori);
				Assert.AreEqual(annonceForPut.Beskrivelse, afterUpdateAnnonce.Beskrivelse);
				Assert.AreEqual(annonceForPut.Studieretning, afterUpdateAnnonce.Studieretning);
				Assert.AreEqual(annonceForPut.BilledeSti, afterUpdateAnnonce.BilledeSti);
				Assert.AreEqual(annonceForPut.EfManagerId, afterUpdateAnnonce.EfManagerId);
				Assert.AreEqual(annonceForPut.Stand, afterUpdateAnnonce.Stand);
				Assert.AreEqual(annonceForPut.CheckBoxValue, afterUpdateAnnonce.CheckBoxValue);
				Assert.AreEqual(annonceForPut.NumberOfWeeks, afterUpdateAnnonce.NumberOfWeeks);
		}


		[Test]
		public async Task PutAnnonce_NonExistingId_ReturnsNotFound()
		{
			var id = 100;
			var annonceForPut = new AnnonceDTO
			{
				AnnonceId = id,
				Titel = "The Book of Eve",
				Price = 200,
				Kategori = "Bog",
				Beskrivelse = "Det er en flot bog",
				Studieretning = "SW",
				BilledeSti = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSehNExO7Os6_qM7ZpPmqGhgLK84E6pnPvaPQ&usqp=CAU",
				EfManagerId = 3,
				Stand = "Som ny",
				ChatRoomId = 1,
				CheckBoxValue = true,
				NumberOfWeeks = 2
			};
			
			var content = new StringContent(JsonSerializer.Serialize(annonceForPut), Encoding.UTF8, "application/json");

			// Act
			var response = await _client.PutAsync($"/api/Annonces/{id}", content);
			var responseContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseContent);

			// Assert
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}

		[Test]
		public async Task PostAnnonce_ReturnsCreated()
		{
			// Arrange

			var annonceForPut = new AnnonceDTO
			{
				Titel = "TestBog",
				Price = 200,
				Kategori = "Bog",
				Beskrivelse = "Det er en fin bog",
				Studieretning = "WS",
				BilledeSti =
					"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSehNExO7Os6_qM7ZpPmqGhgLK84E6pnPvaPQ&usqp=CAU",
				EfManagerId = 3,
				Stand = "Som ny",
				ChatRoomId = 1,
				CheckBoxValue = false
			};

				var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(annonceForPut), Encoding.UTF8, "application/json");

			// Act
			var response = await _client.PostAsync("/api/Annonces", content);
			var responseContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseContent);

			// Assert
			Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
		}

		[Test]
		public async Task DeleteAnnonce_ExistingId_ReturnsNoContent()
		{
			// Arrange
			var id = 12;

			// Act
			var response = await _client.DeleteAsync($"/api/Annonces/{id}");

			// Assert
			Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
		}

		[Test]
		public async Task DeleteAnnonce_NonExistingId_ReturnsNotFound()
		{
			// Arrange
			var id = 100;

			// Act
			var response = await _client.DeleteAsync($"/api/Annonces/{id}");

			// Assert
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}


	}
	
}
