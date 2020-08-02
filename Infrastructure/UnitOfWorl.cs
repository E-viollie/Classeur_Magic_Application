using ApplicationCore.SeedWork;
using Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;
        private bool _disposed;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(Context context)
        {
            this._context = context;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// sauvegarde
        /// </summary>
        /// <returns></returns>
        public async Task<int> Save()
        {
            int affectedRows = await this._context.SaveChangesAsync()
                                                  .ConfigureAwait(false);
            return affectedRows;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }

            this._disposed = true;
        }
    }
}
