using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ModelsApi.Models;
using ModelsApi.Models.DTOs;

namespace ModelsApi.Test
{
	internal class ChatControllerTest
	{
		private HttpClient _client = null;

		[OneTimeSetUp]
		public void Init()
		{
			var applicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
			_client = applicationFactory.CreateClient();
		}


		[Test]
		public async Task GetMessage_returnsRightOwner()
		{
			// Arrange
			var id = 2;

			// Act
			var response = await _client.GetAsync($"/api/Chat/annonce/{id}/owner");

			var responseBody = await response.Content.ReadAsStringAsync();
			var resultAnnonces = JsonConvert.DeserializeObject<Annonce>(responseBody);
			Console.WriteLine(resultAnnonces.EfManagerId);
			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


		}
		[Test]
		public async Task GetMessage_returnsNotFound()
		{
			// Arrange
			var id = 999;

			// Act
			var response = await _client.GetAsync($"/api/Chat/annonce/{id}/owner");

			// Assert
			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);


		}



		[Test]
		public async Task GetMessage_returnsRightChat()
		{
			// Arrange
			var id = 2;

			// Act
			var response = await _client.GetAsync($"/api/Chat/rooms/{id}/messages");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}



	}
}
