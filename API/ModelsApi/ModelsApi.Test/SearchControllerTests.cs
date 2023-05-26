using Microsoft.AspNetCore.Mvc.Testing;
using ModelsApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Test
{
	internal class SearchControllerTests
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
		public async Task SearchAnnonces_KeywordIsPresentInBookTitles()
		{
			// Arrange
			var keyword = "My"; 

			// Act
			var response = await _client.GetAsync($"/api/search/{keyword}");
			var responseBody = await response.Content.ReadAsStringAsync();

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			var resultAnnonces = JsonConvert.DeserializeObject<List<Annonce>>(responseBody);
			Assert.IsTrue(resultAnnonces.Count > 0);

			foreach (var annonce in resultAnnonces)
			{
				Console.WriteLine("Annonce Titel: " + annonce.Titel);
				Assert.IsTrue(annonce.Titel.Contains(keyword, StringComparison.OrdinalIgnoreCase));
			}
		}


		[Test]
		public async Task SearchAnnonces_ReturnsEmptyListForInvalidKeyword()
		{
			// Arrange
			var keyword = "Kylling";

			// Act
			var response = await _client.GetAsync($"/api/search/{keyword}");
			var responseBody = await response.Content.ReadAsStringAsync();

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			var resultAnnonces = JsonConvert.DeserializeObject<List<Annonce>>(responseBody);
			Assert.IsNotNull(resultAnnonces);
			Assert.IsTrue(resultAnnonces.Count == 0);
		}


	}
}
