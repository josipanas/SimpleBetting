using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Repo.Repositories;
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
            _mapper = new Mapper(new MapperConfiguration(conf => { conf.AddProfile(new UnitMappingProfile()); }));
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
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.GetMatchById(testId);

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
    }
}