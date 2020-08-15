using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ApplicationCore.Interface;
using ApplicationCore.Entities;
using MtgApiManager.Lib.Model;
using ApplicationCore.SeedWork;
using System.Threading.Tasks;
using MtgApiManager.Lib.Dto;

namespace ApplicationCore.Services.Tests
{
    [TestClass()]
    public class CardPossessedServiceTests
    {

        private readonly Mock<IAsyncCardPossessedRepository> ICardPossessedRepoMock;

        [TestMethod()]
        public async Task CreateAsyncCardPossessedTest()
        {
            DateTime todayDate = DateTime.Today;

            CardPossessed collection = new CardPossessed();
            collection.ExchangeDate = todayDate;
            collection.DeckId = Guid.Empty;
            collection.Exchange = false;
            collection.CardId = Faker.Lorem.GetFirstWord();

            ICardPossessedRepoMock.Setup(c => c.AddAsync(It.IsAny<CardPossessed>())).ReturnsAsync(collection);
            
            Mock<IUnitOfWork> UnitOfWorkMock = new Mock<IUnitOfWork>();
            UnitOfWorkMock.Setup(x => x.Save()).ReturnsAsync(1);

            CardPossessed CardPossessedToCreate = new CardPossessed();
            CardPossessedToCreate.ExchangeDate = todayDate;
            CardPossessedToCreate.DeckId = Guid.Empty;
            CardPossessedToCreate.Exchange = false;
            CardPossessedToCreate.CardId = Faker.Lorem.GetFirstWord();

            CardPossessedService service = new CardPossessedService(ICardPossessedRepoMock.Object, UnitOfWorkMock.Object);

            bool result = await service.CreateCardPossessedWithCard(collection.CardId, 1);

            Assert.Equals(result, true);
        }

        [TestMethod()]
        public void CardPossessedServiceTest()
        {

            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SearchCardNotPossessedTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SearchCardNotPossessedTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateCardPossessedWithCardTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetCardPossessedTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllCardPossessedTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateCardPossessedModifyCardTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteCardPossessedTest()
        {
            throw new NotImplementedException();
        }
    }
}