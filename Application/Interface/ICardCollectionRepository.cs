using ApplicationCore.Entities;
using ApplicationCore.SeedWork;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interface
{
    public interface IAsyncCardCollectionRepository : IEfRepository<CardCollection>
    {
    }
}
