using ApplicationCore.SeedWork;
using MtgApiManager.Lib.Model;
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
        public Deck(string name, List<CardCollection> mainBoard, List<CardCollection> sideDeck, List<CardCollection> maybeDeck)
        {
            Name = name;
            MainBoard = mainBoard;
            SideDeck = sideDeck;
            MaybeDeck = maybeDeck;
        }


        /// <summary>
        /// Nom du Deck
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Liste de carte principale du Deck 
        /// </summary>
        public List<CardCollection> MainBoard { get; set; }

        /// <summary>
        /// Liste de carte secondaire du Deck
        /// </summary>
        public List<CardCollection> SideDeck { get; set; }

        /// <summary>
        /// Liste de carte pouvant être rajouter au Deck
        /// </summary>
        public List<CardCollection> MaybeDeck { get; set; }

    }
}
