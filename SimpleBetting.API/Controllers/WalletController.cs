using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Service.Models;

namespace SimpleBetting.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public WalletController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWalletBalance()
        {
            var balance = _transactionRepository.GetWalletBalance();

            return Ok(balance);
        }

        [HttpGet("transactions")]
        public IActionResult GetAllTransactions()
        {
            var transactions = _transactionRepository.GetAllTransactions();
            
            if (transactions.Count == 0) return NotFound();

            return Ok(transactions);
        }

        [HttpPost("transactions/create/payment")]
        public IActionResult CreateTransaction([FromBody] JObject value)
        {
            var amount = value["amount"].ToObject<double>();
            if (amount <= 0) return BadRequest();

            var createdTransaction = _transactionRepository.AddTransaction(Transaction.TransactionType.Payment, amount);
            if (createdTransaction == null) return BadRequest();

            return Created($"transactions/create/payment/{createdTransaction.Id}",
                _mapper.Map<CreatedPaymentTransactionDto>(createdTransaction));
        }
    }
}