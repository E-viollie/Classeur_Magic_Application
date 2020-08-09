using ApplicationCore.Entities;
using ApplicationCore.Interface;
using ApplicationCore.SeedWork;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CardCollectionService
    {
        private readonly MtgApiManager.Lib.Service.CardService _cardService;
        private readonly IAsyncCardCollectionRepository _cardCollectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CardCollectionService(IAsyncCardCollectionRepository cardCollectionRepository, IUnitOfWork unitOfWork)
        {
            _cardService = new MtgApiManager.Lib.Service.CardService();
            _cardCollectionRepository = cardCollectionRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Recherche de la carte non obtenue
        /// </summary>
        /// <param name="name">nom de la carte</param>
        /// <param name="language">langue de la carte</param>
        /// <returns>Liste de carte correspondante à la recherche</returns>
        public List<Card> SearchCardNotPossessed(string name, string language)
        {
            CardQueryParameter cardQueryParameter = new CardQueryParameter();

            List<Card> cardsSearch = _cardService.Where(c => c.Name, name)
                                         .Where(c => c.Language, language).All().Value;

            return cardsSearch;
        }

        /// <summary>
        /// Recherche de la carte non obtenue
        /// </summary>
        /// <param name="name">nom de la carte</param>
        /// <param name="language">langue de la carte</param>
        /// <param name="extension">extension de la carte</param>
        /// <returns>Liste de carte correspondant à la recherche</returns>
        public List<Card> SearchCardNotPossessed(string name, string language, string extension)
        {
            CardQueryParameter cardQueryParameter = new CardQueryParameter();

            List<Card> cardsSearch = _cardService.Where(c => c.Name, name)
                                         .Where(c => c.Language, language)
                                         .Where(c => c.Set, extension).All().Value;

            return cardsSearch;
        }

        /// <summary>
        /// création d'une collection avec une ou plusieurs cartes
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<bool> CreateCardCollectionWithCard(string cardId, int quantity)
        {
            if (cardId is null)
            {
                //todo :levée d'exception
            }

            if (quantity == 0)
            {
                //todo :levée d'exception
            }

            //appel à l'API pour trouver la carte correspondante
            Card card = _cardService.Find(cardId).Value;

            if (card is null)
            {
                //todo :levée d'exception
            }

            bool successAdded;


            for (int i = 1; i <= quantity; i++)
            {
                //par défault les cartes ajoutées ne sont pas soumise à l'échange ni dans un deck
                await _cardCollectionRepository.AddAsync(new CardCollection(card));
            }

            int affectedRows = await _unitOfWork.Save();
            successAdded = affectedRows == 1 ? true : false;

            return successAdded;
        }

        /// <summary>
        /// récupérer une carte
        /// </summary>
        /// <param name="collectionId">Guid de la carte en notre possession</param>
        /// <returns><see cref="CardCollection"/> carte </returns>
        public async Task<CardCollection> GetCardPossessed(Guid collectionId)
        {
            if (Guid.Empty == collectionId)
            {
                //todo :levée d'exception
            }

            //Récupération de la liste de carte posséder
            CardCollection cardCollection = await _cardCollectionRepository.FindByIdAsync(collectionId);


            return cardCollection;
        }

        /// <summary>
        /// Récupération de toutes les cartes
        /// </summary>
        /// <returns><see cref="CardCollection"/>liste</returns>        
        public async Task<IReadOnlyList<CardCollection>> GetAllCardPossessed()
        {
            //Récupération de la liste de carte posséder
            IReadOnlyList<CardCollection> cardCollection = await _cardCollectionRepository.FindAsync();

            return cardCollection;
        }

        /// <summary>
        /// mise à jour d'une collection en cas de carte
        /// </summary>
        /// <param name="collectionId">guid: id de la carte à mettre à jour</param>
        /// <param name="cardToUpdate">Carte avec les modifications à sauvegarder</param>
        /// <returns>bool : true => réussi, false => échoué</returns>
        public async Task<bool> UpdateCardCollectionModifyCard(Guid collectionId, CardCollection cardToUpdate)
        {
            if (Guid.Empty == collectionId)
            {
                //todo :levée d'exception
            }

            CardCollection cardCollection = await _cardCollectionRepository.FindByIdAsync(collectionId);

            if (cardCollection is null)
            {
                //todo :levée d'exception
            }

            cardCollection = cardToUpdate;

            await _cardCollectionRepository.UpdateAsync(cardCollection);

            int affectedRows = await _unitOfWork.Save();

            bool successUpdated = affectedRows == 1 ? true : false;

            return successUpdated;
        }

        /// <summary>
        /// supression d'une carte
        /// </summary>
        /// <param name="collectionId">Guid : id de la carte à supprimer</param>
        /// <returns>bool : true => réussi, false => échoué</returns>
        public async Task<bool> DeleteCardCollection(Guid collectionId)
        {
            if (Guid.Empty.Equals(collectionId))
            {
                //todo :levée d'exception
            }

            _cardCollectionRepository.DeleteAsync(collectionId);

            int affectedRows = await _unitOfWork.Save();

            bool successDeleted = affectedRows == 1 ? true : false;

            return successDeleted;
        }


    }
}
