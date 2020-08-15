using ApplicationCore.Entities;
using ApplicationCore.Interface;
using Infrastructure.Config;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CardPossessedRepository : EfRepository<CardPossessed>, IAsyncCardPossessedRepository
    {
        /// <summary>
        /// contexte
        /// </summary>
#pragma warning disable CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant
        private readonly CardContext _context;
#pragma warning restore CS0108 // Un membre masque un membre hérité ; le mot clé new est manquant

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="context"></param>
        public CardPossessedRepository(CardContext context) : base(context)
        {
            _context = context;
        }
    }
}
