using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.SeedWork
{
    public interface IEfRepository<T> where T : Entity
    {
        /// <summary>
        /// Ajoute une entity en base de donnée
        /// </summary>
        /// <param name="entity"><see cref="Entity"/></param>
        /// <returns>return l'entity enregistrée avec l'Id attribué</returns>
        public Task<T> AddAsync(T entity);

        /// <summary>
        /// Récupérer toutes les entity
        /// </summary>
        /// <returns>une liste des entités enregistrées en base en donnée</returns>
        public Task<IReadOnlyList<T>> FindAsync();

        /// <summary>
        /// Récupérer l'entity relatif à l'Id passé en paramètre
        /// </summary>
        /// <param name="id">Guid correspondant à l'entity que l'on souhaite récupérer</param>
        /// <returns>l'entity</returns>
        public Task<T> FindByIdAsync(Guid id);

        /// <summary>
        /// Mise à jour de l'entity
        /// </summary>
        /// <param name="entity">Entity à mettre à jour</param>
        /// <returns>l'entity avec les données</returns>
        public Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Suppression de l'entity
        /// </summary>
        /// <param name="Id">Guid correspondant à l'entity que l'on souhaite supprimer</param>
        public void DeleteAsync(Guid Id);

    }
}
