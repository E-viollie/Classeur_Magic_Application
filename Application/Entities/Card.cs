using ApplicationCore.Enum.Card;
using ApplicationCore.SeedWork;
using System;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Carte obtenue
    /// </summary>
    public class Card : Entity
    {
        /// <summary>
        /// Constructeur vide
        /// </summary>
        public Card() { }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="card">Carte avec toutes les informations relatives</param>
        public Card(string cardId)
        {
            CardId = cardId;
            DeckId = null;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="cardId">Id de la carte dans l'API</param>
        /// <param name="deckId">Id du Deck où la carte est présente</param>
        /// <param name="stateCard">Etat de possession ou d'échange </param>
        /// <param name="exchangeDate">Date d'échange de la carte</param>
        /// <param name="condition">Condition physique de la carte</param>
        /// <param name="foil">Carte foil ou non</param>
        /// <param name="language">Langue de la carte</param>
        public Card(string cardId, int? deckId, StateCards stateCard, DateTime? exchangeDate, Conditions condition, bool foil, Language language)
            : this(cardId)
        {
            //TODO :Ajouter image carte + deck
            DeckId = deckId;
            StateCard = stateCard;
            ExchangeDate = exchangeDate;
            Condition = condition;
            Foil = foil;
            Language = language;
        }



        /// <summary>
        /// Carte avec toutes les informations relatives 
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Présente dans un deck
        /// </summary>
        public int? DeckId { get; set; }

        //public Deck Deck { get; set; } 

        /// <summary>
        /// <see cref="StateCards"/>
        /// </summary>
        public StateCards StateCard { get; set; }

        /// <summary>
        /// Date d'échange de la carte 
        /// </summary>
        public DateTime? ExchangeDate { get; set; }

        /// <summary>
        /// <see cref="Conditions"/>
        /// </summary>
        public Conditions Condition { get; set; }

        /// <summary>
        /// La carte est foil 
        /// bool = true
        /// </summary>
        public bool Foil { get; set; }

        /// <summary>
        /// Langue de la carte 
        /// <see cref="Language"/>
        /// </summary>
        public Language Language { get; set; }


    }
}
