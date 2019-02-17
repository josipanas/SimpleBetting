using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Repo.Mocks;
using SimpleBetting.Service;
using SimpleBetting.Service.Models;
using SimpleBetting.WebAPI.Controllers;
using Xunit;

namespace SimpleBetting.Tests
{
    public class MatchesControllerTest
    {
        public MatchesControllerTest()
        {
            _repository = new MatchRepositoryMock();
            _mapper = new Mapper(new MapperConfiguration(conf => { conf.AddProfile(new MappingProfile()); }));
            _controller = new MatchesController(_repository, _mapper);
        }

        private readonly IMatchRepository _repository;
        private readonly IMapper _mapper;
        private readonly MatchesController _controller;

        [Fact]
        public void GetAllReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<MatchDto>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetMatchByIdReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetMatchById(3);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetMatchByIdReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetMatchById(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetMatchByIdReturnsRightItem()
        {
            // Arrange
            var testId = 2;

            // Act
            var okResult = _controller.GetMatchById(testId) as OkObjectResult;

            // Assert
            Assert.IsType<MatchDto>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as MatchDto).Id);
        }

        [Fact]
        public void GetMatchesBySportIdReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetMatchesBySportId(6);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetMatchesBySportIdReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetMatchesBySportId(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetMatchesBySportIdReturnsRightItems()
        {
            // Arrange
            var testId = 2;

            // Act
            var okResult = _controller.GetMatchesBySportId(testId) as OkObjectResult;

            // Assert
            Assert.IsType<List<MatchDto>>(okResult.Value);
            Assert.Single(okResult.Value as List<MatchDto>);
        }
    }
}