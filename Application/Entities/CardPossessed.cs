using ApplicationCore.SeedWork;
using System;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Carte obtenue
    /// </summary>
    public class CardPossessed : Entity
    {
        /// <summary>
        /// Constructeur vide
        /// </summary>
        public CardPossessed() { }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        public CardPossessed(string cardId)
        {
            CardId = cardId;
            DeckId = null;
            Exchange = false;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        /// <param name="inDeck">Présente dans un deck</param>
        /// <param name="exchange">Soumise à l'échange</param>
        public CardPossessed(string cardId, Guid? deckId, bool exchange)
        {
            CardId = cardId;
            DeckId = deckId;
            Exchange = exchange;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        /// <param name="inDeck">Présente dans un deck</param>
        /// <param name="exchange">Soumise à l'échange</param>
        /// <param name="exchangeDate">Date d'échange de la carte</param>
        public CardPossessed(string cardId, Guid? deckId, bool exchange, DateTime? exchangeDate)
            : this(cardId, deckId, exchange)
        {
            ExchangeDate = exchangeDate;
        }



        /// <summary>
        /// Carte avec toutes les informations relatives 
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Présente dans un deck
        /// </summary>
        public Guid? DeckId { get; set; }

        /// <summary>
        /// Soumise à l'échange
        /// </summary>
        public bool Exchange { get; set; }

        /// <summary>
        /// Date d'échange de la carte 
        /// </summary>
        public DateTime? ExchangeDate { get; set; }
    }
}
