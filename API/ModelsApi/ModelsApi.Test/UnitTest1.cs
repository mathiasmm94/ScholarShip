//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using ModelsApi.Controllers;
//using ModelsApi.Data;
//using ModelsApi.Models.DTOs;
//using ModelsApi.Models.Entities;
//using ModelsApi.Utilities;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Moq;

//namespace ModelsApi.Tests.Controllers
//{
//	[TestFixture]
//	public class AccountControllerTests
//	{
//		private Mock<ApplicationDbContext> _dbContextMock;
//		private Mock<IOptions<AppSettings>> _appSettingsMock;
//		private AccountController _accountController;

//		[SetUp]
//		public void Setup()
//		{
//			_dbContextMock = new Mock<ApplicationDbContext>();
//			_appSettingsMock = new Mock<IOptions<AppSettings>>();
//			_accountController = new AccountController(_dbContextMock.Object, _appSettingsMock.Object);
//		}

//namespace ModelsApi.Test
//{
//	public class Tests
//	{
//		[SetUp]
//		public void Setup()
//		{
//		}

//		[Test]
//		public void Test1()
//		{
//			Assert.Pass();
//		}
//	}
//}