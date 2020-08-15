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
    public class CardPossessedService : ICardPossessedService
    {
        private readonly MtgApiManager.Lib.Service.CardService _cardService;
        private readonly IAsyncCardPossessedRepository _CardPossessedRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CardPossessedService(IAsyncCardPossessedRepository CardPossessedRepository, IUnitOfWork unitOfWork)
        {
            _cardService = new MtgApiManager.Lib.Service.CardService();
            _CardPossessedRepository = CardPossessedRepository;
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
        public async Task<bool> CreateCardPossessedWithCard(string cardId, int quantity)
        {
            if (cardId is null)
            {
                //todo :levée d'exception
            }

            if (quantity == 0)
            {
                //todo :levée d'exception
            }

            bool successAdded;


            for (int i = 1; i <= quantity; i++)
            {
                await _CardPossessedRepository.AddAsync(new CardPossessed(cardId));
            }

            int affectedRows = await _unitOfWork.Save();
            successAdded = affectedRows == 1 ? true : false;

            return successAdded;
        }

        /// <summary>
        /// récupérer une carte
        /// </summary>
        /// <param name="collectionId">Guid de la carte en notre possession</param>
        /// <returns><see cref="CardPossessed"/> carte </returns>
        public async Task<CardPossessed> GetCardPossessed(Guid collectionId)
        {
            if (Guid.Empty == collectionId)
            {
                //todo :levée d'exception
            }

            //Récupération de la liste de carte posséder
            CardPossessed CardPossessed = await _CardPossessedRepository.FindByIdAsync(collectionId);


            return CardPossessed;
        }

        /// <summary>
        /// Récupération de toutes les cartes
        /// </summary>
        /// <returns><see cref="CardPossessed"/>liste</returns>        
        public async Task<IReadOnlyList<CardPossessed>> GetAllCardPossessed()
        {
            //Récupération de la liste de carte posséder
            IReadOnlyList<CardPossessed> CardPossessed = await _CardPossessedRepository.FindAsync();

            return CardPossessed;
        }

        /// <summary>
        /// mise à jour d'une collection en cas de carte
        /// </summary>
        /// <param name="collectionId">guid: id de la carte à mettre à jour</param>
        /// <param name="cardToUpdate">Carte avec les modifications à sauvegarder</param>
        /// <returns>bool : true => réussi, false => échoué</returns>
        public async Task<bool> UpdateCardPossessedModifyCard(Guid collectionId, CardPossessed cardToUpdate)
        {
            if (Guid.Empty == collectionId)
            {
                //todo :levée d'exception
            }

            CardPossessed CardPossessed = await _CardPossessedRepository.FindByIdAsync(collectionId);

            if (CardPossessed is null)
            {
                //todo :levée d'exception
            }

            CardPossessed = cardToUpdate;

            await _CardPossessedRepository.UpdateAsync(CardPossessed);

            int affectedRows = await _unitOfWork.Save();

            bool successUpdated = affectedRows == 1 ? true : false;

            return successUpdated;
        }

        /// <summary>
        /// supression d'une carte
        /// </summary>
        /// <param name="collectionId">Guid : id de la carte à supprimer</param>
        /// <returns>bool : true => réussi, false => échoué</returns>
        public async Task<bool> DeleteCardPossessed(Guid collectionId)
        {
            if (Guid.Empty.Equals(collectionId))
            {
                //todo :levée d'exception
            }

            _CardPossessedRepository.DeleteAsync(collectionId);

            int affectedRows = await _unitOfWork.Save();

            bool successDeleted = affectedRows == 1 ? true : false;

            return successDeleted;
        }


    }
}
