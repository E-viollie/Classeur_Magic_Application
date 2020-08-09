using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class CardService
    {
        public Exceptional<List<Card>> GetAllCards()
        {
            MtgApiManager.Lib.Service.CardService service = new MtgApiManager.Lib.Service.CardService();
            Exceptional<List<Card>> cards = service.All();

            return cards;
        }


    }
}
