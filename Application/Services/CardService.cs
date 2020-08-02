using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Service
    {
        public Exceptional<List<Card>> GetAllCards()
        {
            CardService service = new CardService();
            Exceptional<List<Card>> cards = service.All();

            return cards;
        }


    }
}
