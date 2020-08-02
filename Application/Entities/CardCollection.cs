using ApplicationCore.SeedWork;
using MtgApiManager.Lib.Model;
using System;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Carte obtenue
    /// </summary>
    public class CardCollection : Entity
    {
        /// <summary>
        /// Constructeur vide
        /// </summary>
        public CardCollection() { }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        public CardCollection(Card card)
        {
            Card = card;
            InDeck = null;
            Exchange = false;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        /// <param name="inDeck">Présente dans un deck</param>
        /// <param name="exchange">Soumise à l'échange</param>
        public CardCollection(Card card, Guid? inDeck, bool exchange)
        {
            Card = card;
            InDeck = inDeck;
            Exchange = exchange;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        /// <param name="inDeck">Présente dans un deck</param>
        /// <param name="exchange">Soumise à l'échange</param>
        /// <param name="exchangeDate">Date d'échange de la carte</param>
        public CardCollection(Card card, Guid? inDeck, bool exchange, DateTime? exchangeDate) 
            : this(card, inDeck, exchange)
        {
            ExchangeDate = exchangeDate;
        }



        /// <summary>
        /// Carte avec toutes les informations relatives 
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Présente dans un deck
        /// </summary>
        public Guid? InDeck { get; set; }

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
