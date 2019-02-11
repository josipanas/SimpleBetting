using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBetting.Data.Entities;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Service.Interfaces;
using SimpleBetting.Service.Models;

namespace SimpleBetting.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TicketService(ITicketRepository ticketRepository, ITransactionRepository transactionRepository)
        {
            _ticketRepository = ticketRepository;
            _transactionRepository = transactionRepository;
        }

        public Ticket CreateTicket(TicketForCreationDto ticketInput)
        {
            double totalOdd = 1;
            foreach (var match in ticketInput.SelectedMatches) totalOdd *= match.SelectedOddValue;

            var payoutTransaction =
                _transactionRepository.AddTransaction(Transaction.TransactionType.Payout, ticketInput.Stake);

            var stakeWithHandlingCost = ticketInput.Stake - ticketInput.Stake * 0.05;

            var possiblePayout = totalOdd * stakeWithHandlingCost;

            var ticket = new Ticket
            {
                TotalOdd = Math.Round(totalOdd, 2),
                Stake = Math.Round(ticketInput.Stake, 2),
                PossiblePayout = Math.Round(possiblePayout, 2),
                TransactionId = payoutTransaction.Id
            };

            var createdTicket = _ticketRepository.AddTicket(ticket);
            _transactionRepository.UpdateTicketId(payoutTransaction, ticket.Id);

            if (IsWinningTicket(ticket))
            {
                var paymentTransaction =
                    _transactionRepository.AddTransaction(Transaction.TransactionType.Payment, ticket.PossiblePayout);
                _transactionRepository.UpdateTicketId(paymentTransaction, ticket.Id);
            }

            return createdTicket;
        }

        public bool ValidateTicketInput(TicketForCreationDto ticketInput)
        {
            if (ticketInput.SelectedMatches.Any(m => m.IsTopOffer))
                if (!ValidateTopOffer(ticketInput.SelectedMatches))
                    return false;

            //only one offer can be selected per match
            var matchIds = new HashSet<int>();
            foreach (var match in ticketInput.SelectedMatches)
                if (!matchIds.Add(match.Id))
                    return false;

            return true;
        }

        private bool ValidateTopOffer(List<MatchForTicketCreationDto> selectedMatches)
        {
            if (selectedMatches.Count < 6) return false;

            var topOfferCounter = 0;
            foreach (var match in selectedMatches)
            {
                if (match.IsTopOffer)
                    topOfferCounter++;
                if (match.SelectedOddValue < 1.1 || topOfferCounter > 1)
                    return false;
            }

            return true;
        }

        //Dummy logic for determining winning ticket
        private bool IsWinningTicket(Ticket ticket)
        {
            return ticket.Id % 2 == 0;
        }
    }
}