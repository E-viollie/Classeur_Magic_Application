using ApplicationCore.SeedWork;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    //TODO : implement for EDH deck
    public class Deck : Entity
    {
        /// <summary>
        /// Constructeur vide
        /// </summary>
        public Deck()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name">Nom du Deck</param>
        /// <param name="mainBoard">Liste de carte principale du Deck</param>
        /// <param name="sideDeck">Liste de carte pouvant être rajouter au Deck</param>
        /// <param name="maybeDeck">Liste de carte pouvant être rajouter au Deck</param>
        public Deck(string name, List<Card> cardList)
        {
            Name = name;
            CardList = cardList;
        }


        /// <summary>
        /// Nom du Deck
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Liste de carte principale du Deck 
        /// </summary>
        public List<Card> CardList { get; set; }

    }
}
