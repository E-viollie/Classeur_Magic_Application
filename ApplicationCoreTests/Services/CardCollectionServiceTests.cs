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
    public class CardCollectionServiceTests
    {

        private readonly Mock<IAsyncCardCollectionRepository> ICardCollectionRepoMock;

        [TestMethod()]
        public async Task CreateAsyncCardCollectionTest()
        {
            Card cardMock = new Card();
            DateTime todayDate = DateTime.Today;

            CardCollection collection = new CardCollection();
            collection.ExchangeDate = todayDate;
            collection.DeckId = Guid.Empty;
            collection.Exchange = false;
            collection.Card = cardMock;

            ICardCollectionRepoMock.Setup(c => c.AddAsync(It.IsAny<CardCollection>())).ReturnsAsync(collection);
            
            Mock<IUnitOfWork> UnitOfWorkMock = new Mock<IUnitOfWork>();
            UnitOfWorkMock.Setup(x => x.Save()).ReturnsAsync(1);

            CardCollection CardCollectionToCreate = new CardCollection();
            CardCollectionToCreate.ExchangeDate = todayDate;
            CardCollectionToCreate.DeckId = Guid.Empty;
            CardCollectionToCreate.Exchange = false;
            CardCollectionToCreate.Card = cardMock;

            CardCollectionService service = new CardCollectionService(ICardCollectionRepoMock.Object, UnitOfWorkMock.Object);

            bool result = await service.CreateCardCollectionWithCard(cardMock.Id, 1);

            Assert.Equals(result, true);
        }

        [TestMethod()]
        public void CardCollectionServiceTest()
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
        public void CreateCardCollectionWithCardTest()
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
        public void UpdateCardCollectionModifyCardTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteCardCollectionTest()
        {
            throw new NotImplementedException();
        }
    }
}