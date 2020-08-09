﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config
{
    /// <summary>
    /// Context pour l'enregistrement en base de donnée
    /// </summary>
    public class CardContext : DbContext
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="options"></param>
        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
        }

        //Todo : ajouter des tables

        /// <summary>
        /// DbSet d'une collection de card
        /// </summary>
        public DbSet<CardCollection> cardCollection { get; set; }

        /// <summary>
        /// DbSet de d'un deck
        /// </summary>
        public DbSet<Deck> Decks { get; set; }

    }
}
