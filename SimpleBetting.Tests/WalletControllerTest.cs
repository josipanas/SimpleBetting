using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Repo.Mocks;
using SimpleBetting.Service;
using SimpleBetting.Service.Models;
using SimpleBetting.WebAPI.Controllers;
using Xunit;

namespace SimpleBetting.Tests
{
    public class WalletControllerTest
    {
        public WalletControllerTest()
        {
            _repository = new TransactionRepositoryMock();
            _mapper = new Mapper(new MapperConfiguration(conf => { conf.AddProfile(new MappingProfile()); }));
            _controller = new WalletController(_repository, _mapper);
        }

        private readonly WalletController _controller;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _repository;

        [Fact]
        public void CreateTransactionReturnsCreatedTransaction()
        {
            // Arrange
            var json = JObject.Parse("{\"amount\":50}");

            // Act
            var createdResult = _controller.CreateTransaction(json) as CreatedResult;

            // Assert
            Assert.NotNull(createdResult);
            Assert.IsType<CreatedResult>(createdResult);
            Assert.IsType<CreatedPaymentTransactionDto>(createdResult.Value);
        }


        [Fact]
        public void GetAllTransactionsReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAllTransactions() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Transaction>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetWalletBalanceReturnsRightBalance()
        {
            // Act
            var okResult = _controller.GetWalletBalance() as OkObjectResult;

            // Assert
            Assert.Equal(90.50, okResult.Value);
        }
    }
}