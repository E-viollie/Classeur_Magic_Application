using ApplicationCore.Entities;
using ApplicationCore.Interface;
using Infrastructure.Config;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CardCollectionRepository : EfRepository<CardCollection>, IAsyncCardCollectionRepository
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
        public CardCollectionRepository(CardContext context) : base(context)
        {
            _context = context;
        }
    }
}
