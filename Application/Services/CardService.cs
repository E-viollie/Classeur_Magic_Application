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
    public class CardService : ICardService
    {
        private readonly MtgApiManager.Lib.Service.CardService _cardService;
        private readonly IAsyncCardRepository _CardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CardService(IAsyncCardRepository CardPossessedRepository, IUnitOfWork unitOfWork)
        {
            _cardService = new MtgApiManager.Lib.Service.CardService();
            _CardRepository = CardPossessedRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Recherche de la carte non obtenue
        /// </summary>
        /// <param name="name">nom de la carte</param>
        /// <param name="language">langue de la carte</param>
        /// <returns>Liste de carte correspondante à la recherche</returns>
        public List<MtgApiManager.Lib.Model.Card> SearchCardNotPossessed(string name, string language)
        {
            CardQueryParameter cardQueryParameter = new CardQueryParameter();

            List<MtgApiManager.Lib.Model.Card> cardsSearch = _cardService.Where(c => c.Name, name)
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
        public List<MtgApiManager.Lib.Model.Card> SearchCardNotPossessed(string name, string language, string extension)
        {
            CardQueryParameter cardQueryParameter = new CardQueryParameter();

            List<MtgApiManager.Lib.Model.Card> cardsSearch = _cardService.Where(c => c.Name, name)
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
                await _CardRepository.AddAsync(new Entities.Card(cardId));
            }

            int affectedRows = await _unitOfWork.Save();
            successAdded = affectedRows == 1 ? true : false;

            return successAdded;
        }

        /// <summary>
        /// récupérer une carte
        /// </summary>
        /// <param name="collectionId">Int de la carte en notre possession</param>
        /// <returns><see cref="MtgApiManager.Lib.Model.Card"/> carte </returns>
        public async Task<Entities.Card> GetCardPossessed(int collectionId)
        {
            if (collectionId > 0)
            {

            }

            //Récupération de la liste de carte posséder
            Entities.Card CardPossessed = await _CardRepository.FindByIdAsync(collectionId);


            return CardPossessed;
        }

        /// <summary>
        /// Récupération de toutes les cartes
        /// </summary>
        /// <returns><see cref="MtgApiManager.Lib.Model.Card"/>liste</returns>        
        public async Task<IReadOnlyList<Entities.Card>> GetAllCardPossessed()
        {
            //Récupération de la liste de carte posséder
            IReadOnlyList<Entities.Card> CardPossessed = await _CardRepository.FindAsync();

            return CardPossessed;
        }

        /// <summary>
        /// mise à jour d'une collection en cas de carte
        /// </summary>
        /// <param name="collectionId">Int: id de la carte à mettre à jour</param>
        /// <param name="cardToUpdate">Carte avec les modifications à sauvegarder</param>
        /// <returns>bool : true => réussi, false => échoué</returns>
        public async Task<bool> UpdateCardPossessedModifyCard(int? collectionId, Entities.Card cardToUpdate)
        {
            if (collectionId > 0)
            {
                //todo :levée d'exception
            }

            Entities.Card CardPossessed = await _CardRepository.FindByIdAsync(collectionId);

            if (CardPossessed is null)
            {
                //todo :levée d'exception
            }

            CardPossessed = cardToUpdate;

            await _CardRepository.UpdateAsync(CardPossessed);

            int affectedRows = await _unitOfWork.Save();

            bool successUpdated = affectedRows == 1 ? true : false;

            return successUpdated;
        }

        /// <summary>
        /// supression d'une carte
        /// </summary>
        /// <param name="collectionId">Int : id de la carte à supprimer</param>
        /// <returns>bool : true => réussi, false => échoué</returns>
        public async Task<bool> DeleteCardPossessed(int collectionId)
        {
            if (collectionId > 0)
            {
                //todo :levée d'exception
            }

            _CardRepository.DeleteAsync(collectionId);

            int affectedRows = await _unitOfWork.Save();

            bool successDeleted = affectedRows == 1 ? true : false;

            return successDeleted;
        }


    }
}
