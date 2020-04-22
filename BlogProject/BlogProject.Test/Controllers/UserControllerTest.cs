using BlogProject.Core.Services.Interfaces;
using BlogProject.DataLayer.Entities.User;
using BlogProject.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Net;
using System.Threading.Tasks;
using Moq.Protected;

namespace BlogProject.Test.Controllers
{
    public class UserControllerTest
    {
        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();


        [Fact]
        public async Task GetUser_IsNotNull()
        {
            BlogProject.API.Controllers.UsersController UsersController = new API.Controllers.UsersController(userRepository.Object);

            var actual = await UsersController.GetUsers();

            Assert.NotNull(actual);
        }


        [Fact]
        public async Task GetUser_IsCallBackIActionResult()
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.GetUsers();

            Assert.IsAssignableFrom<IActionResult>(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(10000)]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetUserById_IsCallBackNotNull(int Id)
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.GetUser(Id);

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(10000)]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetUserById_IsCallBackIActionResult(int Id)
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.GetUser(Id);

            Assert.IsAssignableFrom<IActionResult>(actual);
        }

        [Fact]
        public async Task PostUser_IsCallBackNotNull()
        {
            UsersController UsersController = new UsersController(userRepository.Object);
            User User = new User();

            var actual = await UsersController.PostUser(User);

            Assert.NotNull(actual);
        }

        [Fact]
        public async Task PostUser_IsCallBackIActionResult()
        {
            UsersController UsersController = new UsersController(userRepository.Object);
            User User = new User();

            var actual = await UsersController.PostUser(User);

            Assert.IsAssignableFrom<IActionResult>(actual);
        }


        //[Fact]
        //public async Task PostUser_IsCallBackIActionResul()
        //{
        //    Mock<UsersController> MockusersController;
        //    //Arrange
        //    MockusersController = new Mock<UsersController>();

        //   // var controller = MockusersController.Object;
        //    User User = new User();
        //    //Act
        //    var result =await MockusersController.Object.PostUser(User);

        //    //Assert
        //    Assert.IsAssignableFrom<ViewResult>(result);
        //    MockusersController.VerifyAll();
        //}

        [Theory]
        [InlineData(0, null)]
        [InlineData(1, null)]
        [InlineData(-1, null)]
        [InlineData(1000, null)]

        public async Task PutUser_IsCallBackNotNull(int Id, User user)
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.PutUser(Id, user);

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(0, null)]
        [InlineData(1, null)]
        [InlineData(-1, null)]
        [InlineData(1000, null)]
        public async Task PutUser_IsCallBackIActionResult(int Id, User user)
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.PutUser(Id, user);

            Assert.IsAssignableFrom<IActionResult>(actual);
        }



        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1000)]

        public async Task DeleteUser_IsCallBackNotNull(int Id)
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.DeleteUser(Id);

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1000)]
        public async Task DeleteUser_IsCallBackIActionResult(int Id)
        {
            UsersController UsersController = new UsersController(userRepository.Object);

            var actual = await UsersController.DeleteUser(Id);

            Assert.IsAssignableFrom<IActionResult>(actual);
        }

    }
}
